using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Interview
{
    class Program
    {
        static void Main1(string[] args)
        {
            // 2 method paralel çalışır. 10 defa Method1 ardından Method2 yazar, yani paralel çalışır.
            Parallel.Invoke(() => Method1(), () => Method2());

            // 2 method ardışık çalışır. Önce 10 tane Method1 yazar, ardından 10 tane Method2 yazar
            Method1();
            Method2();

            // Out olan methodu çağırmadan önce out değişkenleri tanımlanmalıdır.
            int sum, dif;
            MyMaths(10, 10, out sum, out dif);
            MyMaths(10, 10, out int sum2, out int dif2); // C# 6 sonrası gelen özellik
            Console.WriteLine(sum);
            Console.WriteLine(dif);


            // Ref olan methodu çağırmadan önce Ref değişkenleri tanımlanmalıdır. Ancak bu değişkenlere başlangıç değerleri atanmalıdır.
            int sayiRef = 0;
            DegistirRef(ref sayiRef);
            Console.WriteLine(sayiRef);

            //Boxing işlemi - Normal atamadan 20 kat daha uzun sürer
            int sayi = 8765;
            object a = sayi;

            sayi++;

            Console.WriteLine(sayi); // Sonuç sayının bir fazlası olan 8766'dır
            Console.WriteLine(a); // Sonuç sayının kendisidir(8765). Çünkü referans gösterilmektedir.

            //Unboxing işlemi - Normal atamadan 4 kat daha uzun sürer
            int b = (int)a; // a burada object'tir, yani referans tip.

            CellPhone cp = new CellPhone();
            cp.Typing(); // Polymorphism - 2 tane kullanım çeşidi var

            IEnumerable<int> values = new List<int>();

        }


        //static metodlar ismi ile çağrılır ve örneği üretilemez.
        static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Method1");
            }
        }

        static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Method2");
            }
        }


        static void MyMaths(int num1, int num2, out int sum, out int dif)
        {
            sum = num1 + num2;
            dif = num1 - num2;
        }

        static void DegistirRef(ref int sayiRef)
        {
            sayiRef = 1234;
        }

    }



    //POLYMORPHISM

    //Polymorphism - Compile Time (overloading)
    public class CellPhone
    {
        public void Typing()
        {
            Console.WriteLine("Using keypad");
        }

        public void Typing(bool isSmartPhone)
        {
            Console.WriteLine("Using qwerty keyboard");
        }
    }

    //Polymorphism - Runtime (overriding)

    class CellPhone2
    {
        public virtual void Typing()
        {
            Console.WriteLine("Using keypad");
        }
    }

    class SmartPhone : CellPhone2 // Inheritance
    {
        public override void Typing()
        {
            Console.WriteLine("Typing function from child class");
        }

    }

    class User
    {

        // Encapsulation
        string address;
        private string name;

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

    }

    // C# is managed code. Because Common Language Runtime (CLR) manages C# codes. CLR compiles and executes C# codes.
    // It is resposible for automatic memory management, security boundries, type-safety, etc.


    // Interface
    public interface myInterface1
    {
        void Print();
    }

    public interface myInterface2
    {
        void Print();
    }

    //Multiple Interface with same method
    class Student : myInterface1, myInterface2
    {
        void myInterface1.Print()
        {
            Console.WriteLine("For myInterface1");
        }

        void myInterface2.Print()
        {
            Console.WriteLine("For myInterface2");
        }
    }


    // Static class'lardan instance(new kelimesi) ile oluşturulamaz

    // Static class'larda "this" kullanılmaz

    /* const ile readonly arasındaki fark ==> a) const tanımlanırken değer verilmelidir, readonly de ise hem tanımlama anında hem de class constructor
    'ında değer verilebilir.  b) const ile static kullanılmaz, readonly kullanılabilir  */


    //sealed kelimesi ile bir class'ın inherit edilmesini engelleriz



    class Books : IDisposable
    {
        private string _name { get; set; }
        private double _price { get; set; }
        public Books(string name, double price)
        {
            _name = name;
            _price = price;
        }
        public void Print()
        {
            Console.WriteLine("Book name is {0} and price is {1}", _name, _price);
        }
        public void Dispose()
        {
            Console.WriteLine("Disposing of Book");
        }
    }

    class Students
    {
        public void DoSomething()
        {
            // using kullanarak işlem bittiğinde Dispose methodu otomatik olarak çalıştırılır
            using (Books myBook = new Books("book name", 12.45))
            {
                myBook.Print();
            }
        }
    }


    // Dependency Injection interface'ler ile yapılır ve kodda yer alan bağımlılığı azaltır(loosely-coupled)


    //Delegates -- method pointer
    class DelegateClass
    {
        // declare delegate
        public delegate void Print(int value);
        static void Main4(string[] args)
        {
            //Single Cast Delegate
            // Print delegate points to PrintNumber
            Print printDel = PrintNumber;
            // or Print printDel = new Print(PrintNumber);
            printDel(100000);

            // Print delegate points to PrintMoney
            printDel = PrintMoney;
            printDel(10000);

            Print printNumDel = PrintNumber;
            Print printMonDel = PrintMoney;

            //MultiCast Delegate
            Print multiPrintDel = printNumDel + printMonDel; // 2 method ardı ardına çalıştırılır
            multiPrintDel(100);

            multiPrintDel = printMonDel - printNumDel; // Money metodu çalıştırılır, diğer çalıştırılmaz
            multiPrintDel(100);

        }
        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }
        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }

        int[] marks = new int[3] { 25, 34, 89 }; // Single Dimension Array
        int[,] numbers = new int[3, 2] {  //Multi-Dimensional array
            { 1, 2 },
            { 2, 3 },
            { 3, 4 }
        };
    }


    // Array ile ArrayLisat arasındaki fark : Array ==> fixed type, ArrayList ==> multi-type
    class Sample
    {
        //Array and Araraylist.
        public void ArrayFunction()
        {
            string[] country = new string[3];
            country[0] = "USA"; //only string value can be added
            country[1] = "Denmark";
            country[2] = "Russia";
            //can store different data types
            ArrayList arraylist = new ArrayList();
            arraylist.Add(3);
            arraylist.Add("USA");
            arraylist.Add(false);
        }

        /* 
         A jagged array is like a nested array; each element of a jagged array is an array in itself.
         The item of a jagged array can be of different dimensions and sizes.
        */
        public void ShowJaggedArray()
        {
            int[][] jaddedArray = new int[2][];
            jaddedArray[0] = new int[3] { 1, 2, 3 };
            jaddedArray[1] = new int[4] { 1, 2, 3, 4 };
        }
    }

    /*
     Struct

        - A Struct inherits from System. Value type and so it is a value type.
        - It is preferred to use struct when there is a small amount of data. 
        - A structure cannot be abstract.
        - There is no need to create an object with a new keyword.
        - Struct does not have permission to create any default constructor.
     
     */

    struct MyStruct
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }

    /* 
    Class

        - The class is a reference type in c#, and it inherits from the System. Object Type.
        - When there is a large amount of data, then in that scenario, classes are used.
        - We can inherit one class from another class.
        - A class can be an abstract type. 

     */

    class Class
    {

    }

    /*
     What is the difference between throw and throw ex?
        “Throw” statement holds the original error stack of the previous function or function hierarchy. 
         In contrast, “Throw ex” has the stack trace from the throw point.  So it is always advised to use “Throw”, 
         because it provides exact error information related to the function and gives you actual trace data of error source.
     */

    /*
     Explain the difference between finally and finalize block?
       - Finally, it is a code block part of execution handling this code block executes irrespective of whether the exception occurs or not.

       - While the finalize method is called just before garbage collection. The compiler calls this method automatically 
    when not called explicitly in code.
     */

    class MyClass
    {
        static void Main3(string[] args)
        {
            var someVariable = 25;
            someVariable = 43;
            someVariable = "Hello"; // you can not assign dfferent type variable
        }

    }

    public class Bike
    {
        dynamic someValue = 21;
        public Bike()
        {
            //assigned string value later
            someValue = "Hello";
        }
    }

    public class SomeClass
    {
        static void Main6(string[] args)
        {
            print();
            anonymousData; // you can't acces anonymous type outside of method
            DoPurchase(0);
        }

        public static void print()
        {
            //anonymous type
            var anonymousData = new
            {
                FirstName = "John",
                SurName = "lastname"
            };
            Console.WriteLine("First Name : " + anonymousData.FirstName);

            // Classical try-catch example
            try
            {
                //write some code here
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                /*code to execute in the last
                like dispose objects and resource*/
            }


            // Try - Multiple Catch example - we can use one catch and if block for every exception type Instead of this
            try
            {
                // try some stuff
            }
            catch (FormatException ex) { }
            catch (OverflowException ex) { }
            catch (ArgumentNullException ex) { }
        }


        //Custom exception example
        public static void DoPurchase(int quantity)
        {
            if (quantity == 0)
            {
                //this will throw error here with the custom message
                throw new Exception("Quantity cannot be zero");
            }
        }

        // LinQ Example
        public void GetData()
        {
            List<string> mobiles = new List<string>() {
                "Iphone","Samsung","Nokia","MI"
            };
            //linq syntax
            var result = from s in mobiles
                         where s.Contains("Nokia")
                         select s;

            Console.WriteLine("Result is : " + result.FirstOrDefault());
        }
    }


    //Generic Type
    //We use < > to specify Parameter type 
    public class GFG<T>
    {
        //private data members 
        private T data;
        //using properties 
        public T value
        {
            //using accessors 
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
    }
    //vehicle class 
    class Vehicle
    {
        //Main method 
        static void Main(string[] args)
        {
            //instance of string type 
            GFG<string> company = new GFG<string>();
            company.value = "Tata motors";
            //instance of float type 
            GFG<float> version = new GFG<float>();
            version.value = 6.0F;
            //display Tata motors 
            Console.WriteLine(company.value);
            //display 6 
            Console.WriteLine(version.value);


            char c1 = 'a';
            char c2 = 'A';
            Console.WriteLine(c1 == c2); // output false. Referansları karşılaştırır
            Console.WriteLine(c1.Equals(c2)); // output true. Content'i karşılaştırır

        }
    }

    /* 
     Below are the steps explaining the code compilation.

        - The C# compiler compiles the code into managed code, also called Byte code.
        - Then JIT (Just in time compiler) compiles the Byte code into Native or machine language, which is directly executed by CPU.

     */

    // Example of Composition. Inheritance ile karşılaştırılır. Inheritance'de parent class inherit edilir, composition'da ise bir class diğer class
    // içerisinde kullanılır. First class ==> BackEnd class,  Second Class ==> FrontEnd Class'dır.
    public class FirstClass
    {
        public string property { get; set; }

        public void FirstMethod()
        {
            // Do something....
        }
    }

    public class SecondClass
    {
        private FirstClass firstClass = new FirstClass();
        public string ClassProperty { get; set; }

        public void MyMethod()
        {
            // Do something....
            firstClass.FirstMethod();
        }
    }


    /*
      IMMUTABLE CLASS Kavramı

         Immutable objectlerin en önemli avantajı multi thread uygulamalarda ortaya çıkıyor. Immutable objectleri stateleri değiştirilemediği 
     için o nesneyi kaç tane thread kullanırsa kullansın o nesne üzerinde değişiklik yapamıyor. Hal böyle olunca siz de threadler arasındaki 
    senkronizasyonu sağlayacak olan mekanizmaları yazmaktan kurtulmuş oluyorsunuz ve otomatik olarak yazdığınız tip thread-safe oluyor.
     
     */
    public class ImmutableClass
    {
        private readonly int _x;
        private readonly int _y;

        public int X
        {
            get
            {
                return _x;
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }
        }
        public ImmutableClass(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
    }
}


