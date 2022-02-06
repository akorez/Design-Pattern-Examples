using System;

namespace StrategyDesingPattern
{
    /*
 * --  Encapsulates interchangeable behaviors and uses delegation to decide which one to use. --
 Strategy Design Pattern ==> Bir fonksiyonun birden fazla yapılış şekli olduğu takdirde, bu fonksiyonelliği farklı versiyonlarıyla 
kullanmak istendiğinde kullanılabilecek bir design patternidir.

Aynı işi farklı şekillerde yapan birden fazla concrete strategy classımız olduğunda bunları bir strategy class üzerinden clienta sunmak, 
strategy classına da bu concrete tiplere ait ortak ata olan interfaceyi vermek , ilerleyen zamanlarda bu concrete tiplere bir yenisi daha 
eklendiğinde , işimizi kolaylaştıracak, bu durumda tek yapmamız gereken bu concrete tipi ortak interfaceden türetmek yeterli olacaktır. 

 */
    class Program
    {

        static void Main(string[] args)
        {
            Serializer srz = new Serializer(new XmlSerializer());

            srz.Serialize("Stragey");
            srz.Deserialize("Stragey");

            srz = new Serializer(new BinarySeriazlier());

            srz.Serialize("");
            srz.Deserialize("");
        }
    }

    //Base Interface
    interface ISerializable
    {
        void Serialize(string str);
        void Deserialize(string str);
    }

    //Concrete tip 1
    class XmlSerializer : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine($"{str} xml ters serileştirme");
        }

        public void Serialize(string str)
        {
            Console.WriteLine($"{str} xml serileştirme");
        }
    }

    //Concrete tip 2
    class BinarySeriazlier : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine("binary ters serileştirme");
        }

        public void Serialize(string str)
        {
            Console.WriteLine("binary serileştirme");
        }
    }

    //Context tip
    class Serializer
    {
        ISerializable _serializer;

        public Serializer(ISerializable serializer)
        {
            _serializer = serializer;
        }

        public void Serialize(string str)
        {
            _serializer.Serialize(str);
        }

        public void Deserialize(string str)
        {
            _serializer.Deserialize(str);
        }
    }
}
