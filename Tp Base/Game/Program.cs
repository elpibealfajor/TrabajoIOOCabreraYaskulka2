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

            //GenericExample<int, int> exampleInt = new GenericExample<int,int>(2,2);

            //GenericExample<Player> plaaayer = new GenericExample<Player>(new Player((1,1),1,0,10,0));

        }

        private static void TestGenericMethod<T>(T param)
        {

        }
        private  void TeestGenericMethod<T>(T param)
        {
            //return default(T);
        }
        private static void Update()
        {
            GameManager.Instance.Update();
        }

        private static void Render()
        {
            Engine.Clear();
            Engine.Draw("Png/Background/Fondo.jpeg");
            Engine.Draw("Png/Hud.png",50,0);
            GameManager.Instance.Render();
            Engine.Show();
        }
    }
}