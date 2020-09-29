using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;


namespace Game
{
    public class Program
    {
        public static float deltaTime;
        private static float lastFrameTime;
        private static DateTime startDate;

        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();

        public static Player player;



        private static void Main(string[] args)
        {
            Initialization();

            while (true)
            {
                var currentTime = (float)(DateTime.Now - startDate).TotalSeconds;
                deltaTime = currentTime - lastFrameTime;
                lastFrameTime = currentTime;

                InputDetection();
                Update();
                Render();

            }
        }

        private static void Initialization()
        {
            startDate = DateTime.Now;
            Engine.Initialize("ElCabron", 800, 675);
            player = new Player(new Vector2(50, 400), 0.75f, 1f, 200, 100);

            Random random = new Random();

            float x = 0;
            float y = 5;

            for (int i = 0; i < 6; i++)
            {
                y += 100;
                x = 450;
                for (int k = 0; k < 3; k++)
                {
                    x += 100;
                    Enemy enemies2 = new Enemy(new Vector2(x, y), 0.75f, 0f, 100f, 100);
                    enemies.Add(enemies2);

                }

            }
        }

        private static void InputDetection()
        {
            player.InputDetection();
        }

        private static void Update()
        {
            if (player != null)
            {
                player.Update();
            }

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update();
            }

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Update();
            }

        }

        private static void Render()
        {
            Engine.Clear();
            Engine.Draw("Png/Background/Fondo.jpeg");

            if (player != null)
            {
                player.Render();
            }

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Render();
            }

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Render();

            }
            Engine.Show();
        }
    }
}