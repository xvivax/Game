namespace MyGame.Units
{
    public class Unit
    {
        protected int x;
        protected int y;
        protected string name;

        public Unit(string name, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

    }
}