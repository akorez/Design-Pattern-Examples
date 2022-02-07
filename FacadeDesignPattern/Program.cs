using System;

namespace FacadeDesignPattern
{
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
                Console.WriteLine("Credit has been disbursed");
                Console.ReadKey();
            }
        }
    }
}
