using System;

namespace FacadeDesignPattern
{
    /*
     -- Simplifies the interface of a group of classes. --
     Facade(Dış Görünüş) Design Pattern ==> Bir alt sistemin parçalarını oluşturan classları istemciden soyutlayarak kullanımı daha da kolaylaştırmak 
    için tasarlanmış tasarım kalıbıdır. Karmaşık ve detaylı olan alt sistemi kullanıcılara basit bir arayüz sağlayarak kullandırmak
    amaçlanmaktadır. 
    Aşağıdaki örnekte görüleceği üzere; Banka, Kredi ve MerkezBankasi karmaşık sistemin alt class'ları. Bunları Facade class'ı içinde
    soyutlayarak kullanıcıya tek ve basit bir sınıf olan Facade class'ı sunuluyor.

    ÖNEMLİ ==> 
    1) Alt sistem içerisinde bulunan class'lar birbirinden ve Facade sınıfından bağımsı olmalıdır.
    2) Facade bizim classlarımızı içermek zorundadır ve operasyonu yaparken onlara ait fonksiyonellikleri kullanması gereklidir.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Facade fcd = new Facade();

            fcd.KrediKullan(new Musteri { Ad = "Atakan", MusteriNumarası = 452124, TCNo = "123546" }, 1000);
        }
    }

    class Musteri
    {
        public int MusteriNumarası { get; set; }
        public string TCNo { get; set; }
        public string Ad { get; set; }
    }


    class Banka
    {
        public bool KrediyiKullan(Musteri musteri,decimal talepEdilenMiktar)
        {
            return true;
        }
    }

    class Kredi
    {
        public bool KrediKullanmaDurumu(Musteri musteri)
        {
            return true;
        }
    }

    class MerkezBankasi
    {
        public bool KaraListeKontrol(string TCNo)
        {
            return false;
        }
    }

    class Facade
    {
        private Banka _banka;
        private Kredi _kredi;
        private MerkezBankasi _merkezBankasi;

        public Facade()
        {
            _banka = new Banka();
            _kredi = new Kredi();
            _merkezBankasi = new MerkezBankasi();
        }

        public void KrediKullan(Musteri musteri,decimal talep)
        {
            if (!_merkezBankasi.KaraListeKontrol(musteri.TCNo) && _kredi.KrediKullanmaDurumu(musteri))
            {
                _banka.KrediyiKullan(musteri, talep);
                Console.WriteLine("Kredi kullandırıldı");
                Console.ReadKey();
            }
        }
    }
}
