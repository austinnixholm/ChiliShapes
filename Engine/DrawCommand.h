#pragma once
class DrawCommand
{
public:
	enum CommandType
	{
		NONE,
		CIRCLE,
		SQUARE
	};

	DrawCommand();
	DrawCommand(CommandType type);
	DrawCommand(int radius, int r, int g, int b);
	DrawCommand(int radius, int r, int g, int b, int fR, int fG, int fB);
	DrawCommand(int width, int height, int r, int g, int b);
	virtual ~DrawCommand();
	CommandType getType() const;
	virtual int getRadius();
	virtual int getWidth();
	virtual int getHeight();
	virtual int getR();
	virtual int getG();
	virtual int getB();
	virtual int getFillR();
	virtual int getFillG();
	virtual int getFillB();
private:
	CommandType type;
	int radius, r, g, b;
	int fillR = -1, fillG = -1, fillB = -1;
	int width, height;
};
