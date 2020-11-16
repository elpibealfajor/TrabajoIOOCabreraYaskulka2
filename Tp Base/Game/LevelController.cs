using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelController //aspectos generales del estado nivel
    {
        public List<MonoBehaviour> monoBehaviours { get; private set; } = new List<MonoBehaviour>();

        public  List<Bullet> Bullets { get; private set; } = new List<Bullet>();  // globals del program
        public  List<Enemy> Enemies { get; private set; } = new List<Enemy>();
        public Player Player { get; private set; }


        public LevelController()
        {
            Initialization();
        }

        public void Initialization()
        {
            Player = new Player("Png/Player/Idle/1.png",new Vector2(50, 400), 0.75f, 1f, 200);

            Random random = new Random();

            CreationOfEnemies();
        }

        public void Update()
        {

            if(Player != null)
            {
                Player.InputDetection();
                Player.Update();
            }





            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullets[i].Update();
            }

            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemies[i].Update();
            }


        }

        public void Render()
        {
            if (Player != null)
            {
                Player.Render();
            }

            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullets[i].Render();
            }

            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemies[i].Render();

            }
        }

        public void CreationOfEnemies()
        {
            float x = 0;
            float y = 150;

            for (int i = 0; i < 3; i++)
            {
                y += 100;
                x = 450;
                for (int k = 0; k < 2; k++)
                {
                    x += 100;
                    Enemy enemies2 = new Enemy("Png/Enemy/Idle/1.png",new Vector2(x, y), 0.75f, 0f, 100f, 100);
                    Enemies.Add(enemies2);

                }

            }
        }
    }
}
