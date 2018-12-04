using System;

namespace MyGame.Units
{
    public class Hero : Unit
    {
        public Hero(string name, int x, int y) : base(name, x, y)
        {

        }

        public void MoveLeft()
        {
            x--;
        }

        public void MoveRight()
        {
            x++;
        }

        public void PrintInfo()
        {
            Console.WriteLine(name + " is at position: [" + x + ", " + y + "]");
        }
    }
}