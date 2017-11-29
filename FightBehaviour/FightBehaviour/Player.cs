using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightBehaviour
{
    class Player : Character
    {
        public Player(string name, int strenght, int defense)
        {
            this.Name = name;
            this.AttackStrenght = strenght;
            this.DefenseStrenght = defense;
        }
    }
}
