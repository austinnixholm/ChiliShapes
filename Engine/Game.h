/****************************************************************************************** 
 *	Chili DirectX Framework Version 16.07.20											  *	
 *	Game.h																				  *
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
#pragma once

#include "Keyboard.h"
#include "Mouse.h"
#include "Graphics.h"
#include <list>
#include "DrawCommand.h"

class Game
{
public:
	Game(class MainWindow& wnd);
	Game(const Game&) = delete;
	Game& operator=(const Game&) = delete;
	void Go();

	struct Point
	{
		Point();

		Point(int ptX, int ptY)
		{
			this->ptX = ptX;
			this->ptY = ptY;
		}

		Point* addToList(std::list<Point>& list, Point p)
		{
			list.push_back(p);
			return this;
		}

		int getPtX()
		{
			return this->ptX;
		}

		int getPtY()
		{
			return this->ptY;
		}
		void setRgb(int r, int g, int b)
		{
			this->r = r;
			this->g = g;
			this->b = b;
		}
		int getR() { return this->r; }
		int getG() { return this->g; }
		int getB() { return this->b; }
	private:
		int r = 100, g = 255, b = 255;
		int ptX;
		int ptY;
	};

private:
	void ComposeFrame();
	void UpdateModel();
	static DrawCommand::CommandType getCommandType(std::string cmdType);
	void ParseCommand(DrawCommand::CommandType commandType, std::string rawCommandData, DrawCommand& command);
	void ParseAndAddCommand(std::string command);
	void WaitForComs();
	void DrawCircle(DrawCommand command, int centerX, int centerY);
	void DrawCircle(double radius, int r, int g, int b, int fR, int fG, int fB, int centerX, int centerY, bool temp);
	void DrawSquare(DrawCommand command, int centerX, int centerY);
	void DrawSquare(int width, int height, int r, int g, int b, int centerX, int centerY, bool temp);
	bool InBounds(Point p);

	/********************************/
	/*  User Functions              */
	/********************************/
private:
	MainWindow& wnd;
	Graphics gfx;
	std::list<Point> drawPoints;
	std::list<Point> tempPoints;
	Point placePoint = Point(0, 0);
	bool drawing = false;
	bool cmdReady = false;
	/********************************/
	/*  User Variables              */
	/********************************/
};
