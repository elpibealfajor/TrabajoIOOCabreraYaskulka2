using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Collider
    {
        new Transform transform;
        public Collider()
        {

        }
        private bool isAlive;
        private int currentLife;
        private Animation destroyAnimation;
        private Animation damageAnimation;
        private Animation currentAnimation;
        public bool IsBoxColliding(Bullet bullet)
        {
            float distanceX = Math.Abs(transform.Position.X - bullet.Position.X);
            float distanceY = Math.Abs(transform.Position.Y - bullet.Position.Y);

            float WidthDiv2 = bullet.Width / 2 + bullet.Width / 2;
            float HeightDiv2 = bullet.Height / 2 + bullet.Height / 2;

            return distanceX <= WidthDiv2 && distanceY <= HeightDiv2;
        }
        public  void BulletCollision(Bullet bullet)
        {
            currentLife -= bullet.Damage;
            bullet.DestroyBullet();

            if (currentLife <= 0)
            {
                isAlive = false;
                currentAnimation = destroyAnimation;
            }
        }
    }
}
