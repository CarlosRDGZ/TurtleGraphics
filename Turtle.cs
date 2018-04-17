namespace TurtleGraphics
{
    class Turtle
    {
        public static readonly int[] DELTA = new int[4] { 1, 1, -1, -1};

        private int _x;
        private int _y;
        private int _facing;
        public int X => _x;
        public int Y => _y;
        public int Facing => _facing;
        public string Pen { get; set; }

        public Turtle(int x, int y)
        {
            _x = x;
            _y = y;
            _facing = 0;
            Pen = "up";
        }

        public void TurnRight()
        {
            if (_facing < 3)
                _facing++;
            else
                _facing = 0; 
        }

        public void TurnLeft()
        {
            if (_facing > 0)
                _facing--;
            else
                _facing = 3;
        }

        public void Move()
        {
            if (_facing % 2 == 0)
                _y += DELTA[_facing];
            else
                _x += DELTA[_facing];
        }

        public override string ToString()
        {
            return "{ x: " + _x + ", y: " + _y + ", facing: " + 
                (_facing == 0 ? "rigth" : 
                _facing == 1 ? "down" :
                _facing == 2 ? "left" : "up") + 
                " }" +
                System.Environment.NewLine;
        }
    }
}

/*
       3
    2     0
       1
 */