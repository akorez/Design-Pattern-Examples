using System;

namespace IteratorDesignPattern
{
    /*
    -- Provides a way to traverse a collection of objects without exposing the collection’s implementation -- 

    Iterator Design Pattern

    Aggregate ==> Veri kümesi içerisinde dolaşmak için bir IIterator interface’i tipinden Iterator 
    yaratılmasını zorunlu tutan arayüzdür.
    
    Iterator ==> Veri kümesi içerisinde dolaşmanın tüm şart ve imzasını bu arayüz belirlemektedir. 
    Yani bir enumerator(sayıcı) görevi üstlenmektedir. Uzun lafın kısası, elimizdeki veri kümesi üzerinde 
    döngü esnasında verileri/nesneleri elde edebilmemiz için gerekli işlemleri/kontrolleri/şartları/hususları tanımlar.

    ConcreteAggregate ==> Veri kümesini barındıran nesnedir. Aggregate arayüzünü uygulayarak Iterator nesnesini oluşturur.

    ConcreteIterator ==> Iterator arayüzünü uygulayan ve içerisinde iterasyon metot ve özelliklerini barındıran,
    yukarıda da bahsettiğimiz enumerator görevini üstlenen sınıftır.
     
     */

    interface IAggregate
    {
        IIterator CreateIterator();
    }

    class DateTimeAggregate : IAggregate
    {
        public DateTime startDate;
        public DateTime endDate;
        public IIterator CreateIterator() => new DateTimeIterator(this);
    }

    interface IIterator
    {
        bool HasDate();
        DateTime CurrentDate();
    }

    class DateTimeIterator : IIterator
    {
        DateTimeAggregate aggregate;
        DateTime currentDate;
        public DateTimeIterator(DateTimeAggregate aggregate)
        {
            this.aggregate = aggregate;
            currentDate = aggregate.startDate;
        }

        public DateTime CurrentDate() => currentDate;
        public bool HasDate()
        {
            if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                int dayCount = currentDate.DayOfWeek == DayOfWeek.Saturday ? 1 : 6;
                currentDate = currentDate.AddDays(dayCount);
            }
            else
            {
                int dayCount = (int)currentDate.DayOfWeek;
                currentDate = currentDate.AddDays(6 - dayCount);
                /*6'dan ilgili günün haftalık sayısını çıkarırsak eğer 
                 Cumartesi gününe kalan günü hesaplamış oluruz.
                 Haliyle bu hesabı ilgili tarihe eklersek eğer
                 o haftanın hafta sonuna ulaşmış oluruz.*/
            }
            return currentDate < aggregate.endDate;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            DateTimeAggregate tarih = new DateTimeAggregate();
            tarih.startDate = new DateTime(2022, 01, 01);
            tarih.endDate = DateTime.Now;
            IIterator iterator = tarih.CreateIterator();

            while (iterator.HasDate())
            {
                Console.WriteLine(iterator.CurrentDate().ToShortDateString());
            }

            Console.Read();
        }
    }
}
