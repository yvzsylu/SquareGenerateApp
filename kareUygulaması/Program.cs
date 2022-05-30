using System;

namespace kareUygulaması
{
    internal class Program
    {
        // Karakterlerin ard arda yazıldığında (wwwww) görünmemesi için araya boşluk koyarak satır yazan metot ( w w w w w )
        static void SatırYaz(int uzunluk, string karakter)
        {
            for (int i = 0; i < uzunluk; i++)
            {

                if (i == uzunluk - 1)
                {
                    Console.Write($"{karakter}");
                }
                else
                {
                    Console.Write($"{karakter}");
                    Console.Write(" ");
                }
            }
        }


        // Belirtilen toplulukta char değeri arar, true veya false döner.
        static bool topluluktaVarMı(string topluluk, char karakter)
        {
            for (int i = 0; i < topluluk.Length; i++)
            {
                if (topluluk[i] == karakter)
                {
                    return true;
                }
            }
            return false;
        }

        // Rakamlar üzerinde dönerek, true veya false döner.
        static bool rakamMı(char karakter)
        {
            return topluluktaVarMı("0123456789", karakter);
        }

        // Tüm karakterlerde dönüp hepsinin rakam olması durumunu denetler ve buna göre sayı olup olmadığını belirler.
        static bool sayıMı(string bilgi)
        {
            for (int i = 0; i < bilgi.Length; i++)
            {
                if (rakamMı(bilgi[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }


        // Bütün denetimleri yaparak sadece sayı girilmesini sağlayan metot.
        static int sayıAl(string soruMetni)
        {
            string girilen;
            bool deger;
            Console.Write(soruMetni);
            do
            {
                girilen = Console.ReadLine();
                deger = sayıMı(girilen);

                if (!deger || girilen == "")
                {
                    Console.Write("Lütfen Sayısal Değer Giriniz:");
                }
            } while (!deger || girilen == "");

            return Convert.ToInt32(girilen);

        }

        // Sadece parametre olarak belirtilen tamsayı değerlerini alana kadar sorguyu döner.
        static int cevapAl(string soruMetni, int cevapBir, int cevapIki, int cevapUc)
        {
            string girilen;
            bool deger;
            int rakam;
            do
            {
                Console.Write(soruMetni);
                do
                {
                    girilen = Console.ReadLine();
                    deger = sayıMı(girilen);

                    if (!deger || girilen == "")
                    {
                        Console.Write("Lütfen Sayısal Değer Giriniz:");
                    }
                } while (!deger || girilen == "");
                rakam = Convert.ToInt32(girilen);
            } while (rakam != cevapBir && rakam != cevapIki && rakam != cevapUc);
            return rakam;
        }

        static void IcıDoluKare(int uzunluk, string karakter)
        {

            for (int i = 0; i < uzunluk; i++)
            {
                SatırYaz(uzunluk, karakter);
                Console.WriteLine();
            }
        }


        static void IcıBosKare(int uzunluk, string karakter)
        {
            SatırYaz(uzunluk, karakter);
            Console.Write("\n");
            for (int x = 0; x < uzunluk - 2; x++) // -2 değerini vermeliyiz çünkü kare ilk ve son satırı çıkartıp uzunluk kadar satır olmasını sağlamayılız.
            {
                Console.Write($"{karakter}");
                for (int v = 0; v < uzunluk - 2; v++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine($" {karakter}");
            }
            SatırYaz(uzunluk, karakter);

        }
        static void IcıBosKarelerdenKare(int uzunluk, string karakter)
        {
            uzunluk = uzunluk * 4; // Uzunlukla herhangi bi sayıyı çarpıp aşağıdaki if'lerde bu sayının moduna göre
                                   // yazdırırsak sayının değeri kadar uzunlukta ve genişlikte küçü kareler elde olmuş oluruz.
                                   //  (4x4) gibi
            for (int i = 0; i <= uzunluk; i++)
            {
                for (int j = 0; j <= uzunluk; j++)
                {
                    if (i % 4 == 0)
                    {
                        Console.Write($"{karakter} ");
                    }
                    else if (j % 4 == 0)
                    {
                        Console.Write($"{karakter} ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            string yeniden;
            do
            {
                // acilis
                Console.WriteLine("KARE OLUŞTURMA PROGRAMI");
                Console.WriteLine("-----------------------");
                Console.WriteLine();
                Console.WriteLine("     KARELER    ");
                Console.WriteLine("(1)İÇİ DOLU KARE");
                Console.WriteLine("(2)İÇİ BOŞ KARE");
                Console.WriteLine("(3)İÇİ BOŞ KARELERDEN OLUŞAN KARE");
                Console.WriteLine("");

                // soru 1
                int secim = cevapAl("SEÇİM YAPINIZ (1/2/3?): ", 1, 2, 3);
                // soru 2
                int uzunluk = sayıAl("Oluşturmak istediğiniz kare uzunluğunu giriniz: ");
                // soru 3
                Console.Write("Karakter Seçiniz:");
                string karakter = Console.ReadLine();




                // kareler
                switch (secim)
                {
                    case 1:
                        IcıDoluKare(uzunluk, karakter);
                        break;
                    case 2:
                        IcıBosKare(uzunluk, karakter);
                        break;
                    case 3:
                        IcıBosKarelerdenKare(uzunluk, karakter);
                        break;
                }
                Console.WriteLine("\nTekrar denemek için lütfen E' ye çıkmak için herhangi bir tuşa basınız =)");
                yeniden = Console.ReadLine().ToLower();
            } while (yeniden == "e");




        }


    }
}

