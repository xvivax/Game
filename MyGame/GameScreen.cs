using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using MyGame.Units;

namespace MyGame
{
    public class GameScreen
    {
        private int width;
        private int height;

        private Hero hero;
        private List<Enemy> enemies;
        private Window gameScreenwindow;

        // Speed for all enemies
        private float enemiesSpeed = 1.5f;
        private long currentTime = 0;
        private long previousTime = 0;

        public GameScreen(int width, int height)
        {
            this.width = width;
            this.height = height;

            enemies = new List<Enemy>();
            gameScreenwindow = new Window(0, 0, width, height, '@');
        }

        public void SetHero(Hero hero)
        {
            this.hero = hero;
        }

        public Hero GetHero()
        {
            return hero;
        }

        public void AddEnemy(Enemy enemy)
        {
             enemies.Add(enemy);
        }

        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.MoveDown();
            }
        }

        public Enemy GetEnemyByID(int id)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetID() == id)
                {
                    enemy.MoveDown();
                    return enemy;
                }
            }

            return null;
        }

        public void Render()
        {
            gameScreenwindow.Render();
            hero.Render();

            currentTime = Stopwatch.GetTimestamp() / Stopwatch.Frequency;
            float elapsedTime = currentTime - previousTime;

            if ( elapsedTime > enemiesSpeed)
            {
                MoveAllEnemiesDown();
                previousTime = currentTime;
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.Render();
            }
        }
    }
}