using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightBehaviour
{
    class BasicAttackBehavior : IAttackBehavior
    {
        public void Attack(Character attacker, Character target)
        {
            target.Lives -= attacker.AttackStrenght * 1;
        }
    }
}
