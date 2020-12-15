using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    
    public enum EnemyType 
    {
        ShipEnemy,
        TankShip,
    }
    public static class EnemyFactory
    {
        public static Enemy GetInstance(EnemyType enemyType, Vector2 position)
        {
            switch (enemyType)
            {
                case EnemyType.ShipEnemy:
                    return new Enemy("Png/Enemy/Idle/1.png", position, 0.75f, 0f, 100f, 100, 0.5f, 0.5f);
                case EnemyType.TankShip:
                    return new Enemy("Png/Enemy/Idle/1.png", position, 1.75f, 0f, 100f, 800, 0.5f, 0.5f);
                default:
                    return new Enemy("Png/Enemy/Idle/1.png", position, 0.75f, 0f, 100f, 100, 0.5f, 0.5f);
            }
        }
    }
}
