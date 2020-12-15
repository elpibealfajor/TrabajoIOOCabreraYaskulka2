using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IEnemy
    {
        bool CanAttack { get; }
        float Damage { get;  }
        void Attack();
        float GetTotalDamage();
    }
}
