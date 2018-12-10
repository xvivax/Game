using System;
using System.Diagnostics;

namespace MyGame.Units
{
    public class Bullet : Unit
    {
        public Bullet(int x, int y) : base("", x, y)
        {
        }

        public void Render()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(".");
        }

        public void Move()
        {
            y--;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

    }
}