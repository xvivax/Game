using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.Units;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GUIController guiController = new GUIController();
            guiController.ShowMenu();
        }
    }
}
