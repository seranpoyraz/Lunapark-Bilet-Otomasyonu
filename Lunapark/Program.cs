using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunapark
{
    class Program
    {
        public enum anaMenu { makineler = 1, bilet,raporlar, cikis };
        public enum makineMenu { makineEkle=1,makineCikar,makineListesi,cikis};
        public enum raporlarMenu { basılanbiletsayisi=1,ziyaretciIst}
        public enum biletMenu { biletBas=1,biletListe,biletAra,cikis}
        public enum ziyaretciIst { yasGrubu=1,cinsiyet,ogrDurum}

        static string lunaparkMakine = @"Makineler.txt";
        static string lunaparkBilet = @"BiletMakine.txt";
        static string lunaparkBiletTum = @"Bilet.txt";

        struct Bilet
        {
            public int biletno;
            public string ad;
            public string soyad;
            public string dogumtarihi;
            public DateTime biletTarihi;
            public int makineUcreti;
            public double indirim;
            public double kdv;
            public double biletUcreti;




            public Bilet (int biletNo,string Ad, string Soyad, string Dogumtarihi, DateTime BiletTarihi, int MakineUcreti,double Indirim, double Kdv,double BiletUcreti)
            {

                biletno = biletNo;
                ad = Ad;
                soyad = Soyad;
                dogumtarihi = Dogumtarihi;
                biletTarihi = BiletTarihi;
                makineUcreti = MakineUcreti;
                indirim = Indirim;
                kdv = Kdv;
                biletUcreti = BiletUcreti;
                

                
            }
        }

        struct Makine
        {
            public int makineNo;
            public string makineAd;
            public int makineAltYas;
            public int makineUstYas;

            public Makine (int MakineNo, string MakineAd, int MakineAltYas, int MakineUstYas)
            {
                makineNo = MakineNo;
                makineAd = MakineAd;
                makineAltYas = MakineAltYas;
                makineUstYas = MakineUstYas;
            }
        }

        static int makineleriOku(Makine [] makine)
        {
            int i = 0;

            if (File.Exists(lunaparkMakine) == true)
            {
                StreamReader dosya = new StreamReader(lunaparkMakine);

                string kayıt = dosya.ReadLine();
                string[] alanlar;

                while (kayıt != null)
                {
                    alanlar = kayıt.Split(';');

                    makine[i].makineNo = Convert.ToInt32(alanlar[0]);
                    makine[i].makineAd = alanlar[1];
                    makine[i].makineAltYas = Convert.ToInt32(alanlar[2]);
                    makine[i].makineUstYas = Convert.ToInt32(alanlar[3]);

                    i++;

                    kayıt = dosya.ReadLine();
                }

                dosya.Close();
            }

            return i;
        }

        static void makineleriKaydet(Makine[] makine, int makinesayisi)
        {
            StreamWriter dosya = new StreamWriter(lunaparkMakine);

            for (int i = 0; i < makinesayisi; i++)
            {

                dosya.WriteLine("{0};{1};{2};{3}",
                makine[i].makineNo,makine[i].makineAd, makine[i].makineAltYas,makine[i].makineUstYas);
            }

            dosya.Flush();
            dosya.Close();
        }

        static void biletMakineKAydet(int biletNo,int secim,int[]MakineSecim)
        {
            StreamWriter dosya = new StreamWriter(lunaparkBilet,true);

            for (int i = 0; i < secim; i++)
            {

                dosya.WriteLine("{0};{1}",
                biletNo, MakineSecim[i]);
            }

            dosya.Flush();
            dosya.Close();
        }

        static int biletMakineOku(int biletNo,int[] MakineSecim)
        {
            int i = 0;

            if (File.Exists(lunaparkBilet) == true)
            {
                StreamReader dosya = new StreamReader(lunaparkBilet);

                string kayıt = dosya.ReadLine();
                string[] alanlar;

                while (kayıt != null)
                {
                    alanlar = kayıt.Split(';');

                    biletNo = Convert.ToInt32(alanlar[0]);
                    MakineSecim[i] = Convert.ToInt32(alanlar[1]);


                    i++;

                    kayıt = dosya.ReadLine();
                }

                dosya.Close();
            }

            return i;
        }

        static void logo()
        {
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=========================================");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("         $ SERPOLIS LUNAPARKI $          ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=========================================");
            Console.ResetColor();
            Console.WriteLine("");

        }

        static anaMenu AnaMenu()
        {

            Console.WriteLine("");
            Console.WriteLine("1-Makineler");
            Console.WriteLine("2-Bilet");
            Console.WriteLine("3-Raporlar");
            Console.WriteLine("4-Çıkış");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Seçiminiz:");
            Console.ResetColor();
            anaMenu secim = (anaMenu) Convert.ToInt32(Console.ReadLine());
            return secim;

        }

        static void ustMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Üst Menüye dönmek için ENTER tuşuna basınız...");
            Console.ResetColor();
            //Console.ReadLine();
        }

        static void yasGrubuKlavuz()
        {
            
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Kullanabilir Yaş Grubu".PadRight(40) + "Yaş Grubu Kodu".PadRight(40));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1-12 yaş grubu için uygun".PadRight(40)+"Y001".PadRight(40));
            Console.WriteLine("6-14 yaş grubu için uygun".PadRight(40) + "Y002".PadRight(40));
            Console.WriteLine("16 yaş ve üstü yaş grubu için uygun".PadRight(40) + "Y003".PadRight(40));
            Console.WriteLine("18 yaş ve üstü yaş grubu için uygun".PadRight(40) + "Y004".PadRight(40));
            Console.WriteLine("Tüm yaş grupları için uygun".PadRight(40) + "Y005".PadRight(40));
            
        }

        static void makineListesi(Makine[] makine, int makinesayisi)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("Makine No".PadRight(20)+"Makine Adı".PadRight(20) + "Yaş Alt Sınırı".PadRight(25)+ "Yaş Üst Sınırı".PadRight(25));
            Console.ResetColor();

            string makineAlt = "";
            string makineUst = "";
            string makineTum = "";

            for (int i=0; i<makinesayisi; i++)
            {

                if (makine[i].makineUstYas == 100 && makine[i].makineAltYas == -1)
                {
                    makineTum = "Tüm yaş grupları için uygundur...";

                    Console.WriteLine(makine[i].makineNo.ToString().PadRight(20) + makine[i].makineAd.PadRight(20) + makineTum.PadRight(30));

                }


                else if (makine[i].makineAltYas == -1)
                {
                        makineAlt = "yok";
                        Console.WriteLine(makine[i].makineNo.ToString().PadRight(20) + makine[i].makineAd.PadRight(20) + makineAlt.ToString().PadRight(25) + makine[i].makineUstYas.ToString().PadRight(25));


                }

                else if (makine[i].makineUstYas == 100)
                {
                        makineUst = "yok";
                        Console.WriteLine(makine[i].makineNo.ToString().PadRight(20) + makine[i].makineAd.PadRight(20) + makine[i].makineAltYas.ToString().PadRight(25) + makineUst.PadRight(25));

                }
                
                else
                {
                    Console.WriteLine(makine[i].makineNo.ToString().PadRight(20) + makine[i].makineAd.PadRight(20) + makine[i].makineAltYas.ToString().PadRight(25) + makine[i].makineUstYas.ToString().PadRight(25));
                }

            }
            
            Console.ReadLine();
            
        }

        static int makineEkle(Makine[]makine,int makinesayisi)
        {

            if (makinesayisi == 0)
            {
                makine[makinesayisi].makineNo = 1;
            }
            else
            {
                makine[makinesayisi].makineNo = makine[makinesayisi - 1].makineNo + 1;
            }


            Console.Write("Makine Adı:");
            makine[makinesayisi].makineAd = Console.ReadLine();
            Console.Write("Alt Yaş Sınırı:");
            Console.WriteLine("Alt yaş sınırı istemiyorsanız lütfen '-1' giriniz.");
            makine[makinesayisi].makineAltYas = Convert.ToInt32(Console.ReadLine());
            Console.Write("Üst Yaş Sınırı:");
            Console.WriteLine("Üst yaş sınırı istemiyorsanız lütfen '100' giriniz.");
            makine[makinesayisi].makineUstYas = Convert.ToInt32(Console.ReadLine());

            return makinesayisi+1;
        }

        static int makineAra(Makine[]makine,int makinesayisi, string aramametni)
        {
            int i = 0;
            int sonuc = -1;
            for (i = 0; i <= makinesayisi; i++)
            {
                if (aramametni == makine[i].makineAd.ToLower())
                {
                    sonuc = i;
                    break;

                }

            }

            return sonuc;
        }

        static int makineArav2(Makine[] makine, int makinesayisi, int j)
        {
            int i = 0;
            int sonuc = -1;
            for (i = 0; i <= makinesayisi; i++)
            {
                if (j == makine[i].makineNo)
                {
                    sonuc = i;
                    break;

                }

            }

            return sonuc;
        }

        static bool EminMisiniz(string cevap)
        {
            bool sonuc = true;


            if (cevap == "e" || cevap == "E")
            {
                sonuc = true;
            }

            else if (cevap == "h" || cevap == "H")
            {
                sonuc = false;
            }

            else
            {
                Console.WriteLine("Hatalı yanıt");

            }

            return sonuc;
        }

        static int makineCikar(Makine[] makine,int sil,int makinesayisi)
        {
            for (int i = sil; i < makinesayisi; i++)
            {
                makine[i] = makine[i + 1];
            }

            return makinesayisi - 1;

        }

        static int biletleriOku(Bilet[] bilet)
        {
            int i = 0;

            if (File.Exists(lunaparkBiletTum) == true)
            {
                StreamReader dosya = new StreamReader(lunaparkBiletTum);

                string kayıt = dosya.ReadLine();
                string[] alanlar;


                while (kayıt != null)
                {

                    alanlar = kayıt.Split(';');

                    bilet[i].biletno= Convert.ToInt32(alanlar[0]);
                    bilet[i].biletTarihi = Convert.ToDateTime(alanlar[1]);
                    bilet[i].ad = alanlar[2];
                    bilet[i].soyad = alanlar[3];
                    bilet[i].dogumtarihi = alanlar[4];
                    bilet[i].makineUcreti = Convert.ToInt32(alanlar[5]);
                    bilet[i].indirim = Convert.ToDouble(alanlar[6]);
                    bilet[i].kdv = Convert.ToDouble(alanlar[7]);
                    bilet[i].biletUcreti = Convert.ToDouble(alanlar[8]);
                    

                    i++;

                    kayıt = dosya.ReadLine();
                }

                dosya.Close();
            }

            return i;
        }

        static void biletleriKaydet(Bilet[] bilet, int biletsayisi)
        {
            StreamWriter dosya = new StreamWriter(lunaparkBiletTum);


            for (int i = 0; i < biletsayisi; i++)
            {
                Console.WriteLine(bilet[i].biletno);
                Console.ReadKey();
                dosya.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                bilet[i].biletno, bilet[i].biletTarihi,bilet[i].ad,bilet[i].soyad,bilet[i].dogumtarihi,bilet[i].makineUcreti,bilet[i].indirim,bilet[i].kdv,bilet[i].biletUcreti);
            }


            dosya.Flush();
            dosya.Close();
        }

        static int dogumtarih2yas(Bilet[] bilet, int biletsayisi)
        {
            int yas, yil;
            DateTime bugun = DateTime.Today;

            yil = Convert.ToInt32(bilet[biletsayisi].dogumtarihi.Substring(6, 4));
            yas = bugun.Year - yil;

            return yas;
        }

        static int biletBas(Bilet[]bilet, int[] MakineSecim, Makine[] makine,int biletsayisi,int makinesayisi)
        {

            if (biletsayisi == 0)
            {
                bilet[biletsayisi].biletno = 1;
            }
            else
            {
                bilet[biletsayisi].biletno = bilet[biletsayisi - 1].biletno + 1;
            }

            string makineAlt = "";
            string makineUst = "";

            DateTime date = DateTime.Now;
            
            Console.WriteLine("Bilet Tarihi:" + date.ToString("d"));
            bilet[biletsayisi].biletTarihi = date;
            Console.WriteLine("Bilet Numarası:" + bilet[biletsayisi].biletno);
            Console.Write("Ad:");
            bilet[biletsayisi].ad = Console.ReadLine();
            Console.Write("Soyad:");
            bilet[biletsayisi].soyad = Console.ReadLine();
            Console.Write("Doğum Tarihi:");
            bilet[biletsayisi].dogumtarihi = Console.ReadLine();
            int yas = dogumtarih2yas(bilet, biletsayisi);
            Console.Clear();
            Console.WriteLine("Yaş:" + yas);
            Console.WriteLine("Seçilebilecek makineler:");
            Console.WriteLine("");
            Console.WriteLine("Makine No".PadRight(20) + "Makine Adı".PadRight(20) + "Yaş Alt Sınırı".PadRight(25) + "Yaş Üst Sınırı".PadRight(25));
            for (int i = 0; i < makinesayisi; i++)
            {
                if (makine[i].makineAltYas <= yas && yas<makine[i].makineUstYas)
                {

                    if (makine[i].makineAltYas == -1 && makine[i].makineUstYas == 100)
                    {
                        makineAlt = "yok";
                        makineUst = "yok";
                    }

                    else if (makine[i].makineAltYas == -1)
                    {
                        makineAlt = "yok";
                        makineUst = makine[i].makineUstYas.ToString();
                    }

                    else if (makine[i].makineUstYas == 100)
                    {
                        makineUst = "yok";
                        makineAlt = makine[i].makineAltYas.ToString();
                    }

                    else
                    {
                        makineAlt = makine[i].makineAltYas.ToString();
                        makineUst = makine[i].makineUstYas.ToString();
                    }


                        Console.WriteLine(makine[i].makineNo.ToString().PadRight(20) + makine[i].makineAd.PadRight(20) + makineAlt.PadRight(25) + makineUst.PadRight(25));
                }

            }
            
            int secim = makineSecenek(MakineSecim);
            int makineucreti = (secim * 8);

            bilet[biletsayisi].makineUcreti = makineucreti;

            
            bilet[biletsayisi].indirim= biletIndırım(makineucreti);
            bilet[biletsayisi].kdv=((bilet[biletsayisi].makineUcreti-bilet[biletsayisi].indirim)*0.18);
            bilet[biletsayisi].biletUcreti = ((bilet[biletsayisi].makineUcreti - bilet[biletsayisi].indirim) + bilet[biletsayisi].kdv);

            biletMakineKAydet(bilet[biletsayisi].biletno, secim, MakineSecim);

            ornekBilet(bilet, biletsayisi, MakineSecim,makine);


            return biletsayisi + 1;
        }

        static double biletIndırım(double makineucreti)
        {
            double indirim=0.0;
            Console.Clear();
            Console.WriteLine("İndirim uygulanacak mı? (e/h)");
            string indcevap = Console.ReadLine().ToLower();
            if (indcevap == "e")
            {
                Console.WriteLine("Hangi indirimin uygulanmasını istiyorsunuz?");
                Console.WriteLine("1-Öğrenci İndirimi (%25)");
                Console.WriteLine("2-Ekstra İndirim   (%15)");
                Console.Write("Seçim:");
                int indsecim = Convert.ToInt32(Console.ReadLine());

                switch (indsecim)
                {
                    case 1:
                        indirim= Math.Round((makineucreti * 0.25),2);
                        break;
                    case 2:

                        indirim = Math.Round((makineucreti * 0.15),2);
                        break;
                }

            }

            else
            {
                indirim = 0;
            }

            return indirim;
        }

        static int makineSecenek(int[] MakineSecim)
        {
           
            char cevap = 'e';

            Console.WriteLine("");

            int i = 0;
            
            do
            {
                Console.Write("Seçmek istediğiniz makinenin numarasını giriniz:");
                MakineSecim[i] = Convert.ToInt32(Console.ReadLine());
                

                Console.WriteLine("Başka makine seçmek istiyor musunuz? (e/h)");
                cevap = Convert.ToChar(Console.ReadLine());

                        i++;
                

            } while (cevap!= 'h');


            

            return i;
        }

        static void biletListesi(Bilet[] bilet,int[] MakineSecim,int biletsayisi)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("Bilet No".PadRight(10)+"Bilet Tarihi".PadRight(15) + "Ad".PadRight(15) + "Soyad".PadRight(15) + "Doğum Tarihi".PadRight(20)+ "Bilet Ücreti".PadRight(10));
            Console.ResetColor();


            for (int i = 0; i < biletsayisi; i++)
            {



                Console.WriteLine(bilet[i].biletno.ToString().PadRight(10)+bilet[i].biletTarihi.ToString("d").PadRight(15) + bilet[i].ad.PadRight(15) + bilet[i].soyad.PadRight(15) + 
                    bilet[i].dogumtarihi.ToString().PadRight(20) + bilet[i].biletUcreti.ToString().PadRight(10));



            }



            ustMenu();
            Console.ReadLine();
        }

        static void ornekBilet(Bilet[] bilet,int biletsayisi,int[] MakineSecim,Makine[] makine)
        {

            int secim = biletMakineOku(bilet[biletsayisi].biletno, MakineSecim);
            int makinesayisi = makineleriOku(makine);

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("┌" + new String('─', 25) + "┐");
            Console.WriteLine("│" + "«•´`•SERPOLIS LUNAPARKI•´`•»" + "│".PadLeft(2));
            Console.WriteLine("├" + new String('─', 25) + "┤");

            Console.WriteLine("│" + bilet[biletsayisi].biletTarihi.ToString("d") + "│".PadLeft(17));
            Console.WriteLine("│" + "│".PadLeft(26));
            Console.WriteLine("│" + bilet[biletsayisi].ad + " " + bilet[biletsayisi].soyad + "│".PadLeft(18));
            Console.WriteLine("│" + "│".PadLeft(26));
            for (int i = bilet[biletsayisi].biletno; i < secim; i++)
            {
                int j = MakineSecim[i];

                int a = makineArav2(makine, makinesayisi, j);

                    Console.WriteLine("│" + makine[a].makineAd);


            }
            
            Console.WriteLine("│" + "│".PadLeft(26));
            Console.WriteLine("│" + "Makine Ücreti: " + bilet[biletsayisi].makineUcreti.ToString().PadLeft(6) + " TL" + "│".PadLeft(2));
            Console.WriteLine("│" + "İndirim: " + bilet[biletsayisi].indirim.ToString().PadLeft(12) + " TL" + "│".PadLeft(2));
            Console.WriteLine("│" + "KDV %18: " + (bilet[biletsayisi].kdv.ToString().PadLeft(12) + " TL") + "│".PadLeft(2));
            Console.WriteLine("│" + "│".PadLeft(26));
            Console.WriteLine("│" + "Toplam Tutar: " + bilet[biletsayisi].biletUcreti.ToString().PadLeft(7) + " TL" + "│".PadLeft(2));
            Console.WriteLine("└" + new String('─', 25) + "┘");
        }

        static void hangiMakineR(Makine[] makine, Bilet[] bilet, int[] MakineSecim, int makinesayisi, int biletsayisi)
        {
            int secim = biletMakineOku(bilet[biletsayisi].biletno, MakineSecim);
            int noMakAdet = 0;


            Console.WriteLine("Hangi makine için kaç edet bilet kesildiğini öğrenmek için lütfen makine numarasını giriniz...");
            int no = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < secim; i++)
            {
                if (no == MakineSecim[i])
                {
                    noMakAdet++;
                    Console.WriteLine(noMakAdet + " adet bilet kesilmiştir.");
                }

                else if (no != MakineSecim[i])
                {
                    Console.WriteLine("Girmiş olduğunuz makine için henüz bilet kesilmemiştir.");
                }



            }


            Console.ReadLine();
        }



        static int biletAra(Bilet[] bilet,int biletsayisi,string bAramametni)
        {
            int i = 0;
            int sonuc = -1;
            for (i = 0; i <= biletsayisi; i++)
            {
                if (bAramametni == bilet[i].biletno.ToString())
                {
                    sonuc = i;
                    break;

                }

            }

            return sonuc;
        }

        static void Main(string[] args)
        {

            Makine[] makine = new Makine[1000];
            Bilet[] bilet = new Bilet[1000];
            Bilet[] biletMakine = new Bilet[1000];
            int[] MakineSecim = new int[15];

            int makinesayisi = makineleriOku(makine);
            int biletsayisi = biletleriOku(bilet);
            
            anaMenu AnaMenuSecim;

            do
            {       
                Console.Clear();
                logo();
                AnaMenuSecim = AnaMenu();

                if (AnaMenuSecim == anaMenu.makineler)
                {
                    makineMenu makineSecim;

                    do
                    {
                        Console.Clear();
                        logo();
                        Console.WriteLine("1-Makine Ekle");
                        Console.WriteLine("2-Makine Çıkar");
                        Console.WriteLine("3-Makine Listesi");
                        Console.WriteLine("4-Üst Menü");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("Seçiminiz:");
                        Console.ResetColor();
                        makineSecim = (makineMenu)Convert.ToInt32(Console.ReadLine());
                        switch (makineSecim)
                        {
                            case makineMenu.makineEkle:
                               
                                makinesayisi = makineEkle(makine, makinesayisi);
                                makineleriKaydet(makine, makinesayisi);

                                break;
                            case makineMenu.makineCikar:

                                Console.Write("Listeden çıkarmak istediğiniz makinenin adını giriniz:");

                                string aramaMetni = Console.ReadLine();
                                int sil = makineAra(makine, makinesayisi, aramaMetni);
                                Console.WriteLine("");
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("Listeden çıkarmak istediğiniz makine: {0} dir.Emin misiniz? (e/h)",makine[sil].makineAd);
                                Console.ResetColor();
                                Console.WriteLine("");
                                string cevap = Console.ReadLine();

                                bool eminlik = EminMisiniz(cevap);

                                if (eminlik == true)
                                {

                                    makinesayisi = makineCikar(makine, sil, makinesayisi);
                                    makineleriKaydet(makine, makinesayisi);

                                    Console.WriteLine("Makine başarıyla çıkartıldı...");
                                }

                                else
                                {
                                    makineSecim = (makineMenu) ConsoleKey.Enter;   
                                }


                                break;
                            case makineMenu.makineListesi:
                                makineListesi(makine, makinesayisi);
                                ustMenu();

                                break;

                        }

                    } while (makineSecim!=makineMenu.cikis);



                }

                else if (AnaMenuSecim == anaMenu.bilet)
                {
                    biletMenu biletSecim;

                    do
                    {
                        Console.Clear();
                        logo();
                        Console.WriteLine("1-Bilet Bas");
                        Console.WriteLine("2-Bilet Listesi");
                        Console.WriteLine("3-Bilet Ara");
                        Console.Write("Seçim:");
                        biletSecim = (biletMenu)Convert.ToInt32(Console.ReadLine());

                        switch (biletSecim)
                        {
                            case biletMenu.biletBas:
                                Console.Clear();
                                logo();
                                Console.WriteLine("Şuana kadar basılan bilet sayısı"+biletsayisi);
                                biletsayisi=biletBas(bilet,MakineSecim,makine,biletsayisi,makinesayisi);
                                
                                Console.WriteLine("");
                                Console.WriteLine("Bilet yukarıdaki gibi oluşturulacaktır. Bilet basılmasını istiyor musunuz? (e/h)");
                                string yanit = Console.ReadLine().ToLower();

                                if (yanit == "e")
                                {
                                    biletListesi(bilet, MakineSecim, biletsayisi);
                                    Console.ReadKey();
                                    biletleriKaydet(bilet,biletsayisi);
                                    Console.Clear();
                                    Console.WriteLine("Bilet başarıyla basıldı (kaydedildi)...");
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Bilet basım işleminden vazgeçildi...");
                                }

                                ustMenu();      

                                break;
                            case biletMenu.biletListe:

                                biletListesi(bilet, MakineSecim, biletsayisi);

                                break;
                            case biletMenu.biletAra:

                                Console.Clear();
                                logo();
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Bilgilerine erişmek istediğiniz biletin numarasını giriniz:");
                                Console.ResetColor();
                                string bAramametni = Console.ReadLine().Trim();

                                int arananbilet=biletAra(bilet, biletsayisi, bAramametni);
                                ornekBilet(bilet, arananbilet, MakineSecim, makine);
                                ustMenu();
                                Console.ReadLine();

                                break;
                        }



                    } while (biletSecim!=biletMenu.cikis);
                }

                else if (AnaMenuSecim == anaMenu.raporlar)
                {
                    makineListesi(makine, makinesayisi);
                    hangiMakineR(makine, bilet, MakineSecim, makinesayisi, biletsayisi);

                }

                else
                {

                }

            } while (AnaMenuSecim != anaMenu.cikis);




            

            Console.ReadLine();
        }
    }
}
