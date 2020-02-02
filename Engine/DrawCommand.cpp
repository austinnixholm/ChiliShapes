#include "DrawCommand.h"


DrawCommand::DrawCommand() : DrawCommand(NONE)
{
}

DrawCommand::DrawCommand(CommandType type)
{
	this->type = type;
}

DrawCommand::DrawCommand(int radius, int r, int g, int b) : DrawCommand(CIRCLE)
{
	this->radius = radius;
	this->r = r;
	this->g = g;
	this->b = b;
}

DrawCommand::DrawCommand(int width, int height, int r, int g, int b) : DrawCommand(SQUARE)
{
	this->width = width;
	this->height = height;
	this->r = r;
	this->g = g;
	this->b = b;
}



DrawCommand::CommandType DrawCommand::getType() const
{
	return this->type;
}

int DrawCommand::getB()
{
	return this->b;
}

int DrawCommand::getG()
{
	return this->g;
}


int DrawCommand::getR()
{
	return this->r;
}

int DrawCommand::getRadius()
{
	return this->radius;
}

int DrawCommand::getWidth()
{
	return this->width;
}

int DrawCommand::getHeight()
{
	return this->height;
}

DrawCommand::~DrawCommand()
= default;
