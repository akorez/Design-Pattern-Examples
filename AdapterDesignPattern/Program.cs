using System;

namespace AdapterDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Fax fax = new Fax
            {
                FaxErrorCode = 4000,
                ErrorDescription = "Not Responding"
            };

            IError[] errors = {
                      new DbError{ErrorNumber=100,Description="Connection failed!" },
                         new DbError{ErrorNumber=101,Description="Query failed!" },
                            new ServiceError{ErrorNumber=300,Description="Authorization failed!" },
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
                Console.WriteLine("{0} {1} -> Db Error sent", ErrorNumber.ToString(), Description);
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
                Console.WriteLine("{0} {1} -> Service Error sent", ErrorNumber.ToString(), Description);
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
                Console.WriteLine("{0} {1} -> Fax Error sent", ErrorNumber.ToString(), Description);
            }
        }
    }
}
