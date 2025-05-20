using System;
using System.IO;
using System.Linq;

// BÜŞRA BİLGÜCÜ

namespace ogrenciNotSistemi
{
    internal class Program
    {
        //Dosya atamasi.
        const string filePath = @"C:\Users\halkbank\Desktop\ogrenciNotSistemi\ogrenciBilgileri.txt";

        // Ogrenci bilgileri için dizileri oluşturuyoruz.
        static int[] ogrenciNo = new int[15];
        static string[] ogrenciAd = new string[15];
        static string[] ogrenciSoyad = new string[15];
        static int[] ogrenciYas = new int[15];
        static double[] ogrenciNotOrtalama = new double[15];

        // Eklenen ogrenci sayisini tutmak ve takip etmek icin bir sayac tanimliyoruz.
        static int ogrenciSayisi = 0;

        static void Main(string[] args)
        {
            // Program baslarken ogrencileri dosyadan veri yüklemek icin.
            OgrencileriDosyadanYukle();

            int kullaniciSecim = 0; // Do-While Dongusu disinda kullanici secimi tanimlandi.
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;  //Hosgeldiniz yazisini yesil renkte yazdirmak icin.
                Console.WriteLine("\n**Hosgeldiniz..**");
                Console.ResetColor();    //Renkleri sifirlamak icin.

                //Ogrenci Bilgileri:
                Console.WriteLine("[1] Tum Ogrenciler:");
                Console.WriteLine("[2] Yeni Ogrenci Ekle:");
                Console.WriteLine("[3] Ogrenci Sil:");
                Console.WriteLine("[4] Soyad Bilgisine Gore Ogrenci Ara:");
                Console.WriteLine("[5] Cikis yap ve Kaydet...");

                // Ek olarak 50'nin altinda kalan ogrencileri tespit etmek istiyoruz.
                Console.WriteLine("[6] Ortalama Altinda Kalan Ogrenciler:");

                Console.Write("Seçiminiz Nedir?: "); // Kullanicidan verilen sayilara gore bir secim yapmasini istiyoruz. [1-6 arasinda]

                try    //Hata yapilmasina karsin try-catch kullaniyoruz.
                {
                    kullaniciSecim = int.Parse(Console.ReadLine());

                    switch (kullaniciSecim)
                    {
                        case 1:
                            TumOgrenciler();
                            break;

                        case 2:
                            OgrenciEkle();
                            break;

                        case 3:
                            Console.Write("Lutfen sistemden silmek istediginiz ogrencinin numarasini giriniz : ");
                            int no = int.Parse(Console.ReadLine());
                            OgrenciSil(no);
                            break;

                        case 4:
                            Console.Write("Lutfen soyadina gore arama yapmak istediginiz ogrencinin soyadi bilgisini giriniz : ");
                            string soyad = Console.ReadLine();
                            SoyadinaGoreOgrenciAra(soyad);
                            break;

                        case 5:
                            Console.WriteLine("Cikis yapiliyor... Bilgiler Dosyaya Kaydediliyor...");
                            OgrencileriDosyayaKaydet();
                            break;

                        case 6:
                            ortalamaAltindaKalanOgrenciler();
                            OgrencileriDosyayaKaydet();
                            break;

                        default:

                            Console.WriteLine("Gecersiz bir tuslama yaptiniz! Lutfen [1-6] araliginda bir secim yapiniz.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata Olustu: " + ex.Message);
                }
            } while (kullaniciSecim != 5);
        }

