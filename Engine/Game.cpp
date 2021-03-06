/****************************************************************************************** 
 *	Chili DirectX Framework Version 16.07.20											  *	
 *	Game.cpp																			  *
 *	Copyright 2016 PlanetChili.net <http://www.planetchili.net>							  *
 *																						  *
 *	This file is part of The Chili DirectX Framework.									  *
 *																						  *
 *	The Chili DirectX Framework is free software: you can redistribute it and/or modify	  *
 *	it under the terms of the GNU General Public License as published by				  *
 *	the Free Software Foundation, either version 3 of the License, or					  *
 *	(at your option) any later version.													  *
 *																						  *
 *	The Chili DirectX Framework is distributed in the hope that it will be useful,		  *
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of						  *
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the						  *
 *	GNU General Public License for more details.										  *
 *																						  *
 *	You should have received a copy of the GNU General Public License					  *
 *	along with The Chili DirectX Framework.  If not, see <http://www.gnu.org/licenses/>.  *
 ******************************************************************************************/
#define _USE_MATH_DEFINES

#include "MainWindow.h"
#include "Game.h"
#include <sstream>
#include <vector>
#include "stringhelpers.h"
#include <math.h>

#define DEBUG false

#define PIPE_NAME TEXT("\\\\.\\pipe\\CHILICOM")
#define PIPE_MAX_BUFFER 512

#define INITAL_COMMAND_DELIMITER "="
#define COMMAND_DATA_DELIMITER ","

DrawCommand currentCommand;

DrawCommand::CommandType Game::getCommandType(std::string cmdType)
{
	if (cmdType == "SQ")
		return DrawCommand::CommandType::SQUARE;
	else if (cmdType == "CIR")
		return DrawCommand::CommandType::CIRCLE;
	return DrawCommand::CommandType::NONE;
}

bool Game::InBounds(Point p)
{
	return p.getPtX() >= 0 && p.getPtY() >= 0 && p.getPtX() <= Graphics::ScreenWidth && p.getPtY() <= Graphics::
		ScreenHeight;
}

void Game::ParseCommand(DrawCommand::CommandType commandType, std::string rawCommandData,
                        DrawCommand& command)
{
	std::vector<std::string> splitData = stringhelpers::split(rawCommandData, COMMAND_DATA_DELIMITER);
	switch (commandType)
	{
	case DrawCommand::CommandType::CIRCLE:
		if (splitData.size() == 7) // params: radius,r,g,b
		{
			int radius = std::stoi(splitData[0]);
			int r = std::stoi(splitData[1]), g = std::stoi(splitData[2]), b = std::stoi(splitData[3]);
			int fR = std::stoi(splitData[4]), fG = std::stoi(splitData[5]), fB = std::stoi(splitData[6]);

			DrawCommand cmd(radius, r, g, b, fR, fG, fB); //circle draw command
			currentCommand = cmd;
		}
		break;
	case DrawCommand::CommandType::SQUARE:
		if (splitData.size() == 5) // params: width,height, r, g, b
		{
			int width = std::stoi(splitData[0]);
			int height = std::stoi(splitData[1]);
			int r = std::stoi(splitData[2]), g = std::stoi(splitData[3]), b = std::stoi(splitData[4]);
			DrawCommand cmd(width, height, r, g, b);
			currentCommand = cmd;
		}
		break;
	}
}

void Game::ParseAndAddCommand(std::string command)
{
	std::size_t initialDelim = command.find(INITAL_COMMAND_DELIMITER);
	if (initialDelim != std::string::npos)
	{
		std::string commandType = command.substr(0, initialDelim);

		DrawCommand::CommandType drawCommandType = getCommandType(commandType);

		const int len = command.size() - commandType.size();
		std::string nextSection = command.substr(initialDelim + 1, len - 1);

		ParseCommand(drawCommandType, nextSection, currentCommand);

		printf("command parsed\n");
	}
}

