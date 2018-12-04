using System;

namespace MyGame
{
    public class GUIController
    {
        private MenuWindow menuWindow;
        private bool needToRender = true;
        private CreditWindow creditWindow;

        public GUIController()
        {
            menuWindow = new MenuWindow();
            creditWindow = new CreditWindow();
        }

        public void ShowMenu()
        {
            do
            {
                menuWindow.Render();
                //creditWindow.Render();

                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        menuWindow.PreviousButton();
                        break;
                    case ConsoleKey.RightArrow:
                        menuWindow.NextButton();
                        break;
                    case ConsoleKey.Enter:
                        break;
                }

            } while (needToRender);
        }


    }
}