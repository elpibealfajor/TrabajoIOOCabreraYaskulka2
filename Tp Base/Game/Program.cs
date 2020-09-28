using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        public static float deltaTime;

        static void Main(string[] args)
        {
            Engine.Initialize();

            while(true)
            {
                Engine.Clear();
                Engine.Draw("ship.png");
                Engine.Show();
            }
        }
    }
}