void Game::WaitForComs()
{
	try
	{
		//Open pipe client and attempt to read data!
		HANDLE hPipe;
		DWORD dwRead;
		CHAR chBuf[PIPE_MAX_BUFFER];


		hPipe = CreateFile(PIPE_NAME,
		                   GENERIC_READ | GENERIC_WRITE,
		                   0,
		                   NULL,
		                   OPEN_EXISTING,
		                   0,
		                   NULL);
		if (hPipe != INVALID_HANDLE_VALUE)
		{
			BOOL result = ReadFile(hPipe,
			                       chBuf,
			                       PIPE_MAX_BUFFER,
			                       &dwRead,
			                       NULL);
			if (result)
			{
				std::stringstream ss;
				ss << chBuf;
				std::string strResult = ss.str();
				std::size_t pos = strResult.find("\0");
				const std::string realStr = strResult.substr(pos);
				ParseAndAddCommand(realStr);
			}

			CloseHandle(hPipe);
		}
	}
	catch (int e)
	{
		printf("error");
	}
}

static double DegreesToRadians(double degrees)
{
	return (degrees * M_PI) / 180.0;
}

void Game::DrawSquare(int width, int height, int r, int g, int b, int centerX, int centerY, bool temp)
{
	int leftX = centerX - width / 2 - 1, topY = centerY - height / 2;
	int rightX = centerX + width / 2 + 1, bottomY = centerY + height / 2 + 1;
	for (int x = leftX; x <= rightX; x++)
	{
		Point p = Point(x, topY);
		Point p2 = Point(x, bottomY);
		p2.setRgb(r, g, b);
		p.setRgb(r, g, b);
		if (!temp)
		{
			drawPoints.push_front(p);
			drawPoints.push_front(p2);
		}
		else
		{
			tempPoints.push_back(p);
			tempPoints.push_back(p2);
		}
	}
	for (int y = topY; y <= bottomY; y++)
	{
		Point p = Point(leftX, y);
		Point p2 = Point(rightX, y);
		p.setRgb(r, g, b);
		p2.setRgb(r, g, b);
		if (!temp)
		{
			drawPoints.push_front(p);
			drawPoints.push_front(p2);
		}
		else
		{
			tempPoints.push_back(p);
			tempPoints.push_back(p2);
		}
	}
	drawing = false;
}

void Game::DrawSquare(DrawCommand command, int centerX, int centerY)
{
	DrawSquare(command.getWidth(), command.getHeight(), command.getR(), command.getG(), command.getB(), centerX,
	           centerY, false);
}

void Game::DrawCircle(double radius, int r, int g, int b, int fR, int fG, int fB, int centerX, int centerY, bool temp)
{
	double rad = radius;
	double x1, y1;

	double sinus = sin(45);
	double range = 1;

	bool isFilled = fR != -1 && fG != -1 && fB != -1;

	if (isFilled)
	{
		for (int i = rad; i >= range; --i)
		{
			int j = sqrt(rad * rad - i * i);

			for (int k = -j; k <= j; k++)
			{
				std::list<Point> points;

				Point p1 = Point(centerX - k, centerY + i);
				p1.addToList(points, p1);
				Point p2 = Point(centerX - k, centerY - i);
				Point p3 = Point(centerX + i, centerY + k);
				Point p4 = Point(centerX - i, centerY - k);
				points.push_back(p1);
				points.push_back(p2);
				points.push_back(p3);
				points.push_back(p4);

				for (Point p : points)
				{
					if (InBounds(p))
					{
						p.setRgb((isFilled && i != radius ? fR : r), (isFilled && i != radius ? fG : b),
						         (isFilled && i != radius ? fB : b));
						if (temp)
							tempPoints.push_front(p);
						else
							drawPoints.push_back(p);
					}
				}
			}
		}
		range = r * sinus;
		for (int i = centerX - range + 1; i < centerX + range; i++)
		{
			for (int j = centerY - range + 1; j < centerY + range; j++)
			{
				Point p = Point(i, j);

				p.setRgb(fR, fG, fB);
				if (InBounds(p))
				{
					if (temp)
						tempPoints.push_front(p);
					else
						drawPoints.push_back(p);
				}
			}
		}
	}
	else
	{
		for (double angleDegrees = 0; angleDegrees < 360.0; angleDegrees++)
		{
			x1 = rad * cos(DegreesToRadians(angleDegrees));
			y1 = rad * sin(DegreesToRadians(angleDegrees));
			Point p = Point(centerX + x1, centerY + y1);
			if (p.getPtX() >= 0 && p.getPtY() >= 0 && p.getPtX() <= Graphics::ScreenWidth && p.getPtY() <= Graphics::
				ScreenHeight)
			{
				p.setRgb(r, g, b);
				if (!temp)
					drawPoints.push_back(p);
				else
					tempPoints.push_front(p);
			}
		}
	}
	drawing = false;
}

