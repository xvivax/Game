using System;

namespace MyGame.Units
{
    public class Hero : Unit
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Hero(string name, int x, int y) : base(name, x, y)
        {
            X = x;
            Y = y;
        }

        public void MoveLeft()
        {
            X--;
        }

        public void MoveRight()
        {
            X++;
        }

        public void PrintInfo()
        {
            Console.WriteLine(name + " is at position: [" + X + ", " + Y + "]");
        }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("^");
        }
    }
}