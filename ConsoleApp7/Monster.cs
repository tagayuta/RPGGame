using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Monster
    {
        private string name;
        private int hp;
        private int attack;
        private string superAttackName;
        private int superAttack;

        public Monster(string name, int hp, int attack, string superAttackName, int superAttack)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.superAttackName = superAttackName;
            this.superAttack = superAttack;
        }

        public string Name { get { return this.name; } }
        public int HP { get { return this.hp; } set { this.hp = value; } }
        public int Attack { get { return this.attack; } set { this.attack = value; } }
        public string SuperAttackName { get { return this.superAttackName; } }
        public int SuperAttack { get { return this.superAttack; } }
    }
}