void Game::DrawCircle(DrawCommand command, int centerX, int centerY)
{
	DrawCircle(command.getRadius(), command.getR(), command.getG(), command.getB(), command.getFillR(),
	           command.getFillG(), command.getFillB(), centerX, centerY, false);
}

Game::Game(MainWindow& wnd)
	:
	wnd(wnd),
	gfx(wnd)
{
	placePoint = Point(0, 0);
	if (DEBUG)
	{
		AllocConsole();
		freopen("conin$", "r", stdin);
		freopen("conout$", "w", stdout);
		freopen("conout$", "w", stderr);
	}
}

void Game::Go()
{
	gfx.BeginFrame();
	WaitForComs();
	UpdateModel();
	ComposeFrame();
	gfx.EndFrame();
}

void Game::UpdateModel()
{
	Point p = Point(wnd.mouse.GetPosX(), wnd.mouse.GetPosY());
	bool cmdIsValid = currentCommand.getType() != DrawCommand::NONE;
	cmdReady = cmdIsValid;
	if (InBounds(p))
	{
		if (wnd.mouse.LeftIsPressed())
		{
			if (!cmdIsValid && wnd.kbd.KeyIsPressed(VK_CONTROL))
			{
				p.setRgb(255, 40, 40);
				drawPoints.push_front(p);
			}

			if (cmdIsValid)
			{
				drawing = true;
				switch (currentCommand.getType())
				{
				case DrawCommand::CIRCLE:
					DrawCircle(currentCommand, p.getPtX(), p.getPtY());
					break;
				case DrawCommand::SQUARE:
					DrawSquare(currentCommand, p.getPtX(), p.getPtY());
					break;
				}
				currentCommand = DrawCommand();
				placePoint = Point(-1, -1);
			}
		}

		if (cmdIsValid)
			placePoint = Point(p.getPtX(), p.getPtY());
	}
}

void Game::ComposeFrame()
{
	if (cmdReady)
	{
		if (currentCommand.getType() == DrawCommand::CIRCLE)
		{
			DrawCircle(currentCommand.getRadius(), currentCommand.getR(), currentCommand.getG(), currentCommand.getB(),
			           currentCommand.getFillR(), currentCommand.getFillG(), currentCommand.getFillB(),
			           placePoint.getPtX(), placePoint.getPtY(), true);
		}
		else if (currentCommand.getType() == DrawCommand::SQUARE)
		{
			DrawSquare(currentCommand.getWidth(), currentCommand.getHeight(), currentCommand.getR(),
			           currentCommand.getG(), currentCommand.getB(),
			           placePoint.getPtX(), placePoint.getPtY(), true);
		}
	}

	for (Point p : tempPoints)
	{
		gfx.PutPixel(p.getPtX(), p.getPtY(), p.getR(), p.getG(), p.getB());
	}

	for (Point p : drawPoints)
	{
		gfx.PutPixel(p.getPtX(), p.getPtY(), p.getR(), p.getG(), p.getB());
	}
	tempPoints.clear();
}
