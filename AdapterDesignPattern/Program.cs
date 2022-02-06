using System;

namespace AdapterDesignPattern
{
    class Program
    {
        /*
        -- Changes the interface of one or more classes. --
        Adapter design pattern ==> Aşağıdaki örnekten de görüleceği üzere; DbError ve ServiceError classları, ortak bir yapıya
        sahip  olarak IError interface'ni implemente ediyor. Fax class'ı ise daha farklı bir yapıya sahip. Ancak fax sınıfıda 
        IError yapısını dahil edilmek isteniyor. Bu durumda kullanılan design pattern'dir.

        FaxAdapter diye bir sınıf yaratılır ve bu sınıf IError interface'sini implemente eder. Ayrıca içerisinde Fax sınıfının
        bir örneği kullanılır. Böylece Fax sınıfı IError yapısına ADAPTE edilir. Main kısmında bu class'a Fax class'ının bir örneği
        gönderilir.

         */


        static void Main(string[] args)
        {
            Fax fax = new Fax
            {
                FaxErrorCode = 4000,
                ErrorDescription = "Cevap gelmiyor"
            };

            IError[] errors = {
                      new DbError{ErrorNumber=100,Description="Baglanti saglanamadi" },
                         new DbError{ErrorNumber=101,Description="sorgulama saglanamadi" },
                            new ServiceError{ErrorNumber=300,Description="yetki saglanamadi" },
                               new FaxAdapter(fax)
                            };
            

            foreach (IError error in errors)
                error.SendMail();

            Console.ReadKey();
        }


        interface IError
        {
            int ErrorNumber { get; set; }
            string Description { get; set; }

            void SendMail();
        }

        class DbError : IError
        {
            private int _errorNumber;
            private string _description;

            public int ErrorNumber
            {
                get { return _errorNumber; }
                set { _errorNumber = value; }
            }

            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }

            public void SendMail()
            {
                Console.WriteLine("{0} {1} -> Db Hatası gönderildi", ErrorNumber.ToString(), Description);
            }
        }

        class ServiceError : IError
        {
            private int _errorNumber;
            private string _description;

            public int ErrorNumber
            {
                get { return _errorNumber; }
                set { _errorNumber = value; }
            }

            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }

            public void SendMail()
            {
                Console.WriteLine("{0} {1} -> servis Hatası gönderildi", ErrorNumber.ToString(), Description);
            }
        }

        class Fax
        {
            public int FaxErrorCode { get; set; }
            public string ErrorDescription { get; set; }

            public void Send()
            {

            }

            void Get()
            {

            }
        }

        class FaxAdapter : IError
        {
            private Fax _fax;

            public FaxAdapter(Fax fax)
            {
                _fax = fax;
            }

            public int ErrorNumber
            {
                get { return _fax.FaxErrorCode; }
                set { _fax.FaxErrorCode = value; }
            }

            public string Description
            {
                get { return _fax.ErrorDescription; }
                set { _fax.ErrorDescription = value; }
            }


            public void SendMail()
            {
                Console.WriteLine("{0} {1} -> Fax Hatası gönderildi", ErrorNumber.ToString(), Description);
            }
        }
    }
}
