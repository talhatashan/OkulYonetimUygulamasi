using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasi
{
    internal class Okul
    {
        // Okula ait herhangi bir bilginin değiştirilme işlemleri bu sınıfta yapıalcak


        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {

            Ogrenci o = new Ogrenci(no, ad, soyad, dogumTarihi, cinsiyet, sube);   //Kurucu metoddan gelen veri         
            this.Ogrenciler.Add(o);
        }

        public void OgrenciGuncelle(int no, string ad, string soyad, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {
            Ogrenci o=Ogrenciler.Where(o => o.No == no).FirstOrDefault();

            if (o != null) {
                o.No = no;
                o.Ad = ad;
                o.Soyad = soyad;
                o.DogumTarihi = dogumTarihi;
                o.Cinsiyet = cinsiyet;
                o.Sube = sube;
            }
        }
        public void OgrenciSil(int no)
        {
            Ogrenci o = Ogrenciler.Where(o => o.No == no).FirstOrDefault();
            

            if (o != null)
            {
                Ogrenciler.Remove(o);
            }
        }

        public void KitapEkle(int no, string kitapAdi)
        {
            Ogrenci o = Ogrenciler.Where(o => o.No == no).FirstOrDefault();
            if (o != null)
            {
               o.Kitaplar.Add(kitapAdi);
                Console.WriteLine("Bilgiler sisteme girilmistir.");
                Console.WriteLine();
            }
        }


        public void NotEkle(int no, string ders, int not)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.Notlar.Add(new DersNotu(ders, not));
            }

        }

        

        public void ListeYazdir(List<Ogrenci> liste)
        {


            
            Console.WriteLine("Sube      No        Adı Soyadı               Not Ort.       Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();

            foreach (Ogrenci o in liste)
            {
                string adiSoyadi = o.Ad + " " + o.Soyad;
                Console.WriteLine(o.Sube.ToString().PadRight(10) + o.No.ToString().PadRight(10) + adiSoyadi.ToString().PadRight(26) + o.Ortalama.ToString().PadRight(14) + o.Kitaplar.Count.ToString().PadRight(12));
            }


        }
        public void AdresEkleme(string il, string ilce, string mahalle, int no )
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                if (o.Adresi == null) {
                    o.Adresi = new Adres();
                }
                
                o.Adresi.Il=il;
                o.Adresi.Ilce=ilce;
                o.Adresi.Mahalle=mahalle;
            }
            

        }


        //public void OgrenciAdresiGir() {
        //    Console.WriteLine();
        //    OgrenciNoAlmaMetodu()
        //    Ogrenci o = Ogrenciler.Where(o => o.No == no).FirstOrDefault();
        //    Console.WriteLine("Ögrencinin Adı Soyadı: " + o.Ad + " " + o.Soyad);
        //    Console.WriteLine("Ögrencinin Subesi: " + o.Sube);
        //    while (true) {
                
        //            Console.WriteLine();
        //            if (o != null) {
        //                if (o.Adresi == null)
        //                {
        //                    o.Adresi = new Adres(); 
        //                }                        
        //                o.Adresi.Il = il;                
        //                o.Adresi.Ilce = ilce;
        //                o.Adresi.Mahalle = mahalle;
        //                Console.WriteLine();
        //                Console.WriteLine("Bilgiler sisteme girilmistir.");
        //                Console.WriteLine();
        //                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
        //                break;
        //            }
        //            else { Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin."); continue; }
                    
                
        //    }
            
           
            

            //foreach (Ogrenci item in Ogrenciler)
            //{
            //    if (no==item.No)
            //    {
            //        Console.Write("Il: ");
            //        string il = Console.ReadLine();
            //        item.Adresi.Il = il;
            //        Console.Write("Ilce: ");
            //        string ilce = Console.ReadLine();
            //        item.Adresi.Ilce = ilce;
            //    }
            //}
       // }

        public void KitapEkleme(int no, string kitapAdi)
        {
            Ogrenci o=Ogrenciler.Where(o =>o.No == no).FirstOrDefault();
            if (o != null) { 
           
                o.Kitaplar.Add(kitapAdi);
            }
        }

        public void IllereGoreListeYazdir(List<Ogrenci> liste, string listeAdi)
        {


            Console.WriteLine(listeAdi + " Listele --------------------------------------------------");
            Console.WriteLine("Sube      No        Adı Soyadı               Sehir       Semt");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();

            foreach (Ogrenci o in liste)
            {
                string adiSoyadi = o.Ad + " " + o.Soyad;
                Console.WriteLine(o.Sube.ToString().PadRight(10) + o.No.ToString().PadRight(10) + adiSoyadi.ToString().PadRight(26) + o.Adresi.Il.ToString().PadRight(14) + o.Adresi.Ilce.ToString().PadRight(12));
                
            }
        }

        public void OgrencininNotlariniGoruntule(List<Ogrenci> liste, int no)
        {                        
            Ogrenci ogrenci = liste.Where(o => o.No == no).FirstOrDefault();
            if (ogrenci != null)
            {
                Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);                             
                Console.WriteLine("Ögrencinin Subesi: " + ogrenci.Sube);
                Console.WriteLine();
                if (ogrenci.Notlar != null && ogrenci.Notlar.Any())
                {
                    Console.WriteLine("Dersin Adi".PadRight(15) + "Notu");
                    Console.WriteLine("--------------------");                    
                    foreach (DersNotu ders in ogrenci.Notlar)
                    {                                               
                        Console.WriteLine(ders.DersAdi.PadRight(15) + ders.Not.ToString().PadRight(10));
                    }
                }
            }
            

        }

        public void OgrencininNotOrtGoruntule(List<Ogrenci> liste, int no)
        {
            Ogrenci ogrenci = liste.Where(o => o.No == no).FirstOrDefault();
            if (ogrenci != null)
            {
                Console.WriteLine();
                Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
                Console.WriteLine("Ögrencinin Subesi: " + ogrenci.Sube);
                Console.WriteLine();
                if (ogrenci.Notlar != null )
                {
                    Console.Write("Ögrencinin not ortalaması: " + ogrenci.Ortalama);
                    Console.WriteLine();
                    return;
 
                }
            }


        }


        public void OgrencininOkuduguKitaplariListele(List<Ogrenci> liste, int no)
        {
            
            Ogrenci ogrenci = liste.Where(o => o.No == no).FirstOrDefault();
            if (ogrenci != null)
            {
                Console.WriteLine();
                Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
                Console.WriteLine("Ögrencinin Subesi: " + ogrenci.Sube);
                Console.WriteLine();
                if (ogrenci.Kitaplar != null && ogrenci.Kitaplar.Any())
                {
                    Console.WriteLine("Okudugu Kitaplar");
                    Console.WriteLine("--------------------");
                    foreach (string kitaplar in ogrenci.Kitaplar)
                    {
                        Console.WriteLine(kitaplar);
                    }
                }
            }
        }
        public void OgrencininOkuduguSonKitap(List<Ogrenci> liste, int no)
        {

            Ogrenci ogrenci = liste.Where(o => o.No == no).FirstOrDefault();
            if (ogrenci != null)
            {
                Console.WriteLine();
                Console.WriteLine("Öğrencinin Adı Soyadı: " + ogrenci.Ad + " " + ogrenci.Soyad);
                Console.WriteLine("Ögrencinin Subesi: " + ogrenci.Sube);
                Console.WriteLine();
                if (ogrenci.Kitaplar != null )
                {
                    Console.WriteLine("Ögrencinin Okudugu Son Kitap");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine(ogrenci.Kitaplar[ogrenci.Kitaplar.Count-1]);
                }
            }
        }

        public void SubeninNotOrtGor(List<Ogrenci> liste , string sube)
        {
            double ortalama = Ogrenciler.Where(o => o.Sube.ToString().ToUpper() == sube.ToUpper()).Average(o => o.Ortalama);
            Console.WriteLine(sube + " Subesinin not ortalamasi: " + ortalama);
        }
       

        

    }
}
