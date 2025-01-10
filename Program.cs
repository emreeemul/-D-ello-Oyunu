using System;
using System.Text;
using System.Collections.Generic;

namespace Duello
{
    public abstract class Silah // Bu sınıf tüm silahlar için temel özellikleri ve davranışları sağlar.
     // Soyutlama (Abstraction): Bu sınıf, tüm silahlar için temel özellikleri ve davranışları sağlar.
    {
        public string Ad { get; private set; } // Silahın adı, yalnızca sınıf içinde ayarlanabilir ve dışarıdan okunabilir. 
        public int Hasar { get; private set; }  // Silahın verdiği hasar miktarı. 
        public int Savunma { get; private set; } // Silahın sağladığı savunma miktarı.

        public Silah(string ad, int hasar, int savunma)  
        {
            Ad = ad;
            Hasar = hasar;
            Savunma = savunma;
        }

       
        ~Silah() 
        {
            Console.WriteLine($"Silah {Ad} yok ediliyor...");
        }

        public abstract void OzelEtki(ref int oyuncuCan, ref int rakipCan);
    }

    public class Balta : Silah 
    
    {
        public Balta() : base("Balta", 150, 0) { } // Balta sınıfı için varsayılan özellikler.
        public override void OzelEtki(ref int oyuncuCan, ref int rakipCan) { }

        ~Balta()
        {
            Console.WriteLine("Balta yok ediliyor...");
        }
    }

    public class IkiliKilic : Silah 
    
    {
        private static Random rastgele = new Random();
        public IkiliKilic() : base("İkili Kılıç", 125, 0) { }     // İkili Kılıç sınıfı için varsayılan özellikler.
        public override void OzelEtki(ref int oyuncuCan, ref int rakipCan)
        {
            if (rastgele.Next(0, 4) == 3)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("İkili Kılıç: Hasardan kaçınıldı!");
                Console.ResetColor();
            }
        }

