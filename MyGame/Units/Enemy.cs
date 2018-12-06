using System;

namespace MyGame.Units
{
    public class Enemy : Unit
    {
        private int id;

        public Enemy(int id, string name, int x, int y) : base(name, x, y)
        {
            this.id = id;
        }

        public void MoveLeft()
        {
            x--;
        }

        public void MoveRight()
        {
            x++;
        }

        public void MoveDown()
        {
            y++;
        }

        public void PrintInfo()
        {
            Console.WriteLine(name + "[" + id + "] is at position: [" + x + ", " + y + "]");
        }

        public int GetID()
        {
            return id;
        }

        public void Render()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("-");
        }
    }
}