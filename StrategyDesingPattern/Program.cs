using System;

namespace StrategyDesingPattern
{
 
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
            Console.WriteLine($"{str} xml deserialization");
        }

        public void Serialize(string str)
        {
            Console.WriteLine($"{str} xml serialization");
        }
    }

    //Concrete tip 2
    class BinarySeriazlier : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine("binary deserialization");
        }

        public void Serialize(string str)
        {
            Console.WriteLine("binary serialization");
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
