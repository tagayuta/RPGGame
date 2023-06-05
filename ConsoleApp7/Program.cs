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
                new Monster("ゴブリン", 30, 10, "正拳突き", 15),
                new Monster("デビル", 25, 6, "ソウルイート", 30),
                new Monster("ゾンビ", 35, 15, "噛みつき", 25),
                new Monster("ドラゴン", 60, 20, "ドラゴンブレス", 35),
                new Monster("魔王", 80, 25, "ギガフレア", 45)
            };

            List<GameChar> human = new List<GameChar>()
            {
                new GameChar("勇者", 80, 7, "エクスカリバァァァー！！！", 30, 6, 80),
                new GameChar("魔剣士", 70, 6, "ファイアソード＆アイスソード", 20, 4, 70),
                new GameChar("魔法使い", 60, 5, "メガフレア", 25, 4, 60)
            };

            string end = "";

            for (int i = 0; i < monster.Length; i++)
            {
                Console.WriteLine(monster[i].Name + "が現れた");
                while (true)
                {
                    Console.WriteLine("自分たちのターン");
                    for(int j = 0; j < human.Count; j++)
                    {
                        if(human[j].HP <= 0)
                        {
                            continue;
                        }
                        human[j].showCount();
                        Console.WriteLine(human[j].Name + "の行動を選択してください");
                        Console.WriteLine("コマンドを選択してください！");
                        Console.WriteLine("A→通常攻撃　B→HP回復　S→スーパーアタック");

                        string command = Console.ReadLine();

                        if (command == "A" || command == "a")
                        {
                            Console.WriteLine(human[j].Name + "の攻撃！");
                            Console.WriteLine(monster[i].Name + "に" + human[j].Attack + "のダメージ");
                            monster[i].HP -= human[j].Attack;
                            if (monster[i].HP <= 0)
                            {
                                monster[i].HP = 0;
                            }
                            Console.WriteLine(monster[i].Name + "のHPは" + monster[i].HP);

                        }
                        else if (command == "B" || command == "b")
                        {
                            human[j].resulection();
                        }
                        else if (command == "S" || command == "s")
                        {
                            if (human[j].Count < human[j].Gage)
                            {
                                Console.WriteLine("攻撃に失敗した、、、");
                                Console.WriteLine("スーパーアタックのゲージが溜まっていません！");
                            }
                            else
                            {
                                Console.WriteLine(human[j].Name + "のスーパーアタック!！！");
                                Console.WriteLine(human[j].SuperAttackName);
                                monster[i].HP -= human[j].SuperAttack;
                                Console.WriteLine(monster[i].Name + "に" + human[j].SuperAttack + "のダメージ");
                                Console.WriteLine(monster[i].Name + "の残りHPは" + monster[i].HP);
                                human[j].Count = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("攻撃に失敗した、、、");
                            Console.WriteLine("正しいコマンドを入力してください！");
                            continue;
                        }

                        //敵が倒れたかの判定
                        if (monster[i].HP <= 0)
                        {
                            Console.WriteLine(monster[i].Name + "を倒した");
                            break;
                        }

                        Console.WriteLine("------------------------------------------");
                    }
                    

                    //敵が倒れたかの判定
                    if (monster[i].HP <= 0)
                    {
                        break;
                    }

                    Random random = new Random();
                    int num = random.Next(1, 5);
                    int hnum = 0;
                    if(human.Count >= 2)
                    {
                        hnum = random.Next(0, human.Count - 1);
                    }
                    

                    if (num < 2)
                    {
                        Console.WriteLine(monster[i].Name + "のスーパーアタック！" + monster[i].SuperAttackName);
                        human[hnum].HP -= monster[i].SuperAttack;
                        Console.WriteLine(human[hnum].Name + "に" + monster[i].SuperAttack + "のダメージ");
                        human[hnum].showHP();
                    }
                    else
                    {
                        Console.WriteLine(monster[i].Name + "の攻撃");
                        human[hnum].HP -= monster[i].Attack;
                        Console.WriteLine(human[hnum].Name + "に" + monster[i].Attack + "のダメージ");
                        human[hnum].showHP();
                    }

                    for (int k = 0; k < human.Count; k++)
                    {
                        if(human[k].HP <= 0)
                        {
                            human.RemoveAt(k);
                       }
                    }

                    if (human.Count == 0)
                    {
                        Console.WriteLine("パーティは全滅した");
                        Console.WriteLine("勇者達は世界を救えなかった");
                        Console.WriteLine("終了しますコマンドの( END )を入力してください");
                        end = Console.ReadLine();
                        Environment.Exit(0x8020);
                    }

                    Console.WriteLine("------------------------------------------");
                }
                

                if (monster[monster.Length - 1].HP <= 0)
                {
                    Console.WriteLine(monster[i].Name + "を倒した");
                    Console.WriteLine("世界に平和が訪れた");
                    Console.WriteLine("終了しますコマンドの( END )を入力してください");
                    end = Console.ReadLine();
                }

                if(end == "END" || end == "end")
                {
                    Environment.Exit(0x8020);
                }

            }
        }
    }
}
