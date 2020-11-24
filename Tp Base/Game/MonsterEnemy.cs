using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MonsterEnemy : IEnemy
    {
        private float damage;
        private bool canAttack;
        public bool CanAttack => canAttack ;

        public float Damage => damage;

        public MonsterEnemy(float damage, bool canAttack)
        {
            this.damage = damage;
            this.canAttack = canAttack;
        }

        public void Attack()
        {
        }

        public float GetTotalDamage()
        {
            return damage;
        }
    }
}
