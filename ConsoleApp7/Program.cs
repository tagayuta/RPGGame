using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Monster[] monster = new Monster[]
{
                new Monster("ゴブリン", 20, 5, "正拳突き", 10),
                new Monster("ゾンビ", 30, 7, "噛みつき", 15),
                new Monster("ドラゴン", 45, 10, "炎のブレス", 25),
                new Monster("魔王", 60, 13, "メガフレア", 30)
};

            GameChar human = new GameChar("勇者", 100, 8, "エクスカリバ", 30);
            string end = "";

            for (int i = 0; i < monster.Length; i++)
            {
                Console.WriteLine(monster[i].Name + "が現れた");
                while (true)
                {
                    Console.WriteLine(human.Name + "のターン");
                    Console.WriteLine("コマンドを選択してください！");
                    Console.WriteLine("A→普通の攻撃　B→HP回復　S→必殺技");
                    string command = Console.ReadLine();
                    if (command == "A")
                    {
                        Console.WriteLine(human.Name + "の攻撃！");
                        Console.WriteLine(monster[i].Name + "に" + human.Attack + "のダメージ");
                        monster[i].HP -= human.Attack;
                        if (monster[i].HP <= 0)
                        {
                            monster[i].HP = 0;
                        }
                        Console.WriteLine(monster[i].Name + "のHPは" + monster[i].HP);

                    }
                    else if (command == "B")
                    {
                        human.resulection();
                    }
                    else if (command == "S")
                    {
                        if (human.Count < 5)
                        {
                            Console.WriteLine("必殺技ゲージが溜まっていません！");
                        }
                        else
                        {
                            Console.WriteLine(human.Name + "の必殺技!！！");
                            Console.WriteLine(human.SuperAttackName + "ァァァー！！！");
                            monster[i].HP -= human.SuperAttack;
                            Console.WriteLine(monster[i].Name + "に" + human.SuperAttack + "のダメージ");
                            Console.WriteLine(monster[i].Name + "の残りHPは" + monster[i].HP);
                            human.Count = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("正しいコマンドを入力してください！");
                        continue;
                    }

                    human.showCount();

                    //敵が倒れたかの判定
                    if (monster[i].HP == 0)
                    {
                        Console.WriteLine(monster[i].Name + "を倒した");
                        break;
                    }

                    Random random = new Random();
                    int num = random.Next(1, 5);

                    if (num < 2)
                    {
                        Console.WriteLine(monster[i].Name + "の必殺技！" + monster[i].SuperAttackName);
                        human.HP -= monster[i].SuperAttack;
                        Console.WriteLine(human.Name + "に" + monster[i].SuperAttack + "のダメージ");
                        human.showHP();
                    }
                    else
                    {
                        Console.WriteLine(monster[i].Name + "の攻撃");
                        human.HP -= monster[i].Attack;
                        Console.WriteLine(human.Name + "に" + monster[i].Attack + "のダメージ");
                        human.showHP();
                    }

                    if (human.HP <= 0)
                    {
                        break;
                    }
                }

                if (human.HP <= 0)
                {
                    Console.WriteLine(human.Name + "は倒れた");
                    Console.WriteLine(human.Name + "は世界救えなかった");
                    Console.WriteLine("終了しますコマンドの( E )を押してください");
                    end = Console.ReadLine();
                    
                }

                if (monster[monster.Length - 1].HP < 0)
                {
                    Console.WriteLine(monster[i].Name + "を倒した");
                    Console.WriteLine("世界に平和が訪れた");
                    Console.WriteLine("終了しますコマンドの( E )を押してください");
                    end = Console.ReadLine();
                }

                if(end == "E")
                {
                    Environment.Exit(0x8020);
                }

            }
        }
    }
}
