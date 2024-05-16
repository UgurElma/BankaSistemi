using System;
using System.Collections.Generic;



class BankaHesabi
{
    int hesabNumarasi { get; set; }
    string hesabIsmı { get; set; }
    float hesabBakiye { get; set; }
    public BankaHesabi(int ID, string adi, float bakiye)
    {
        hesabNumarasi = ID;
        hesabIsmı = adi;
        hesabBakiye = bakiye;
        BankaHesaplari.bankaHesabiList.Add(this);
    }

    public void HesapOzeti()
    {
        Console.WriteLine("Hesap Numarası: " + hesabNumarasi + "\nHesap İsmi: " + hesabIsmı + "\nHesap Bakiyesi: " + hesabBakiye + "\nGeri dönmek için klavyeden bir karaktere dokunun!");
        Console.ReadKey();
    }

    public void ParaEklemeIslemi(float miktar)
    {
        if (miktar > 0)
        {
            hesabBakiye += miktar;
            Console.WriteLine("Para başarıyla hesabınıza eklendi.");
        }
        else
            Console.WriteLine("Lütfen, pozitif miktar giriniz");
    }
    public void ParaÇekmeIslemi(float miktar)
    {
        if ((miktar > 0) && (hesabBakiye - miktar >= 0))
        {
            hesabBakiye -= miktar;
            Console.WriteLine("Para başarıyla hesabınıza çekildi.");
        }
        else if (hesabBakiye - miktar < 0)
            Console.WriteLine("Yetersiz bakiye!");
        else
            Console.WriteLine("Lütfen, pozitif miktar giriniz");
    }
    public void ParaTransferi(float miktar, int ID)
    {
        bool varMi = false;
        BankaHesabi arananKan = null;
        for (int i = 0; i < BankaHesaplari.bankaHesabiList.Count; i++)
        {
            if (ID == BankaHesaplari.bankaHesabiList[i].hesabNumarasi)
            {
                varMi = true;
                arananKan = BankaHesaplari.bankaHesabiList[i];
                break;
            }
        }
        if ((miktar > 0) && (hesabBakiye - miktar >= 0) && varMi)
        {
            hesabBakiye -= miktar;
            arananKan.hesabBakiye += miktar;
            Console.WriteLine("Para transferi başarıyla gerçekleşti.");
        }
        else if (!varMi)
        {
            Console.WriteLine("Kullanıcı uyumsuzluğu!");
        }
        else
        {
            Console.WriteLine("Para transferi gerçekleştirilemedi.");
        }
    }
    public void All()
    {
        List<BankaHesabi> bankaHesabis = BankaHesaplari.bankaHesabiList;
        for (int i = 0; i < bankaHesabis.Count; i++)
        {
            Console.Write(bankaHesabis[i].hesabNumarasi + "\n" + bankaHesabis[i].hesabIsmı + "\n" + bankaHesabis[i].hesabBakiye + "\n");
        }
    }
}