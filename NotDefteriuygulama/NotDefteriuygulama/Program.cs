using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteriUyg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Not Defteri Uygulamsı");
                Console.WriteLine("1.yeni notu oluştur");
                Console.WriteLine("2.varolan notları görüntüle");
                Console.WriteLine("3.bir notu düzenle");
                Console.WriteLine("4.bir notu sil");
                Console.WriteLine("5.çıkış");
                Console.Write("yapmak istediginz işlemi secin: ");

                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        YeniNotOlustur();
                        break;
                    case 2:
                        NotlariGoruntule();
                        break;
                    case 3:
                        NotuDuzenle();
                        break;
                    case 4:
                        NotuSil();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }

        }

        static void YeniNotOlustur()
        {
            Console.Write("Not Başlıgı: ");
            string Baslik = Console.ReadLine();

            Console.Write("Not İçerigi: ");
            string icerik = Console.ReadLine();
            string dosyaAdi = $"{Baslik}.txt";

            File.WriteAllText(dosyaAdi, icerik);
            Console.WriteLine("Not Oluşturuldu");
        }


        static void NotlariGoruntule()
        {
            string[] dosyalar = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.WriteLine("Henüz hiç not yok.");
                return;
            }

            Console.WriteLine("Varolan Notlar:");
            for (int i = 0; i < dosyalar.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(dosyalar[i])}");
            }

            Console.Write("Görüntülemek istediğiniz notun numarasını girin: ");
            int secim = Convert.ToInt32(Console.ReadLine());
            if (secim < 1 || secim > dosyalar.Length)
            {
                Console.WriteLine("Geçersiz not numarası.");
                return;
            }

            string icerik = File.ReadAllText(dosyalar[secim - 1]);
            Console.WriteLine("Not İçeriği:");
            Console.WriteLine(icerik);
        }

        static void NotuDuzenle()
        {
            string[] dosyalar = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.WriteLine("henüz hiç not yok: ");
                return;
            }

            Console.WriteLine("varolan notlar: ");

            for (int i = 0; i < dosyalar.Length; i++)
            {
                Console.WriteLine($"{i + i}. {Path.GetFileNameWithoutExtension(dosyalar[i])}");
            }

            Console.WriteLine("düzenlemek istediginiz notun numarasının girin: ");
            int secim = Convert.ToInt32(Console.ReadLine());
            if (secim < 1 || secim > dosyalar.Length)
            {
                Console.WriteLine("Gecersiz not numarası");
                return;
            }

            Console.WriteLine("yeni içerik: ");
            string yeniIcerik = Console.ReadLine();
            File.WriteAllText(dosyalar[secim-1], yeniIcerik);
            Console.WriteLine("not füncellendi: ");
        }

        static void NotuSil()
        {
            string[] dosyalar = Directory.GetFiles(Directory.GetCurrentDirectory(),"*.txt");
            if (dosyalar.Length == 0)
            {
                Console.WriteLine("henüz hic not yok:");
                return;
            }

            Console.WriteLine("varolan notlar: ");
            for(int i = 0;i < dosyalar.Length;i++)
            {
                Console.WriteLine($"{i + i}. {Path.GetFileNameWithoutExtension(dosyalar[i])}");
            }

            Console.WriteLine("silmek istediginiz notun numarasını giriniz: ");
            int secim = Convert.ToInt32(Console.ReadLine());
            if (secim < 1 || secim > dosyalar.Length)
            {
                Console.WriteLine("gecersiz not numarası: ");
                return;
            }

            File.Delete(dosyalar[secim-1]);
            Console.WriteLine("not silindi");

        }
    }
}
