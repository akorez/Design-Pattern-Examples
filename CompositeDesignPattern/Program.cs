using System;
using System.Collections.Generic;

namespace CompositeDesignPattern
{

    /*
     
      -- Clients treat collections of objects and individual objects uniformly.
     Composite Design Pattern ==> Composite tasarım kalıbı tekil component ve birbirinden farklı componentler grubunun 
    hiyerarşik bir yapıda benzer şekilde hareket etmesini yani kendi içlerinde birbirlerinden farklı olan bir grup nesnenin
    sanki tek bir bütün nesneymiş gibi kullanılmasını bileşik kalıp sağlar. 
     
    Ne zaman Composite tasarım kalıbı kullanmalıyız ?
     - Elimizde düzensiz bir nesne yapısı ve bu nesnelerin birleşimi olduğunda…
     - Client tekil nesne ve nesne grupları arasındaki farklılıkları görmeksizin işlem yapmak istediğinde
     - Kullanıcının isteği doğrultusunda aynı türden veya farklı türlerden bir nesne topluluğu kullanmak zorunda ise, 
    karmaşadan ve karışıklıktan kurtulmak için bileşik kalıp kullanabilir.
    
    Component ==> Ağaç yapısındaki basit ve karmaşık nesneleri ve bu nesnelerin ortak alanlarını açıklayan abstract sınıftır.
    
    Composite ==> Ağaç yapısındaki karmaşık nesnelere karşılık gelen sınıftır. Daha teknik bir izahatte bulunmamız gerekirse eğer 
    Component‘lerin bir araya geldiği ve ağaç yapısındaki alt kırılımları oluşturan kompleks nesneleri temsil etmektedir.
    
    Leaf ==> Ağaç yapısındaki en temel unsuru olan ve alt kırılım barındırmayan tek bir Component nesnesidir. Yani basit nesneyi ifade eder. 


     */
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



    // Component sınıfı
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
        public abstract void ExecuteOrder(); // Hem Leaf hemde Composite tipi için uygulanacak olan fonksiyon

    }


    // Leaf class
    class PrimitiveSoldier : Soldier
    {

        public PrimitiveSoldier(string name, Rank rank) : base(name, rank)
        {

        }

        // Bu fonksiyonun Leaf için anlamı yoktur.
        public override void AddSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        // Bu fonksiyonun Leaf için anlamı yoktur.
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


        // Composite tip kendi içerisinde birden fazla Component tipi içerebilir. Bu tipleri bir koleksiyon içerisinde tutabilir.
        private List<Soldier> _soldiers = new List<Soldier>();

        public CompositeSoldier(string name, Rank rank) : base(name, rank)
        {

        }

        // Composite tipin altına bir Component eklemek için kullanılır
        public override void AddSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }

        // Composite tipin altındaki koleksiyon içerisinden bir Component tipinin çıkartmak için kullanılır
        public override void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        // Önemli nokta. Composite tip içerisindeki bu operasyon, Composite tipe bağlı tüm Component'ler için gerçekleştirilir.
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
                // Root oluşturulur.   
                CompositeSoldier generalAtakan = new CompositeSoldier("Atakan", Rank.General);


                // root altına Leaf tipten nesne örnekleri eklenir.
                generalAtakan.AddSoldier(new PrimitiveSoldier("Mayk", Rank.Colonel));
                generalAtakan.AddSoldier(new PrimitiveSoldier("Tobiassen", Rank.Colonel));


                // Composite tipler oluşturulur.
                CompositeSoldier colonelNevi = new CompositeSoldier("Nevi", Rank.Colonel);
                CompositeSoldier lieutenantColonelZing = new CompositeSoldier("Zing", Rank.LieutenantColonel);


                // Composite tipe bağlı primitive tipler oluşturulur.
                lieutenantColonelZing.AddSoldier(new PrimitiveSoldier("Tomasson", Rank.Captain));
                colonelNevi.AddSoldier(lieutenantColonelZing);
                colonelNevi.AddSoldier(new PrimitiveSoldier("Mayro", Rank.LieutenantColonel));
                    
                // Root' un altına Composite nesne örneği eklenir.
                generalAtakan.AddSoldier(colonelNevi);


                generalAtakan.AddSoldier(new PrimitiveSoldier("Zulu", Rank.Colonel));


                // root için ExecuteOrder operasyonu uygulanır. Buna göre root altındaki tüm nesneler için bu operasyon uygulanır
                generalAtakan.ExecuteOrder();


                Console.ReadLine();
            }
        }
    }
}
