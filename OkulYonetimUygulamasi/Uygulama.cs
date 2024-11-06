using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasi
{

    internal class Uygulama
    {
        // Okul sınıfı verilerine ulaşabilmek için Okul nesnesi oluşturduk
        Okul Okul = new Okul();
        public void Calistir()
        {
            Menu();
            SahteVeriGir();
            while (true)
            {
                string secim = SecimAl();
                Console.WriteLine();
                switch (secim)
                {


                    case "1":
                        ListeYazdirButunOgrenciler();
                        break;

                    case "2":
                        SubeyeGoreListe();
                        break;

                    case "3":
                        CinsiyeteGoreListele();
                        break;

                    case "4":
                        TariheGoreListele();
                        break;

                    case "5":
                        IllereGOreSirala();
                        break;

                    case "6":
                        OgrenciNotlariGoruntule();
                        break;

                    case "7":
                        OgrencininOkuduguKitaplariGoruntule();
                        break;
                    case "8":
                        EnYuksekNotlu5Ogrenci();
                        break;
                    case "9":
                        EnDusukNotlu5Ogrenci();
                        break;
                    case "10":
                        SubedekiEnBasariliOgrenciListele();
                        break;

                    case "11":
                        SubedekiEnDusukOgrenciListele();
                        break;

                    case "12":
                        NotOrtGor();
                        break;

                    case "13":
                        SubeNotOrtGor();
                        break;

                    case "14":
                        OgrenciSonKitaplariGoruntule();
                        break;

                    case "15":
                        OgrenciEkle();
                        break;

                    case "16":
                        OgrenciGuncelle();
                        break;
                    case "17":
                        OgrenciSil();
                        break;
                    case "18":
                        OgrenciAdresiGir();
                        break;
                    case "19":
                        KitapEkle();
                        break;
                    case "20":
                        NotEkle();
                        break;
                    case "X":
                        // Seçim ekranında X'e basılması durumunda bir işlem yapılmadan tekrar seçim istenmesi adına burası boş bırakılabilir.
                        break;
                    case "ÇIKIŞ":
                        Environment.Exit(0);
                        break;
                    case "LİSTE":
                        Menu();
                        break;

                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        Console.WriteLine();
                        Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                        break;


                }
            }
        }
        public string SecimAl()
        {
            try
            {
                int sayi;
                Console.Write("Yapmak istediginiz islemi seçiniz: ");
                string secim = Console.ReadLine().ToUpper();
                if (int.TryParse(secim, out sayi))
                {
                    return sayi.ToString();
                }
                if (secim.ToUpper() == "LİSTE")
                {
                    return "LİSTE";
                }
                if (secim.ToUpper() == "ÇIKIŞ")
                {
                    return "ÇIKIŞ";
                }

                throw new Exception("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }
            catch (Exception e)
            {

                return e.Message;
            }



        }
        public void Menu()
        {
            Console.WriteLine("------  Okul Yönetim Uygulamasi  -----");
            Console.WriteLine();
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");
            Console.WriteLine();
            Console.WriteLine("çıkış yapmak için \"çıkış\" yazıp \"enter\"a basın.");
            Console.WriteLine();
        }

        public void NotGir()
        {
            try
            {
                Console.WriteLine("20-Not Gir ----------------------------------------------------------");

                Console.Write("Ögrencinin numarasi: ");
                int no = int.Parse(Console.ReadLine());

                // bu namaralı öğrencinin bilgileri bulunup ekrana yazılacak


                Console.Write("Not eklemek istediginiz ders: ");
                string ders = Console.ReadLine();

                Console.Write("Ders eklemek istediginz not adedi: ");
                int adet = int.Parse(Console.ReadLine());


                for (int i = 1; i <= adet; i++)
                {
                    Console.Write(i + ". notu girin : ");
                    int not = int.Parse(Console.ReadLine());
                    Okul.NotEkle(no, ders, not);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void SahteVeriGir()
        {
            // başka öğrenciler de eklenir.
            Okul.OgrenciEkle(1, "Ali", "Yılmaz", new DateTime(1999, 5, 4), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(2, "Ayse", "Yılmaz", new DateTime(2000, 5, 4), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(3, "Veli", "Yılmaz", new DateTime(2001, 5, 4), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(4, "Veysel", "Yılmaz", new DateTime(2002, 5, 4), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(5, "Fatma", "Yılmaz", new DateTime(2003, 5, 4), CINSIYET.Kiz, SUBE.C);
            Okul.OgrenciEkle(6, "Berk", "Yılmaz", new DateTime(2004, 5, 4), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(7, "Murat", "Yılmaz", new DateTime(2005, 5, 4), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(8, "Ahmet", "Yılmaz", new DateTime(2006, 5, 4), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(9, "Reha", "Yılmaz", new DateTime(2007, 5, 4), CINSIYET.Erkek, SUBE.A);

            // ders notu
            Okul.NotEkle(1, "Matematik", 85);
            Okul.NotEkle(2, "Matematik", 60);
            Okul.NotEkle(3, "Matematik", 90);
            Okul.NotEkle(4, "Matematik", 65);
            Okul.NotEkle(5, "Matematik", 50);
            Okul.NotEkle(6, "Matematik", 80);
            Okul.NotEkle(7, "Matematik", 95);
            Okul.NotEkle(8, "Matematik", 100);
            Okul.NotEkle(9, "Matematik", 55);
            Okul.NotEkle(10, "Matematik", 45);

            Okul.NotEkle(1, "Turkce", 75);
            Okul.NotEkle(2, "Turkce", 50);
            Okul.NotEkle(3, "Turkce", 80);
            Okul.NotEkle(4, "Turkce", 55);
            Okul.NotEkle(5, "Turkce", 40);
            Okul.NotEkle(6, "Turkce", 70);
            Okul.NotEkle(7, "Turkce", 85);
            Okul.NotEkle(8, "Turkce", 90);
            Okul.NotEkle(9, "Turkce", 45);
            Okul.NotEkle(10, "Turkce", 35);


            // kitap 

            Okul.KitapEkleme(1, "Sefiller");
            Okul.KitapEkleme(2, "Marti");
            Okul.KitapEkleme(3, "Anna Karanina");
            Okul.KitapEkleme(4, "Mai ve siyah");
            Okul.KitapEkleme(5, "Beyaz Zambaklar Ulkesinde");
            Okul.KitapEkleme(6, "Ucurtma Avcisi");
            Okul.KitapEkleme(7, "Beyaz Geceler");
            Okul.KitapEkleme(8, "Suc ve Ceza");
            Okul.KitapEkleme(9, "Don Kisot");

            // adres

            Okul.AdresEkleme("Samsun", "Ilkadim", "Kisla", 1);
            Okul.AdresEkleme("Balikesir", "Balik", "Misla", 2);
            Okul.AdresEkleme("Mugla", "Ekmek", "Pisla", 3);
            Okul.AdresEkleme("Mersin", "Tasucu", "Tosla", 4);
            Okul.AdresEkleme("Adana", "Koz", "Isle", 5);
            Okul.AdresEkleme("Istanbul", "Avcilar", "Sisle", 6);
            Okul.AdresEkleme("Sinop", "Merkez", "Bisle", 7);
            Okul.AdresEkleme("Canakkale", "Buco", "Asla", 8);
            Okul.AdresEkleme("Bursa", "Gemlik", "Zasla", 9);

        }
        public void ListeYazdirButunOgrenciler()
        {
            Console.WriteLine("1-Bütün Ögrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            Okul.ListeYazdir(Okul.Ogrenciler);
            Console.WriteLine();
            MenuyuTekrarListele();


        }

        public void SubeyeGoreListe()
        {
            Console.WriteLine("2-Subeye Göre Ögrencileri Listele --------------------------------------------");

            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string giris = Console.ReadLine();
                Console.WriteLine();
                if (giris != null)
                {
                    if (giris.ToUpper() == "A" || giris.ToUpper() == "B" || giris.ToUpper() == "C")
                    {
                        List<Ogrenci> subeOgrenciler = Okul.Ogrenciler
                       .Where(o => o.Sube.ToString().ToUpper() == giris.ToUpper())
                       .OrderBy(o => o.Sube)
                       .ToList();
                        Okul.ListeYazdir(subeOgrenciler);
                        Console.WriteLine();
                        MenuyuTekrarListele();

                        break;
                    }
                    else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }
                }
            }




        }
        public void CinsiyeteGoreListele()
        {
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele -----------------------------------------");
            Console.Write("Listelemek istediğiniz cinsiyeti girin (K/E):");
            string giris = Console.ReadLine();
            Console.WriteLine();

            if (giris != null)
            {
                if (giris.ToUpper() == "E")
                {

                    Okul.ListeYazdir(
                    Okul.Ogrenciler
                    .Where(o => o.Cinsiyet.ToString().ToUpper() == "Erkek".ToString().ToUpper())
                    .ToList());
                    Console.WriteLine();
                    MenuyuTekrarListele();
                }
                if (giris.ToUpper() == "K")
                {

                    Okul.ListeYazdir(
                    Okul.Ogrenciler
                    .Where(o => o.Cinsiyet.ToString().ToUpper() == "Kiz".ToString().ToUpper())
                    .ToList());
                    Console.WriteLine();
                    MenuyuTekrarListele();
                }
            }

        }

        public void TariheGoreListele()
        {
            DateTime datetime;
            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");
            while (true)
            {
                Console.Write("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");
                string input = Console.ReadLine();
                Console.WriteLine();
                if (DateTime.TryParse(input, out datetime))
                {
                    Okul.ListeYazdir(Okul.Ogrenciler.Where(o => o.DogumTarihi > datetime).ToList());
                    Console.WriteLine();
                    MenuyuTekrarListele();
                    break;
                }
                else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }
            }
        }



        //

        //

        public void IllereGOreSirala()
        {
            Okul.IllereGoreListeYazdir(Okul.Ogrenciler.OrderBy(o => o.Adresi.Il).ToList(), "5-Illere Göre Ögrencileri");
            Console.WriteLine();
            MenuyuTekrarListele();
        }

        public void OgrenciNotlariGoruntule()
        {
            Console.WriteLine("6-Ögrencinin notlarını görüntüle ---------------------------------------------");


            Okul.OgrencininNotlariniGoruntule(Okul.Ogrenciler.ToList(), OgrenciNoAlmaMetodu());
            Console.WriteLine();
            MenuyuTekrarListele();
            Console.WriteLine();
        }
        public void OgrencininOkuduguKitaplariGoruntule()
        {
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");
            Okul.OgrencininOkuduguKitaplariListele(Okul.Ogrenciler.ToList(), OgrenciNoAlmaMetodu());
            Console.WriteLine();
            MenuyuTekrarListele();
            Console.WriteLine();
        }


        public void EnYuksekNotlu5Ogrenci()
        {
            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");
            Console.WriteLine();
            Okul.ListeYazdir(Okul.Ogrenciler.OrderByDescending(o => o.Ortalama).Take(5).ToList());
            Console.WriteLine();
            MenuyuTekrarListele();
        }
        public void EnDusukNotlu5Ogrenci()
        {
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele ----------------------------------");
            Console.WriteLine();
            Okul.ListeYazdir(Okul.Ogrenciler.OrderBy(o => o.Ortalama).Take(3).ToList());
            Console.WriteLine();
            MenuyuTekrarListele();
        }

        public void SubedekiEnBasariliOgrenciListele()
        {
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");

                string giris = Console.ReadLine().ToUpper();
                Console.WriteLine();
                if (giris != null)
                {
                    if (giris == "A" || giris == "B" || giris == "C")
                    {
                        Okul.ListeYazdir(Okul.Ogrenciler.Where(o => o.Sube.ToString() == giris).OrderByDescending(o => o.Ortalama).Take(5).ToList());
                        Console.WriteLine();
                        MenuyuTekrarListele();
                        break;
                    }
                    else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }
                }
            }

        }
        public void SubedekiEnDusukOgrenciListele()
        {
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele ----------------------------------");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string giris = Console.ReadLine().ToUpper();
                Console.WriteLine();
                if (giris != null)
                {
                    if (giris == "A" || giris == "B" || giris == "C")
                    {
                        Okul.ListeYazdir(Okul.Ogrenciler.Where(o => o.Sube.ToString() == giris).OrderBy(o => o.Ortalama).Take(3).ToList());
                        Console.WriteLine();
                        MenuyuTekrarListele();
                        break;
                    }
                    else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }
                }
            }

        }

        public void NotOrtGor()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");

            Okul.OgrencininNotOrtGoruntule(Okul.Ogrenciler, OgrenciNoAlmaMetodu());
            Console.WriteLine();
            MenuyuTekrarListele();
        }

        public void SubeNotOrtGor()
        {
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör -------------------------------------");

            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string giris = Console.ReadLine().ToUpper();
                Console.WriteLine();
                if (giris != null)
                {
                    if (giris == "A" || giris == "B" || giris == "C")
                    {
                        Okul.SubeninNotOrtGor(Okul.Ogrenciler, giris);
                        Console.WriteLine();
                        MenuyuTekrarListele();

                        break;
                    }
                    else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }
                }
            }

        }
        public void OgrenciSonKitaplariGoruntule()
        {
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele ----------------------------");
            Okul.OgrencininOkuduguSonKitap(Okul.Ogrenciler.ToList(), OgrenciNoAlmaMetodu());
            Console.WriteLine();
            MenuyuTekrarListele();

        }
        public void OgrenciEkle()
        {
            Console.WriteLine("15-Öğrenci Ekle -----------------------------------------------------");
            int no = NoAlma("Ögrencinin numarası: ");
            string isim = IlkHarfBuyut(IsimAlma("Ögrencinin adı: "));
            string soyisim = IlkHarfBuyut(IsimAlma("Ögrencinin soyadı: "));
            DateTime datetime = TarihAlma();
            CINSIYET cinsiyet = CinsiyetAlma();
            SUBE sube = SubeAlma();
            Console.WriteLine();

            Ogrenci ogr = Okul.Ogrenciler.Where(o => o.No == no).FirstOrDefault();
            if (ogr == null)
            {
                Okul.OgrenciEkle(no, isim, soyisim, datetime, cinsiyet, sube);
                Console.WriteLine(no + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
                Console.WriteLine();
                MenuyuTekrarListele();
            }
            else
            {
                int numara = Okul.Ogrenciler.Max(o => o.No);
                Okul.OgrenciEkle((numara + 1), isim, soyisim, datetime, cinsiyet, sube);
                Console.WriteLine((numara + 1) + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
                Console.WriteLine("Sistemde " + no + " numaralı öğrenci olduğu için verdiğiniz öğrenci no " + (numara + 1) + " olarak değiştirildi.");
                Console.WriteLine();
                MenuyuTekrarListele();
            }

        }

        public void OgrenciGuncelle()
        {
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");
            while (true)
            {

                int no = NoAlma("Ögrencinin numarasi: ");
                Ogrenci ogr = Okul.Ogrenciler.Where(o => o.No == no).FirstOrDefault();
                if (ogr == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    continue;
                }
                string isim = IlkHarfBuyut(IsimAlma("Ögrencinin adı: "));
                string soyisim = IlkHarfBuyut(IsimAlma("Ögrencinin soyadı: "));
                DateTime datetime = TarihAlma();
                CINSIYET cinsiyet = CinsiyetAlma();
                SUBE sube = SubeAlma();


                Okul.OgrenciGuncelle(no, isim, soyisim, datetime, cinsiyet, sube);
                Console.WriteLine();
                Console.WriteLine("Ogrenci Güncellendi");
                Console.WriteLine();
                MenuyuTekrarListele();
                break;

            }
        }

        public void OgrenciSil()
        {
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");
            int input = OgrenciNoAlmaMetodu();
            Console.WriteLine();
            Ogrenci o = Okul.Ogrenciler.Where(o => o.No == input).FirstOrDefault();
            Console.WriteLine("Ogrencinin Adi Soyadi: " + o.Ad + " " + o.Soyad);
            Console.WriteLine("Ogrencinin Subesi: " + o.Sube);
            Console.WriteLine();
            Console.Write("Ögrenciyi silmek istediginize emin misiniz (E/H): ");
            string giris = Console.ReadLine().ToUpper();
            if (giris == "E")
            {
                Okul.OgrenciSil(input);
                Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");
                Console.WriteLine();
                MenuyuTekrarListele();
            }
            if (giris == "H")
            {
                Console.WriteLine();
                MenuyuTekrarListele();
                return;
            }
            else
            {
                Console.WriteLine();
                MenuyuTekrarListele(); return;
            }

        }

        public int OgrenciNoAlmaMetodu()
        {
            int sayi;
            while (true)
            {
                Console.Write("Ögrencinin numarasi: ");
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    bool ogrenciVarMi = Okul.Ogrenciler.Any(item => item.No == sayi);
                    if (ogrenciVarMi)
                    {
                        return sayi;
                    }
                    else
                    {
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    }

                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }
            }

        }



        public string IsimAlma(string yazi)
        {
            int sayi;
            do
            {
                try
                {
                    Console.Write(yazi);
                    string giris = Console.ReadLine().ToUpper();

                    if (string.IsNullOrWhiteSpace(giris))
                    {
                        throw new Exception("Veri girişi yapılmadı, tekrar deneyin.");
                    }

                    if (int.TryParse(giris, out sayi))
                    {
                        throw new Exception("Hatalı işlem, tekrar girin.");
                    }
                    else
                    {
                        return giris;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }


        public DateTime TarihAlma()
        {
            while (true)
            {
                DateTime datetime;
                Console.Write("Ögrencinin dogum tarihi: ");
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out datetime))
                {
                    return datetime;
                }
                else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }
            }

        }

        public CINSIYET CinsiyetAlma()
        {
            while (true)
            {
                Console.Write("Ögrencinin cinsiyeti (K/E): ");
                string input = Console.ReadLine().ToUpper();
                if (input != null)
                {
                    if (input == "E")
                    {
                        return CINSIYET.Erkek;
                    }
                    if (input == "K")
                    {
                        return CINSIYET.Kiz;
                    }
                    else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }

                }
            }

        }

        public SUBE SubeAlma()
        {
            while (true)
            {
                Console.Write("Ögrencinin subesi (A/B/C): ");
                string input = Console.ReadLine().ToUpper();
                if (input != null)
                {
                    if (input == "A")
                    {
                        return SUBE.A;
                    }
                    if (input == "B")
                    {
                        return SUBE.B;
                    }
                    if (input == "C")
                    {
                        return SUBE.C;
                    }
                    else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }

                }
            }

        }

        public int NoAlma(string mesaj)
        {
            while (true)
            {
                int sayi;
                Console.Write(mesaj);
                string input = Console.ReadLine();

                if (int.TryParse(input, out sayi))
                {
                    return sayi;
                }
                else { Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); }
            }
        }
        public void KitapEkle()
        {
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");
            int input = OgrenciNoAlmaMetodu();
            Console.WriteLine();

            Ogrenci o = Okul.Ogrenciler.Where(o => o.No == input).FirstOrDefault();

            Console.WriteLine("Ogrencinin Adi Soyadi: " + o.Ad + " " + o.Soyad);
            Console.WriteLine("Ogrencinin Subesi: " + o.Sube);
            Console.WriteLine();

            string giris;
            do
            {
                Console.Write("Eklenecek Kitabin Adı: ");
                giris = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(giris))
                {
                    Console.WriteLine("Veri girişi yapılmadı, tekrar deneyin.");
                }
            } while (string.IsNullOrWhiteSpace(giris));

            Okul.KitapEkle(input, giris);
            Console.WriteLine();
            MenuyuTekrarListele();
            
        }


        public void NotEkle()
        {
            Console.WriteLine("20-Not Gir ----------------------------------------------------------");
            int input = OgrenciNoAlmaMetodu();
            Console.WriteLine();
            Ogrenci o = Okul.Ogrenciler.Where(o => o.No == input).FirstOrDefault();
            Console.WriteLine("Ogrencinin Adi Soyadi: " + o.Ad + " " + o.Soyad);
            Console.WriteLine("Ogrencinin Subesi: " + o.Sube);
            Console.WriteLine();
            
            string giris = IsimAlma("Not eklemek istediğiniz dersi giriniz: ");
            int sayi = NoAlma("Eklemek istediginiz not adedi: ");
            for (int i = 1; i <= sayi; i++)
            {
                Console.Write(i + " notu giriniz: ");
                int not = int.Parse(Console.ReadLine());
                Okul.NotEkle(input, IlkHarfBuyut(giris), not);
            }
            Console.WriteLine();
            Console.WriteLine("Bilgiler sisteme girilmistir.");
            Console.WriteLine();
            MenuyuTekrarListele();
        }
        public string IlkHarfBuyut(string giris)
        {
            return giris.Substring(0, 1).ToUpper() + giris.Substring(1).ToLower();
        }


        public void MenuyuTekrarListele()
        {
            Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            Console.WriteLine();
        }
        public void OgrenciAdresiGir()
        {
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");
            int no = OgrenciNoAlmaMetodu();

            Ogrenci o = Okul.Ogrenciler.Where(o => o.No == no).FirstOrDefault();
            Console.WriteLine();
            Console.WriteLine("Ögrencinin Adı Soyadı: " + o.Ad + " " + o.Soyad);
            Console.WriteLine("Ögrencinin Subesi: " + o.Sube);
            Console.WriteLine();
            while (true)
            {
               
                string il = IsimAlma("Il: ");
                string ilce = IsimAlma("Ilce: ");
                string mahalle = IsimAlma("Mahalle: ");
                Console.WriteLine();
                if (o != null)
                {
                    if (o.Adresi == null)
                    {
                        o.Adresi = new Adres();
                    }
                    o.Adresi.Il = il;
                    o.Adresi.Ilce = ilce;
                    o.Adresi.Mahalle = mahalle;
                    Console.WriteLine();
                    Console.WriteLine("Bilgiler sisteme girilmistir.");
                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                    break;
                }
                else { Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin."); continue; }


            }

        }
    }
} 

