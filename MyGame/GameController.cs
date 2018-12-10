using System;
using System.Collections.Generic;
using MyGame.Units;

namespace MyGame
{
    public class GameController
    {
        private int SCREEN_WIDTH = 40;
        private int SCREEN_HEIGHT = 20;
        public void StartGame()
        {
            GameScreen myGame = new GameScreen(SCREEN_WIDTH, SCREEN_HEIGHT);

            myGame.SetHero(new Hero("SuperMan", 20, 15));

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                myGame.AddEnemy(new Enemy(i, "Barsukas", rnd.Next(1, SCREEN_WIDTH - 1), rnd.Next(0, 5)));
            }
            //myGame.Render();

            //myGame.GetHero().MoveLeft();
            //myGame.MoveAllEnemiesDown();
            //myGame.GetEnemyByID(2);

            //myGame.Render();

            bool needToRender = true;

            do
            {
                Console.Clear();

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPress = Console.ReadKey(true);
                    switch (keyPress.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (myGame.GetHero().X > 1)
                            {
                                myGame.GetHero().MoveLeft();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (myGame.GetHero().X < SCREEN_WIDTH - 2)
                            {
                                myGame.GetHero().MoveRight();
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            myGame.AddBullet(new Bullet(myGame.GetHero().X, myGame.GetHero().Y));
                            break;
                    }
                }

                myGame.Render();
                Console.SetCursorPosition(0,0);
                System.Threading.Thread.Sleep(500);
            } while (needToRender);
        }
    }
}