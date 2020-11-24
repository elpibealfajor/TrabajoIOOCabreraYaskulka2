using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PoolBullets
    {
        private List<Bullet> inUse = new List<Bullet>();
        private List<Bullet> availables = new List<Bullet>();

        public PoolBullets()
        {

        }

        public Bullet GetBullet()
        {
            Bullet bulletToReturn;

            if(availables.Count > 0)
            {
                bulletToReturn = availables[0];
                availables.RemoveAt(0);
            }
            else
            {
                bulletToReturn = new Bullet(Vector2.Zero, 90f, 1f, 300f, 50);
                bulletToReturn.OnDeactivate += RecycleBullet;
            }
            inUse.Add(bulletToReturn);
            bulletToReturn.ResetValues();
            return bulletToReturn;
        }

        private void RecycleBullet(Bullet bullet)
        {
            if(inUse.Contains(bullet))
            {
                inUse.Remove(bullet);
                availables.Add(bullet);
            }
        }
    }
}
