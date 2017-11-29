using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightBehaviour
{
    class Scorpion : Character
    {
        public Scorpion(string name, int strenght, int defense)
        {
            this.Name = name;
            this.AttackStrenght = strenght;
            this.DefenseStrenght = defense;
        }

        public void LivesCheck()
        {
            if (Lives > 25)
            {
                AttackBehavior = new ScorpionAttackBehavior();
            }
        }
    }
}
