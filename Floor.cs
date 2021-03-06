using System;
namespace TurtleGraphics
{
    class Floor
    {
        private readonly int _rows;
        private readonly int _cols;
        private readonly bool[,] _floor;
        public readonly Turtle Turtle;

        public Floor(int rows, int cols)
        {
            _floor = new bool[rows, cols];
            Turtle = new Turtle(0, 0);
            _rows = rows;
            _cols = cols;
        }

        public void PenUp() =>
            Turtle.Pen = "up";

        public void PenDown() =>
            Turtle.Pen = "down";
        
        public void Draw()
        {
            if (Turtle.Pen == "down")
                _floor[Turtle.X, Turtle.Y] = true;
        }

        public void MoveTurtle(int steps)
        {
            int pos;
            if (Turtle.Facing % 2 == 0)
                pos = Turtle.Y;
            else
                pos = Turtle.X;

            int moves = Math.Abs(Math.Max(0, 
                Math.Min(pos + (steps * Turtle.DELTA[Turtle.Facing] + (Turtle.DELTA[Turtle.Facing] * -1)), 
                _cols)) - pos);

            for (int i = 0; i < moves; i++)
            {
                Draw();
                Turtle.Move();
            }
        }

        public void TurnTurtleRight() => Turtle.TurnRight();

        public void TurnTurtleLeft() => Turtle.TurnLeft();

        public string TurtleData() => Turtle.ToString();

        public void Clear()
        {
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    _floor[i,j] = false;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (i != Turtle.X || j != Turtle.Y)
                        str += _floor[i,j] ? " * " : "   ";
                    else
                        str += " $ ";
                }
                str += Environment.NewLine;
            }
            return str;
        }
    }
}