        static void OgrenciEkle()
        {
            if (ogrenciSayisi >= 15)
            {
                Console.WriteLine("Ogrenci eklenemez... Sistem doludur."); //  Eger kullanici 15 ogrenciden fazla sayi girerse sistem kabul etmez.
                return;
            }
            try
            {
                Console.Write("Ogrenci No : ");
                int no = int.Parse(Console.ReadLine());

                if (no < 1000 || no > 9999 || ogrenciNo.Contains(no))
                {
                    Console.WriteLine("Gecersiz numara girdiniz."); // Ogrenci numarasi 4 haneli olmali ve tekrar etmemeli.
                    return;
                }

                Console.Write("Ad: ");
                string ad = Console.ReadLine();

                Console.Write("Soyad: ");
                string soyad = Console.ReadLine();

                Console.Write("Yas: ");
                int yas = int.Parse(Console.ReadLine());

                Console.Write("Not Ortalamasi: ");
                double notOrtalamasi = double.Parse(Console.ReadLine());

                ogrenciNo[ogrenciSayisi] = no;
                ogrenciAd[ogrenciSayisi] = ad;
                ogrenciSoyad[ogrenciSayisi] = soyad;
                ogrenciYas[ogrenciSayisi] = yas;
                ogrenciNotOrtalama[ogrenciSayisi] = notOrtalamasi;
                ogrenciSayisi++;

                Console.WriteLine("Ogrenci basariyla eklendi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata Olustu: " + ex.Message);
            }
        }

