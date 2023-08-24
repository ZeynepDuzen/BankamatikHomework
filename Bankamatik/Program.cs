using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bakiye = 250;
            string dogruSifre = "ab18";
            int sifreGirisHakki = 0;

            Console.WriteLine("Kartli islem : 1 / kartsiz islem : 2");
            int kartliKartsiz = Convert.ToInt32(Console.ReadLine());

            if (kartliKartsiz == 1)
            {
                while (sifreGirisHakki < 3)
                {
                    Console.WriteLine("Sifre girin : ");
                    string girilenSifre = Console.ReadLine();
                    if (girilenSifre == dogruSifre)
                    {
                        Console.WriteLine("Giris basarili!");
                        break;
                    }
                    else
                    {
                        sifreGirisHakki++;

                        if (sifreGirisHakki == 3)
                        {

                            Console.WriteLine("3 kez yanlis sifre girildi. Hesabiniz bloke oldu.");
                            Console.Read();
                            return;
                        }
                        Console.WriteLine("Yanlis sifre. Kalan hak: " + (3 - sifreGirisHakki));
                    }
                }

                while (true)
                {
                    AnaMenu(bakiye);

                    int islem = Convert.ToInt32(Console.ReadLine());

                    switch (islem)
                    {
                        case 0:
                            Console.WriteLine("Cikis yapiliyor...");
                            return;
                        case 1:
                            // Para çekme işlemi
                            Console.WriteLine("Cekmek istediginiz miktari girin");
                            int cekilecekMiktar = Convert.ToInt32(Console.ReadLine());
                            if (cekilecekMiktar <= bakiye)
                            {
                                bakiye -= cekilecekMiktar;
                                Console.WriteLine("Paraniz hazirlaniyor...");
                            }
                            else
                            {
                                Console.WriteLine("Bakiyeniz yetersiz");
                            }
                            break;
                        case 2:
                            // Para yatırma işlemi
                            Console.WriteLine("Kredi kartina para yatirmak icin : 1  /  Kendi hesabiniza para yatirmak icin : 2");
                            int paraYatirmaTercihi = Convert.ToInt32(Console.ReadLine());
                            if (paraYatirmaTercihi == 1)
                            {
                                Console.WriteLine("En az 12 haneli kart numarasini girin : ");
                                string kartNo = Console.ReadLine();

                                if ((kartNo.Length >= 12))
                                {
                                    Console.WriteLine("Kredi kartiniza yatirmaniz gereken miktar : ");
                                    int krediKartiYatirilacakMiktar = Convert.ToInt32(Console.ReadLine());
                                    if (krediKartiYatirilacakMiktar <= bakiye)
                                    {
                                        bakiye -= krediKartiYatirilacakMiktar;
                                        Console.WriteLine("Kredi kartina para yatirdiktan sonra bakiyeniz: " + bakiye);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kredi kartiniza para yatirmak icin bakiyeniz yetersiz");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Kart numarasi en az 12 haneli olmalidir");
                                }
                            }
                            if (paraYatirmaTercihi == 2)
                            {
                                Console.WriteLine("Hesabiniza yatirmak istediginiz para miktarini girin : ");
                                int hesabaYatirilacakMiktar = Convert.ToInt32(Console.ReadLine());
                                bakiye += hesabaYatirilacakMiktar;
                                Console.WriteLine("Hesabiniza para yatirma isleminden sonra bakiyeniz : " + bakiye);
                            }
                            break;
                        case 3:
                            // Baska hesaba eft - havale
                            Console.WriteLine("Baska hesaba eft icin : 1 / baska hesaba havale icin : 2");
                            int eftHavaleTercih = Convert.ToInt32(Console.ReadLine());
                            if (eftHavaleTercih == 1) // eft tercihi
                            {
                                Console.WriteLine("Eft numarasi girin : ");
                                string eftNo = Console.ReadLine();
                                if (eftNo.StartsWith("TR", StringComparison.OrdinalIgnoreCase) && eftNo.Length == 14 && Regex.IsMatch(eftNo.Substring(2), @"^\d{12}$"))
                                {
                                    Console.WriteLine("Eft icin yatiracaginiz miktari girin : ");
                                    int eftMiktari = Convert.ToInt32(Console.ReadLine());
                                    if (eftMiktari <= bakiye)
                                    {
                                        bakiye -= eftMiktari;
                                        Console.WriteLine("Eft basari ile gerceklesti");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Eft icin bakiyeniz yetersiz");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yanlis veya eksik eft numarasi girdiniz");
                                }
                            }
                            if (eftHavaleTercih == 2) // havale tercihi
                            {
                                Console.WriteLine("Havale numarasi girin : ");
                                string havaleNo = Console.ReadLine();
                                if (havaleNo.Length == 11)
                                {
                                    Console.WriteLine("Havale icin yatiracaginiz miktari girin : ");
                                    int havaleMiktari = Convert.ToInt32(Console.ReadLine());
                                    if (havaleMiktari <= bakiye)
                                    {
                                        bakiye -= havaleMiktari;
                                        Console.WriteLine("Havale islemi basari ile gerceklesti");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Havale icin bakiyeniz yetersiz");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yanlis veya eksik havale numarasi girdiniz");
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Egitim odemeleri sayfasi arizali");
                            break;
                        case 5:
                            //Fatura Odemeleri
                            Console.WriteLine("Fatura Odemeleri : ");
                            Console.WriteLine("Odemek istediginiz fatura turunu secin : ");
                            Console.WriteLine("Elektrik : 1\nTelefon : 2\nInternet : 3\nSu : 4\nOGS : 5  ");
                            int faturaTuru = Convert.ToInt32(Console.ReadLine());
                            if (faturaTuru == 1) // Elektrik faturasi
                            {
                                Console.WriteLine("Elektrik faturanizin tutarini girin :");
                                int faturaTutari = Convert.ToInt32(Console.ReadLine());
                                if (faturaTutari <= bakiye)
                                {
                                    bakiye -= faturaTutari;
                                    Console.WriteLine("Elektrik faturasi odeme isleminiz basari ile gerceklesti");
                                }
                                else
                                {
                                    Console.WriteLine("Elektrik faturasi odemek icin bakiyeniz yeterli degil");
                                }
                            }
                            if (faturaTuru == 2) //Teleon faturasi
                            {
                                Console.WriteLine("Telefon faturanizin tutarini girin : ");
                                int faturaTutari = Convert.ToInt32(Console.ReadLine());
                                if (faturaTutari <= bakiye)
                                {
                                    bakiye -= faturaTutari;
                                    Console.WriteLine("Telefon faturanizi odeme isleminiz basari ile gerceklesti");
                                }
                                else
                                {
                                    Console.WriteLine("Telefon faturanizi odemek icin bakiyeniz yetersiz");
                                }
                            }
                            if (faturaTuru == 3) //Internet faturasi
                            {
                                Console.WriteLine("Internet faturanizin tutarini girin : ");
                                int faturaTutari = Convert.ToInt32(Console.ReadLine());
                                if (faturaTutari <= bakiye)
                                {
                                    bakiye -= faturaTutari;
                                    Console.WriteLine("Internet faturanizi odeme isleminiz basari ile gerceklesti");
                                }
                                else
                                {
                                    Console.WriteLine("Internet faturanizi odemek icin bakiyeniz yetersiz");
                                }
                            }
                            if (faturaTuru == 4) //Su faturasi
                            {
                                Console.WriteLine("Su faturanizin tutarini girin : ");
                                int faturaTutari = Convert.ToInt32(Console.ReadLine());
                                if (faturaTutari <= bakiye)
                                {
                                    bakiye -= faturaTutari;
                                    Console.WriteLine("Su faturanizi odeme isleminiz basari ile gerceklesti");
                                }
                                else
                                {
                                    Console.WriteLine("Su faturanizi odemek icin bakiyeniz yetersiz");
                                }
                            }
                            if (faturaTuru == 5) // Ogs odemesi
                            {
                                Console.WriteLine("Ogs borcunuzun tutarini girin : ");
                                int faturaTutari = Convert.ToInt32(Console.ReadLine());
                                if (faturaTutari <= bakiye)
                                {
                                    bakiye -= faturaTutari;
                                    Console.WriteLine("Ogs odemeniz basari ile gerceklesti");
                                }
                                else
                                {
                                    Console.WriteLine("Ogs odemesi icin bakiyeniz yetersiz");
                                }
                            }
                            break;
                        case 6:
                            Console.WriteLine("Sifre degisikligi icin 1'i tuslayin");
                            int sifreDegisikligi = Convert.ToInt32(Console.ReadLine());
                            if (sifreDegisikligi == 1)
                            {
                                Console.WriteLine("İki kucukharf ve iki sayidan olusan yeni bir sifre girin : ");
                                string yeniSifre = Console.ReadLine();
                                if (yeniSifre.Length == 4 && char.IsLower(yeniSifre[0]) && char.IsLower(yeniSifre[1]) &&
                                    char.IsDigit(yeniSifre[2]) && char.IsDigit(yeniSifre[3]))
                                {
                                    dogruSifre = yeniSifre;
                                    Console.WriteLine("Yeni sifreniz : " + yeniSifre);
                                }
                                else
                                {
                                    Console.WriteLine("Gecersiz sifre formati");
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Gecersiz islem secimi.");
                            break;
                    }
                    Console.WriteLine("Ana menuye donmek icin 9 / Cıkmak icin : 0");
                    int donusSecimi = Convert.ToInt32(Console.ReadLine());

                    if (donusSecimi == 0)
                    {
                        Console.WriteLine("Cikis yapiliyor ...");
                        return;
                    }
                    if (donusSecimi != 9)
                    {
                        Console.WriteLine("Gecersiz secim . Ana menuye yonlendiriliyorsunuz ...");
                    }
                }
            }
            else if (kartliKartsiz == 2)
            {
                // Kartsız işlem senaryosu burada ele alınabilir.
            }
            else
            {
                Console.WriteLine("Gecersiz secim.");
            }

            //Console.Read();
        }

        static void AnaMenu(int bakiye)
        {
            Console.WriteLine("Yapmak istediginiz islemi secin ");
            Console.WriteLine("Para cekme : 1");
            Console.WriteLine("Para yatirma : 2");
            Console.WriteLine("Para transferi : 3");
            Console.WriteLine("Egitim odemeleri : 4");
            Console.WriteLine("Odemeler : 5");
            Console.WriteLine("Bilgi guncelleme : 6");
            Console.WriteLine("Cikis yap : 0");
        }
    }
}
