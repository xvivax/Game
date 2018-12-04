using System;
using System.Collections.Generic;
using MyGame.Units;

namespace MyGame
{
    public class GameController
    {
        public void StartGame()
        {
            
            GameScreen myGame = new GameScreen(30, 80);

            myGame.SetHero(new Hero("SuperMan", 20, 15));

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                myGame.AddEnemy(new Enemy(i, "Barsukas", rnd.Next(1, 30), rnd.Next(1, 80)));
            }
            myGame.Render();

            myGame.GetHero().MoveLeft();
            myGame.MoveAllEnemiesDown();
            myGame.GetEnemyByID(2);

            myGame.Render();

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
                            myGame.GetHero().MoveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            myGame.GetHero().MoveRight();
                            break;
                    }
                }
                myGame.Render();
                System.Threading.Thread.Sleep(500);
            } while (needToRender);

            Console.ReadKey();
        }
    }
}