        ~IkiliKilic()
        {
            Console.WriteLine("İkili Kılıç yok ediliyor...");
        }
    }

    public class TopuzVeKalkan : Silah 
    
    {
        public TopuzVeKalkan() : base("Topuz ve Kalkan", 100, 50) { } // Topuz ve Kalkan sınıfı için varsayılan özellikler.
        public override void OzelEtki(ref int oyuncuCan, ref int rakipCan) { }

        ~TopuzVeKalkan()
        {
            Console.WriteLine("Topuz ve Kalkan yok ediliyor...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            OyunaBasla();
        }

        static void OyunaBasla() // Oyunun başlangıç ekranını ve kullanıcı mod seçimini sağlar.
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n************* DÜELLO *************\n");
            Console.ResetColor();
            Console.WriteLine("Oyuna Başlamak İçin ENTER Tuşuna Basın...");
            Console.ReadLine();

            Console.WriteLine("Lütfen bir kullanıcı adı giriniz:");
            string oyuncuAdi = Console.ReadLine();

            Console.WriteLine("Mod Seçiniz:"); // Oyuncunun oyun modunu seçmesi için ekran çıktısı sağlar.
            Console.WriteLine("1. Normal Mod");
            Console.WriteLine("2. Sonsuzluk Modu");
            Console.WriteLine("3. Co-op Modu");
            Console.Write("Seçiminiz (1-3): ");
            int modSecim = int.Parse(Console.ReadLine());

            if (modSecim == 1)
            {
                NormalMod(oyuncuAdi);
            }
            else if (modSecim == 2)
            {
                SonsuzlukModu(oyuncuAdi);
            }
            else if (modSecim == 3)
            {
                CoOpModu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz seçim. Oyun kapanıyor.");
                Console.ResetColor();
            }
        }

        static void NormalMod(string oyuncuAdi)
        {
            Silah oyuncuSilahi = SilahSec("1. Oyuncu");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Seçtiğiniz Silah: {oyuncuSilahi.Ad}");
            Console.ResetColor();

            Silah rakipSilahi = RastgeleSilahSec();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Rakibinizin Silahı: {rakipSilahi.Ad} (Rastgele seçildi)");
            Console.ResetColor();

            bool oyuncuKazandi = Savas(1000, 1000, oyuncuSilahi, rakipSilahi);

            if (oyuncuKazandi)
                ZaferEkrani(oyuncuAdi);
            else
                YenilgiEkrani();
        }

        static void SonsuzlukModu(string oyuncuAdi)
        {
            int oyuncuCan = 1000;
            int rakipCan = 1000;
            int tur = 1;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Tur {tur}: Rakibin Canı {rakipCan}");
                Console.ResetColor();

                Silah oyuncuSilahi = SilahSec("1. Oyuncu");
                Silah rakipSilahi = RastgeleSilahSec();

                bool oyuncuKazandi = Savas(oyuncuCan, rakipCan, oyuncuSilahi, rakipSilahi);

                if (!oyuncuKazandi)
                {
                    YenilgiEkrani();
                    break;
                }

                tur++;
                rakipCan += 100;
                oyuncuCan = 1000;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bir sonraki rakibe geçiliyor...");
                Console.ResetColor();
            }
        }

        static void CoOpModu()
        {
            Console.WriteLine("Co-op Mod: İki oyuncu birbiriyle dövüşüyor!");

            Silah oyuncu1Silahi = SilahSec("1. Oyuncu");
            Silah oyuncu2Silahi = SilahSec("2. Oyuncu");

            Console.WriteLine("Dövüş başlıyor!");

            int oyuncu1Can = 1000;
            int oyuncu2Can = 1000;

            while (oyuncu1Can > 0 && oyuncu2Can > 0)
            {
                Console.Clear();
                Console.WriteLine("1. Oyuncu hamlesini yapıyor...");
                string oyuncu1Hamle = GizliHamleSec("q", "w", "e", "x");
                if (oyuncu1Hamle == "x")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("1. Oyuncu oyundan çıkmayı seçti. Oyun sona erdi.");
                    return;
                }

                Console.Clear();
                Console.WriteLine("2. Oyuncu hamlesini yapıyor...");
                string oyuncu2Hamle = GizliHamleSec("ı", "o", "p", "x");
                if (oyuncu2Hamle == "x")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("2. Oyuncu oyundan çıkmayı seçti. Oyun sona erdi.");
                    return;
                }

                if (HamleKarsiHamle(oyuncu1Hamle, oyuncu2Hamle))
                {
                    oyuncu2Can -= oyuncu1Silahi.Hasar;
                    Console.WriteLine("1. Oyuncu başarılı bir saldırı yaptı!");
                }
                else if (HamleKarsiHamle(oyuncu2Hamle, oyuncu1Hamle))
                {
                    oyuncu1Can -= oyuncu2Silahi.Hasar;
                    Console.WriteLine("2. Oyuncu başarılı bir saldırı yaptı!");
                }
                else
                {
                    Console.WriteLine("Hamleler eşleşti, hasar verilmedi.");
                }

                Console.WriteLine($"\n1. Oyuncu Canı: {oyuncu1Can} | 2. Oyuncu Canı: {oyuncu2Can}");
                Console.WriteLine("Devam etmek için ENTER tuşuna basın...");
                Console.ReadLine();
            }

            if (oyuncu1Can > 0)
                ZaferEkrani("1. Oyuncu");
            else
                ZaferEkrani("2. Oyuncu");
        }

        static string GizliHamleSec(string option1, string option2, string option3, string exitOption)
        {
            string hamle;
            while (true)
            {
                hamle = Console.ReadLine()?.Trim().ToLower();
                if (hamle == option1 || hamle == option2 || hamle == option3 || hamle == exitOption)
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz hamle! Lütfen geçerli bir tuş girin.");
                Console.ResetColor();
            }
            return hamle;
        }

        static bool HamleKarsiHamle(string hamle1, string hamle2)
        {
            return (hamle1 == "q" && hamle2 == "p") ||
                   (hamle1 == "w" && hamle2 == "ı") ||
                   (hamle1 == "e" && hamle2 == "o");
        }

        static Silah SilahSec(string oyuncu)
        {
            Console.WriteLine($"{oyuncu} için silah seçiniz:");
            Console.WriteLine("1. Balta 🪓");
            Console.WriteLine("2. İkili Kılıç ⚔️");
            Console.WriteLine("3. Topuz ve Kalkan 🛡️");

            string input;
            while (true)
            {
                input = Console.ReadLine()?.Trim();
                if (input == "1" || input == "2" || input == "3")
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz seçim! Lütfen 1, 2 veya 3 tuşlarına basın.");
                Console.ResetColor();
            }

            return input switch
            {
                "1" => new Balta(),
                "2" => new IkiliKilic(),
                "3" => new TopuzVeKalkan(),
                _ => new Balta()
            };
        }

        static Silah RastgeleSilahSec()
        {
            Random rastgele = new Random();
            int secim = rastgele.Next(1, 4);
            return secim switch
            {
                1 => new Balta(),
                2 => new IkiliKilic(),
                3 => new TopuzVeKalkan(),
                _ => new Balta()
            };
        }

        static bool Savas(int oyuncuCan, int rakipCan, Silah oyuncuSilahi, Silah rakipSilahi) // Oyuncu ile rakip arasındaki savaş mekanizmasını tanımlar.
        {
            while (oyuncuCan > 0 && rakipCan > 0)
            {
                Console.WriteLine("Hamlenizi Seçiniz: (q: Yukarı, w: Orta, e: Aşağı, x: Çıkış)");
                string hamle = GizliHamleSec("q", "w", "e", "x");

                if (hamle == "x")
                {
                    Console.WriteLine("Oyundan çıkılıyor...");
                    return false;
                }

                Random rastgele = new Random();
                string[] rakipHamleleri = { "q", "w", "e" };
                string rakipHamle = rakipHamleleri[rastgele.Next(0, 3)];

                Console.WriteLine($"Rakibin Hamlesi: {rakipHamle.ToUpper()}");

                if ((hamle == "q" && rakipHamle == "e") ||
                    (hamle == "w" && rakipHamle == "q") ||
                    (hamle == "e" && rakipHamle == "w"))
                {
                    rakipCan -= oyuncuSilahi.Hasar;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Başarılı bir saldırı yaptınız!");
                }
                else if ((rakipHamle == "q" && hamle == "e") ||
                         (rakipHamle == "w" && hamle == "q") ||
                         (rakipHamle == "e" && hamle == "w"))
                {
                    oyuncuCan -= rakipSilahi.Hasar;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rakip size vurdu!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Hamleler eşleşti, hasar verilmedi.");
                }

                Console.ResetColor();
                Console.WriteLine($"Sizin Canınız: {oyuncuCan} | Rakibin Canı: {rakipCan}");
            }

            return oyuncuCan > 0;
        }

        static void ZaferEkrani(string oyuncuAdi)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("********************************************");
            Console.WriteLine($"          {oyuncuAdi.ToUpper()} ZAFER KAZANDI!          ");
            Console.WriteLine("********************************************");
            Console.WriteLine("🎉 Tebrikler! Rakibinizi mağlup ettiniz! 🎉");
            Console.ResetColor();
        }

        static void YenilgiEkrani()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********************************************");
            Console.WriteLine("              MAALESEF KAYBETTİNİZ!!!!      ");
            Console.WriteLine("********************************************");
            Console.WriteLine("😞 Bir dahaki sefere daha iyi şanslar! 😞");
            Console.ResetColor();
        }
    }
}
