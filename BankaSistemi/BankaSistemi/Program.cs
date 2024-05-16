using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        BankaHesabi bankaHesabi = new BankaHesabi(1111, "ADMİN", 0);
        BankaHesabi yeniBankaHesabi = new BankaHesabi(0, null, 0);
        Console.WriteLine("-------------- BANKA UYGULAMASINA HOŞ GELDİNİZ ----------------");
        while (true)
        {
            Console.WriteLine("Giriş yapabilmek için hesap numaranızı ve adınızı girmelisiniz!");
            try
            {
                Console.WriteLine("Hesap Numarası ve Hesap Adınız:");
                yeniBankaHesabi = new BankaHesabi(int.Parse(Console.ReadLine()), Console.ReadLine(), 0);
                break;
            }
            catch { Console.WriteLine("Lütfen, sadece sayi giriniz"); continue; }
        }
        BankaHesaplari.bankaHesabiList.Remove(BankaHesaplari.bankaHesabiList[1]);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Para Ekleme ---> +      Para Çekme ---> -      Para Transferi ---> =      Hesap Özeti ---> ?      Tüm Hesap Özeti ---> *\nYapmak istediğiniz işlemi seçin");
            char islem = Console.ReadKey().KeyChar;
            Console.Clear();
            if (islem == '+')
            {
                while (true)
                {
                    Console.WriteLine(">>> Para Ekleme İşlemi <<<\n----------------------------");
                    Console.Write("Yüklenecek miktarı giriniz: ");
                    try
                    {
                        yeniBankaHesabi.ParaEklemeIslemi(float.Parse(Console.ReadLine()));
                        Console.WriteLine("Geri dönmek için klavyeden bir karaktere dokunun!");
                        Console.ReadKey();
                        break;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); Console.ReadKey(); Console.Clear(); }
                }
            }
            else if (islem == '-')
            {
                while (true)
                {
                    Console.WriteLine(">>> Para Çekme İşlemi <<<\n----------------------------");
                    Console.Write("Çekilecek miktarı giriniz: ");
                    try
                    {
                        yeniBankaHesabi.ParaÇekmeIslemi(float.Parse(Console.ReadLine()));
                        Console.WriteLine("Geri dönmek için klavyeden bir karaktere dokunun!");
                        Console.ReadKey();
                        break;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); Console.ReadKey(); Console.Clear(); }
                }
            }
            else if (islem == '=')
            {
                while (true)
                {
                    Console.WriteLine(">>> Para Transfer İşlemi <<<\n----------------------------");
                    Console.WriteLine("Transfer edilecek miktarı ve Transfer edilecek hesap numarasını giriniz: ");
                    try
                    {
                        yeniBankaHesabi.ParaTransferi(float.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                        Console.WriteLine("Geri dönmek için klavyeden bir karaktere dokunun!");
                        Console.ReadKey();
                        break;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); Console.ReadKey(); Console.Clear(); }
                    break;
                }
            }
            else if (islem == '?')
            {
                Console.WriteLine(">>> Hesap Özeti İşlemi <<<\n----------------------------");
                yeniBankaHesabi.HesapOzeti();
            }
            else if (islem == '*')
            {
                Console.WriteLine(">>> Tüm Hesap Özeti <<<\n----------------------------");
                yeniBankaHesabi.All();
                Console.WriteLine("Geri dönmek için klavyeden bir karaktere dokunun!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Program kapatılacak emin misiniz? Hayır --> 0  Evet --> 'Herhangi bir tuşa basınız'");
                if (Console.ReadKey().KeyChar != '0')
                    break;
            }
        }
    }
}
class BankaHesaplari
{
    public static List<BankaHesabi> bankaHesabiList { get; set; } = new List<BankaHesabi>();

    public BankaHesaplari() { }
}
