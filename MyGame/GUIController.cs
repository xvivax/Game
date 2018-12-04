using System;

namespace MyGame
{
    public class GUIController
    {
        private MenuWindow menuWindow;
        private bool needToRender = true;
        private CreditWindow creditWindow;
        private GameController gameController;

        private bool displayCredits = false;

        public GUIController()
        {
            menuWindow = new MenuWindow();
            creditWindow = new CreditWindow();
            gameController = new GameController();
        }

        public void ShowMenu()
        {
            do
            {
                menuWindow.Render();

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
                        switch (menuWindow.GetButtonIndex())
                        {
                            case 0:
                                needToRender = false;
                                gameController.StartGame();
                                break;
                            case 1:
                                displayCredits = true;
                                break;
                            case 2:
                                needToRender = false;
                                break;
                            default:
                                Console.WriteLine("I don't know how did you get here, but you shouldn't be here. ERROR!!!");
                                break;
                        }
                        break;
                }

                if (displayCredits)
                {
                    do
                    {
                        creditWindow.Render();

                        consoleKey = Console.ReadKey(true);

                        switch (consoleKey.Key)
                        {
                            case ConsoleKey.Escape:
                                displayCredits = false;
                                break;
                            case ConsoleKey.Enter:
                                displayCredits = false;
                                break;
                        }

                    } while (displayCredits);

                }

            } while (needToRender);
        }


    }
}