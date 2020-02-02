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
	DrawCommand(int width, int height, int r, int g, int b);
	virtual ~DrawCommand();
	CommandType getType() const;
	virtual int getRadius();
	virtual int getWidth();
	virtual int getHeight();
	virtual int getR();
	virtual int getG();
	virtual int getB();
private:
	CommandType type;
	int radius, r, g, b;
	int width, height;
};
