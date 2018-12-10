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
        private int LIVES = 3;

        private Lives lives;
        private Hero hero;
        private List<Enemy> enemies;
        private Window gameScreenwindow;
        private List<Bullet> bullets;

        // Speed for all enemies
        private float enemiesSpeed = 5.5f;
        private long currentTime = 0;
        private long previousTime = 0;

        // Speed for all bullets
        private float bulletsSpeed = 0.5f;
        private long currentTime2 = 0;
        private long previousTime2 = 0;

        public GameScreen(int width, int height)
        {
            this.width = width;
            this.height = height;

            lives = new Lives(width + 3, 1, 10, "Liko gyvybiu: " + LIVES);
            enemies = new List<Enemy>();
            gameScreenwindow = new Window(0, 0, width, height, '@');
            bullets = new List<Bullet>();

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

        public void AddBullet(Bullet bullet)
        {
            bullets.Add(bullet);
        }

        public void RemoveBullet(Bullet bullet)
        {
            bullets.Remove(bullet);
        }

        public Enemy GetEnemyByID(int id)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetID() == id)
                {
                    //enemy.MoveDown();
                    return enemy;
                }
            }

            return null;
        }

        public void Render()
        {
            lives.Render();
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

            currentTime2 = Stopwatch.GetTimestamp() / Stopwatch.Frequency;
            float elapsedTime2 = currentTime2 - previousTime2;

            if (bullets != null)
            {
                if (elapsedTime2 > bulletsSpeed)
                {
                    for (int i = 0; i < bullets.Count; i++)
                    {
                        bullets[i].Move();

                        if (bullets[i].GetY() < 1)
                        {
                            RemoveBullet(bullets[i]);
                        }

                        for (int j = 0; j < enemies.Count; j++)
                        {
                            if (bullets[i].GetX() == enemies[j].GetX() && bullets[i].GetY() == enemies[j].GetY())
                            {
                                //enemies.Remove(enemies[j]);
                                enemies.Remove(GetEnemyByID(j));
                                RemoveBullet(bullets[i]);
                            }
                        }

                        previousTime2 = currentTime2;
                    }                 
                }
            }

            if (bullets != null)
            {
                foreach (Bullet bullet in bullets)
                {
                    bullet.Render();
                }
            }
        }
    }
}