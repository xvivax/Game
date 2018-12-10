using System;

namespace MyGame.Units
{
    public class Lives : TextLine
    {
        private string data;
        public Lives(int x, int y, int width, string data) : base(x, y, width, data)
        {
            this.data = data;
        }
    }
}