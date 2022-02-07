using System;
using System.Collections.Generic;

namespace CompositeDesignPattern
{
    // Askerlerin rütbeleri
    enum Rank
    {
        General,
        Colonel,
        LieutenantColonel,
        Major,
        Captain,
        Lieutenant
    }



    // Component class
    abstract class Soldier
    {

        protected string _name;
        protected Rank _rank;

        public Soldier(string name, Rank rank)
        {
            _name = name;
            _rank = rank;
        }

        public abstract void AddSoldier(Soldier soldier);
        public abstract void RemoveSoldier(Soldier soldier);
        public abstract void ExecuteOrder(); // Function to be applied for both Leaf and Composite type

    }


    // Leaf class
    class PrimitiveSoldier : Soldier
    {

        public PrimitiveSoldier(string name, Rank rank) : base(name, rank)
        {

        }

        // This function has no meaning for Leaf.
        public override void AddSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        // This function has no meaning for Leaf.
        public override void RemoveSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));
        }

    }



    // Composite Class    
    class CompositeSoldier : Soldier
    {


        // Composite type can contain more than one Component type in itself. It can keep these types in a collection.
        private List<Soldier> _soldiers = new List<Soldier>();

        public CompositeSoldier(string name, Rank rank) : base(name, rank)
        {

        }

        // Used to add a Component under the Composite type
        public override void AddSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }

        // It is used to extract a Component type from the collection under the Composite type.
        public override void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        // Important point. This operation in Composite type is performed for all Components connected to Composite type.
        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));

            foreach (Soldier soldier in _soldiers)
            {
                soldier.ExecuteOrder();
            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                // Root is created.    
                CompositeSoldier generalAtakan = new CompositeSoldier("Atakan", Rank.General);


                // Leaf type object instances are added under root.
                generalAtakan.AddSoldier(new PrimitiveSoldier("Mayk", Rank.Colonel));
                generalAtakan.AddSoldier(new PrimitiveSoldier("Tobiassen", Rank.Colonel));


                // Composite types are created.
                CompositeSoldier colonelNevi = new CompositeSoldier("Nevi", Rank.Colonel);
                CompositeSoldier lieutenantColonelZing = new CompositeSoldier("Zing", Rank.LieutenantColonel);


                // Primitive types are created depending on the composite type.
                lieutenantColonelZing.AddSoldier(new PrimitiveSoldier("Tomasson", Rank.Captain));
                colonelNevi.AddSoldier(lieutenantColonelZing);
                colonelNevi.AddSoldier(new PrimitiveSoldier("Mayro", Rank.LieutenantColonel));

                // A Composite object instance is added under Root.
                generalAtakan.AddSoldier(colonelNevi);


                generalAtakan.AddSoldier(new PrimitiveSoldier("Zulu", Rank.Colonel));


                // For root, the ExecuteOrder operation is applied. Accordingly, this operation is applied for all objects under root
                generalAtakan.ExecuteOrder();


                Console.ReadLine();
            }
        }
    }
}