        /// <summary>
        /// Tüm öğrencileri listeler
        /// </summary>    
        static void TumOgrenciler()  //Tum ogrencileri listelemek icin metot olusturuldu.
        {
            Console.WriteLine("\n*** TUM OGRENCILER ***");
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"{ogrenciNo[i]} - {ogrenciAd[i]} {ogrenciSoyad[i]} - Yas: {ogrenciYas[i]} - Not Ortalamasi: {ogrenciNotOrtalama[i]}");  //Ogrenci bilgileri yazdiriliyor.
            }
        }

        static void SoyadinaGoreOgrenciAra(string soyad)
        {
            bool bulundu = false; // Ogrenci soyadina gore arandiginda bulundu mu kontrolu icin.
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                if (ogrenciSoyad[i].Equals(soyad, StringComparison.OrdinalIgnoreCase)) //StringComparison.OrdinalIgnoreCase kullanimi soyadi aramasi yaparken buyuk-kucuk harflerin yaziminda sorun olmamasi icin yapildi.
                {
                    Console.WriteLine($"{ogrenciNo[i]} - {ogrenciAd[i]} {ogrenciSoyad[i]} - Yas: {ogrenciYas[i]} - Not Ortalamasi: {ogrenciNotOrtalama[i]}");
                    bulundu = true; //ogrenci bulundu.
                }
            }
            if (!bulundu) Console.WriteLine("Ogrenci Bulunamadi.");
        }

        static void OgrenciSil(int no) //Ogrenci silmek icin metot olusturuldu.

        {
            int index = Array.IndexOf(ogrenciNo, no); // Once ogrenci no ile hangi ogrencinin silinmesi isteniyorsa onu belirtiriz.
            if (index == -1)
            {
                Console.WriteLine("Ogrenci bulunamadi.");
                return;
            }

            for (int i = index; i < ogrenciSayisi - 1; i++) //Ogrenci silindikten sonra dizide bir bosluk olusacagindan dolayi dizide birbirlerinin yerine kaydirma islemi yapilir.
            {
                ogrenciNo[i] = ogrenciNo[i + 1];
                ogrenciAd[i] = ogrenciAd[i + 1];
                ogrenciSoyad[i] = ogrenciSoyad[i + 1];
                ogrenciYas[i] = ogrenciYas[i + 1];
                ogrenciNotOrtalama[i] = ogrenciNotOrtalama[i + 1];
            }

            ogrenciSayisi--;   //ve ogrenci silindigi icin ogrenci sayisi bir tane azaltilir.
            Console.WriteLine("Ogrenci Silindi.");
        }


        static void OgrencileriDosyayaKaydet() //Ogrencileri dosyaya kaydetmek icin metot olusturuldu.
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Dosya dizini yoksa olusmasi icindir.
                using (StreamWriter writer = new StreamWriter(filePath))    // StreamWriter: dosya yazma islemi.
                {
                    for (int i = 0; i < ogrenciSayisi; i++)
                    {
                        writer.WriteLine($"{ogrenciNo[i]}-{ogrenciAd[i]}-{ogrenciSoyad[i]}-{ogrenciYas[i]}-{ogrenciNotOrtalama[i]}");
                    }
                }
                Console.WriteLine("Ogrenciler dosyaya kaydedildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata Olustu..: " + ex.Message);
            }
        }

        static void OgrencileriDosyadanYukle()
        {
            try
            {
                if (!File.Exists(filePath)) // Eger bilgisayarda dosya yoksa yeni bir dosya olusturmak icin.
                {
                    Console.WriteLine("Dosyası bulunamadi...Yeni bir dosya olusturuluyor.");
                    return;
                }

                using (StreamReader reader = new StreamReader(filePath)) // StreamReader: dosya okuma islemi.
                {
                    ogrenciSayisi = 0; // Ogrenci sayisi sifirlandi.
                    string satir;
                    while ((satir = reader.ReadLine()) != null && ogrenciSayisi < 15) // Dosyadan okuma islemi yapilirken ogrenci sayisi 15'ten fazla olmamali.
                    {
                        //Ogrenci bilgilerini parcalara ayirarak yazdiriyoruz.
                        string[] parcalar = satir.Split('-'); //Karakterleri ayiriyoruz.
                        ogrenciNo[ogrenciSayisi] = int.Parse(parcalar[0]);
                        ogrenciAd[ogrenciSayisi] = parcalar[1];
                        ogrenciSoyad[ogrenciSayisi] = parcalar[2];
                        ogrenciYas[ogrenciSayisi] = int.Parse(parcalar[3]);
                        ogrenciNotOrtalama[ogrenciSayisi] = double.Parse(parcalar[4]);
                        ogrenciSayisi++;
                    }
                }
                Console.WriteLine("Dosya Yuklemesi Tamamlandi."); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata Olustu: " + ex.Message);
            }
        }

        static void ortalamaAltindaKalanOgrenciler() //Ortalama altinda kalan ogrencileri belirlemek icin metot olusturuldu.
        {
            const string filePath = @"C:\Users\halkbank\Desktop\ogrenciNotSistemi\ortalamaAltindaKalanOgrenciler.txt";

            Console.ForegroundColor = ConsoleColor.Green;  //Ortalama Altinda Kalan Ogrenciler yazisini yesil renkte yazdirmak icin.
            Console.WriteLine("\n**Ortalama Altinda Kalan Ogrenciler**");
            Console.ResetColor();    //Renkleri sifirlamak icin.

            bool kalanOgrenciVarMi = false;    //Ortalama altinda kalan ogrenci var mi yok mu kontrolu icin.

            using (StreamWriter writer = new StreamWriter(filePath))        //Dosyaya yazdirmak icin StreamWriter kullanildi.
            {
                for (int i = 0; i < ogrenciSayisi; i++)   //Ogrenci sayisi kadar dongu olusturuldu.
                {
                    if (ogrenciNotOrtalama[i] < 50)     //Ogrenci not ortalamasi 50'nin altinda ise ona gore islem uyguluyoruz ve basarisiz oldugunu belirliyoruz.
                    {
                        kalanOgrenciVarMi = true;     //Ortalama altinda kalan ogrenci varsa true dondururuz.
                        string kalanBilgi = ($" Maalesef notunuz ortalamanin altindadir.. {ogrenciNo[i]}-{ogrenciAd[i]} {ogrenciSoyad[i]}- Yas : {ogrenciYas[i]}-Not Ortalamasi : {ogrenciNotOrtalama[i]}"); // Ogrenciye basarisiz oldugu bilgisi verildi.
                        Console.WriteLine(kalanBilgi);
                    }
                }
            }
        }

    }
}

