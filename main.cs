using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ZarOyun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameDice game = new GameDice();
            while (true)
            {
                Console.Write("1-Oyuna Başla    :\n2-Oyun Geçmişi   :\n3-Oyundan Çıkış  :\nİşlem seçiniz ===> ");
                string x = Console.ReadLine();
                if (x == "1")
                {
                    game.PearsonInformation();
                    game.DiceTrades();
                }
                else if (x == "2")
                {
                    int k = 1;
                    foreach (var i in game.datarecord)
                    {
                        Console.WriteLine($"{k}. atış : {i}");
                        k = k + 1;
                    }
                }
                else if (x == "3")
                {
                    game.Clean();
                    break;
                }
                else
                {
                    continue;
                }


            }
        }

        class GameDice
        {
            public int total_roll = 0;
            public int point = 0;
            public List<string> datarecord = new List<string>();

            public void PearsonInformation()
            {
                Console.Write("Adınızı giriniz ==>  ");
                string name = Console.ReadLine();
                name = name.Replace(" ", "");
                Console.Write("Soyadınızı giriniz ==>  ");
                string surname = Console.ReadLine();
                Console.Write("Doğum tarihinizi giriniz (01.01.1010) ==>  ");
                string date = Console.ReadLine();
                int month = Convert.ToInt32(date.Substring(3, 2));
                if (name.Length > surname.Length)
                {
                    point = point + 50;
                }
                else if (name.Length == surname.Length)
                {
                    point = point + 25;
                }
                else if (name.Length < surname.Length)
                {
                    point = point - 25;
                }
                point = month <= 6 ? point + 30 : point - 20;

            }

            public void DiceTrades()
            {
                while (total_roll < 10)
                {
                    int roll = new Random().Next(1, 7);
                    if (roll == 1 || roll == 6)
                    {
                        total_roll = total_roll + 1;
                        if (roll == 1)
                        {
                            datarecord.Add($"Gelen zar değeri {roll} bu yüzden 75 puan kaybettiniz.");
                            point -= 75;
                        }

                        if (roll == 6)
                        {
                            datarecord.Add($"Gelen zar değeri {roll} bu sayede 100 puan kazandınız.");
                            point += 100;
                        }
                    }
                    else
                    {
                        datarecord.Add($"Gelen zar değeri {roll} zar tekrar atılıyor...");
                    }


                }

                if (point < 500)
                {
                    Console.WriteLine($"Toplam puanınız {point}.\n...Oyunu kaybettiniz...");
                }
                else
                {
                    Console.WriteLine($"Toplam puanınız {point}.\n...Oyunu kazandınız...");
                }
            }
            public void Clean()
            {
                total_roll = 0;
                point = 0;
                datarecord.Clear();
            }

        }

    }
}
