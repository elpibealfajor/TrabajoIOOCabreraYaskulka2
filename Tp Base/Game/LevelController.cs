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

        public List<Enemy> TankyShips { get; private set; } = new List<Enemy>();
        public Player Player { get; private set; }


        public LevelController()
        {
            Initialization();
        }

        public void Initialization()
        {
            Enemy tankyShip = EnemyFactory.GetInstance(EnemyType.TankShip, new Vector2(730, 350));
            TankyShips.Add(tankyShip);
            Player = new Player("Png/Enemy/Idle/1.png",new Vector2(50, 400), 0.75f, 1f, 200);

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
            for (int i = TankyShips.Count - 1; i >= 0; i--)
            {
                TankyShips[i].Update();
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
            for (int i = TankyShips.Count - 1; i >= 0; i--)
            {
                TankyShips[i].Render();
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
                    //Enemy enemies2 = new Enemy("Png/Enemy/Idle/1.png",new Vector2(x, y), 0.75f, 0f, 100f, 100, 0.5f, 0.5f);
                    Enemy enemies2 = EnemyFactory.GetInstance(EnemyType.ShipEnemy, new Vector2(x, y)); // instantiate con factory
                    Enemies.Add(enemies2);

                }

            }
        }
    }
}
