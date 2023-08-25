

namespace ATM
{
    abstract class Hesap
    {
        public string HesapNo { get; }
        public string AdSoyad { get; set; }
        public double Bakiye { get; protected set; }

        public Hesap(string hesapNo, double bakiye)
        {
            HesapNo = hesapNo;

            Bakiye = bakiye;
        }

        public virtual void ParaYatir(double miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($" {miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL");
        }

        public abstract void ParaCek(double miktar);
    }

    class BankaHesabi : Hesap
    {
        public BankaHesabi(string hesapNo, string adSoyad, double bakiye) : base(hesapNo, bakiye)
        {
        }

        public override void ParaCek(double miktar)
        {
            if (miktar <= Bakiye)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{AdSoyad} adlı hesaptan {miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hesap hesap = new BankaHesabi("12345", "Furkan Sayıner", 1000);

            Console.WriteLine("ATM ");
            Console.WriteLine("Para Yatırmak için 1'e Basın ");
            Console.WriteLine("Para Çekmek İçin 2'ye Basın");

            int secim = Convert.ToInt32(Console.ReadLine());

            if (secim == 1)
            {
                Console.Write("Yatırmak istediğiniz miktar: ");
                double miktar = Convert.ToDouble(Console.ReadLine());
                hesap.ParaYatir(miktar);
            }
            else if (secim == 2)
            {
                Console.Write("Çekmek istediğiniz miktar: ");
                double miktar = Convert.ToDouble(Console.ReadLine());
                hesap.ParaCek(miktar);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
}

