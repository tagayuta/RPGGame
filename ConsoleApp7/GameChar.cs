using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class GameChar
    {
        private string name;
        private int hp;
        private int attack;
        private string superAttackName;
        private int superAttack;
        private int count = 0;
        private int gage;
        private int maxHP;

        public GameChar(string name, int hp, int attack, string superAttackName, int superAttack, int gage, int maxHP)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.superAttackName = superAttackName;
            this.superAttack = superAttack;
            this.gage = gage;
            this.maxHP = maxHP;
        }

        public string Name { get { return name; } }
        public int HP { get { return hp; } set { this.hp = value; } }
        public int Attack { get { return this.attack; } }
        public string SuperAttackName { get { return this.superAttackName; } }
        public int SuperAttack { get { return this.superAttack; } }
        public int Count { get { return count; } set { this.count = value; } }
        public int Gage { get { return gage; } set { this.gage = value; } }


        public void showHP()
        {
            if (this.hp <= 0)
            {
                this.hp = 0;
            }

            Console.WriteLine(this.name + "の残りHPは" + this.hp);
        }

        public void resulection()
        {
            Random rand = new Random();
            int num = rand.Next(8, 15);
            this.hp += num;
            if (this.hp > this.maxHP)
            {
                this.hp = this.maxHP;
            }
            Console.WriteLine(this.name + "は回復魔法を使った！");
            Console.WriteLine(this.name + "のHPは" + num + "回復した！　残りHPは" + this.hp);
        }

        public void showCount()
        {
            this.count++;
            if (this.count >= 6)
            {
                this.count = 6;
                Console.WriteLine("ゲージが溜まりました！　必殺技が使用できます！");
            }
            else
            {
                Console.WriteLine("現在の必殺技ゲージは" + this.count);
            }

        }
    }
}
