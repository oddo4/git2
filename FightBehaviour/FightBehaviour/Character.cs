using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightBehaviour
{
    class Character
    {
        public int Lives = 100;
        public string Name;
        private IAttackBehavior _attackBehavior = new BasicAttackBehavior();
        private int _attackStrenght;
        private int _defenseStrenght;

        public IAttackBehavior AttackBehavior
        {
            get { return _attackBehavior; }
            set { _attackBehavior = value; }
        }
        public int AttackStrenght
        {
            get { return _attackStrenght; }
            set { _attackStrenght = value; }
        }
        public int DefenseStrenght
        {
            get { return _defenseStrenght; }
            set { _defenseStrenght = value; }
        }

        public void Attack(Character attacker, Character target)
        {
            _attackBehavior.Attack(attacker, target);
        }

    }
}
