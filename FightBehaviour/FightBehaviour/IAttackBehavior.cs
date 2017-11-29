using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightBehaviour
{
    interface IAttackBehavior
    {
        void Attack(Character attacker, Character target);
    }
}
