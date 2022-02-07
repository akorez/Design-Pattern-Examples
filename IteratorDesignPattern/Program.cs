using System;

namespace IteratorDesignPattern
{

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
