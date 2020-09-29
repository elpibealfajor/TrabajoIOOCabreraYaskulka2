using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;


namespace Game
{
    public class Program //arranque y gameloop
    {
        public static float deltaTime;
        private static float lastFrameTime;
        private static DateTime startDate;





        private static void Main(string[] args)
        {
            Initialization();

            while (true)
            {
                var currentTime = (float)(DateTime.Now - startDate).TotalSeconds;
                deltaTime = currentTime - lastFrameTime;
                lastFrameTime = currentTime;

                //InputDetection();
                Update();
                Render();

            }
        }

        private static void Initialization()
        {
            startDate = DateTime.Now;
            Engine.Initialize("ElCabron", 800, 675);
            GameManager.Instance.Initialization();
        }

        //private static void InputDetection()
        //{

        //}

        private static void Update()
        {
            GameManager.Instance.Update();
        }

        private static void Render()
        {
            Engine.Clear();
            Engine.Draw("Png/Background/Fondo.jpeg");
            GameManager.Instance.Render();
            Engine.Show();
        }
    }
}