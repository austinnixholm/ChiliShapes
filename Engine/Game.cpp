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
#include <math.h>

#define DEBUG true

#define PIPE_NAME TEXT("\\\\.\\pipe\\CHILICOM")
#define PIPE_MAX_BUFFER 512

#define INITAL_COMMAND_DELIMITER "="
#define COMMAND_DATA_DELIMITER ","

DrawCommand currentCommand;

std::vector<std::string> split(std::string s, std::string delimiter)
{
	size_t pos_start = 0, pos_end, delim_len = delimiter.length();
	std::string token;
	std::vector<std::string> res;

	while ((pos_end = s.find(delimiter, pos_start)) != std::string::npos)
	{
		token = s.substr(pos_start, pos_end - pos_start);
		pos_start = pos_end + delim_len;
		res.push_back(token);
	}

	res.push_back(s.substr(pos_start));
	return res;
}

DrawCommand::CommandType Game::getCommandType(std::string cmdType)
{
	if (cmdType == "SQ")
		return DrawCommand::CommandType::SQUARE;
	else if (cmdType == "CIR")
		return DrawCommand::CommandType::CIRCLE;
	return DrawCommand::CommandType::NONE;
}

void Game::ParseCommand(DrawCommand::CommandType commandType, std::string rawCommandData,
                        DrawCommand& command)
{
	std::vector<std::string> splitData = split(rawCommandData, COMMAND_DATA_DELIMITER);
	switch (commandType)
	{
	case DrawCommand::CommandType::CIRCLE:
		if (splitData.size() == 4) // params: radius,r,g,b
		{
			int radius = std::stoi(splitData[0]);
			int r = std::stoi(splitData[1]), g = std::stoi(splitData[2]), b = std::stoi(splitData[3]);

			DrawCommand cmd(radius, r, g, b); //circle draw command
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

void Game::DrawCircle(double radius, int r, int g, int b, int centerX, int centerY, bool temp)
{
	double rad = radius * 1.0;
	double x1, y1;
	for (double angleDegrees = 0; angleDegrees < 360.0; angleDegrees++)
	{
		x1 = rad * cos(DegreesToRadians(angleDegrees));
		y1 = rad * sin(DegreesToRadians(angleDegrees));
		Point p = Point(centerX + x1, centerY + y1);
		p.setRgb(r, g, b);
		if (!temp)
			drawPoints.push_front(p);
		else
			tempPoints.push_back(p);
	}

	drawing = false;
}

void Game::DrawCircle(DrawCommand command, int centerX, int centerY)
{
	DrawCircle(command.getRadius(), command.getR(), command.getG(), command.getB(), centerX, centerY, false);
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
	if (p.getPtX() >= 0 && p.getPtY() >= 0 && p.getPtX() <= Graphics::ScreenWidth && p.getPtY() <= Graphics::
		ScreenHeight)
	{
		if (wnd.mouse.LeftIsPressed())
		{
			if (cmdIsValid && !drawing)
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
			           placePoint.getPtX(), placePoint.getPtY(), true);
		} else if (currentCommand.getType() == DrawCommand::SQUARE)
		{
			DrawSquare(currentCommand.getWidth(), currentCommand.getHeight(), currentCommand.getR(), currentCommand.getG(), currentCommand.getB(),
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
