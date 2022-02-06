using System;
using System.Collections.Generic;

namespace ObserverDesignPattern
{
    /*
     --Allows a group of objects to be notified when some state changes --

     Observer Design Pattern ==> Elimizdeki mevcut nesnenin durumunda herhangi bir değişiklik olduğunda, bu 
    değişiklerden diğer nesneleri haberdar eden bir tasarımdan bahsediyoruz. Dahada net bir şekilde bahsetmek 
    gerekirse, elimizdeki “x” nesnesinin “y” özelliğinde bir güncellenme, değişiklik yahut belirli bir şartın 
    gerçekleşmesi gibi bir durum cereyan ettiğinde bu “x” nesnesini -izleyen- -gözleyen- diğer “z”, “w”, “k” 
    vs. nesnelerine bu yeni durumu bildiren sisteme denir.

    Klasik örneği finans işlemleridir (hissenin değeri değiştiğinde borsacıların haberdar olması)
     */

    //Subject: Takip etmek istediğimiz hisse stoku
    class Stock
    {

        public string Name { get; set; }
        //Değişikliklerden haberdar olacak kitle
        private List<IFinancer> _financiers;

        private decimal _lotValue;

        public decimal LotValue
        {
            get { return _lotValue; }
            set
            {
                _lotValue = value;
                Notify();
            }
        }

        private void Notify()
        {
            foreach (IFinancer financier in _financiers)
            {
                financier.Update(this);
            }
        }

        public Stock()
        {
            _financiers = new List<IFinancer>();
        }

        public void Subscribe(IFinancer financier)
        {
            _financiers.Add(financier);
        }


        public void Unsubscribe(IFinancer financier)
        {
            _financiers.Remove(financier);
        }

    }

    //Observer : Gözlemcilerimiz
    interface IFinancer
    {
        void Update(Stock stock);
    }

    class Financier : IFinancer
    {
        public string Name { get; set; }

        public void Update(Stock stock)
        {
            Console.WriteLine("{0} hissesinin lot değeri {1} olarak güncellendi", stock.Name, stock.LotValue.ToString("C2"));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Stock azonDemir = new Stock { Name = "Azon Demir Kimya", LotValue = 12.3M };

            Financier xYatirim = new Financier { Name = "X Yatırım Şirketi" };

            azonDemir.Subscribe(xYatirim); //xYatirimi güncelleme alabilmesi için abone ettik.

            Financier zBank = new Financier { Name = "z bank Şirketi" };

            azonDemir.Subscribe(zBank); //zBank güncelleme alabilmesi için abone ettik.

            Console.WriteLine("{0} hissesinin güncel lot degeri {1}", azonDemir.Name, azonDemir.LotValue.ToString("C2"));

            azonDemir.LotValue += 1;

            Console.ReadKey();
        }
    }
}
