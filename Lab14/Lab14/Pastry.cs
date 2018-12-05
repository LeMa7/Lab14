using System;

namespace lab14
{

    interface IMethodPastryInfo
    {
        void info();
    }

    interface IPastryInfo
    {
        string weight { get; set; }
        string shape { get; set; }
        string filling { get; set; }


        void info();
    }

    [Serializable]
    public abstract class Pastry : IMethodPastryInfo, IPastryInfo
    {
        public string weight { get; set; }
        public string shape { get; set; }
        public string filling { get; set; }
        public bool coconutChips { get; set; }



        void IPastryInfo.info()
        {
            if (coconutChips)
            {
                Console.WriteLine("Покрыто кокосовой стружкой");
            }
            else
            {
                Console.WriteLine("Не покрыто кокосовой стружкой");
            }
        }

        void IMethodPastryInfo.info()
        {
            Console.WriteLine("Это метод info");
        }

        public virtual void addInfo()
        {
            Console.WriteLine("Введите вес");
            weight = Console.ReadLine();
            Console.WriteLine("Введите форму");
            shape = Console.ReadLine();
            Console.WriteLine("Введите начинку");
            filling = Console.ReadLine();
            Console.WriteLine("Покрыто ли кокосовой стружкой?");
            string a = Console.ReadLine();

            if (a == "Да")
            {
                coconutChips = true;
            }

            Console.WriteLine("\n");

        }

        public virtual void Type()
        {
            Console.WriteLine("Кондитерские изделия");
        }


        public Pastry()
        {
            weight = null;
            shape = null;
            filling = null;
            coconutChips = false;
        }

        public override string ToString()
        {
            Type();
            string str = weight + "\n" + shape + "\n" + filling + "\n";
            if (coconutChips == true)
            {
                str = str + "Покрыто кокосовой стружкой";
            }
            else
            {
                str = str + "Не покрыто кокосовой стружкой";
            }
            return str;
        }

    }

    [Serializable]      
    public class Candy : Pastry
    {

        public override void Type()
        {
            Console.WriteLine("Конфета");
        }
        
    }

    sealed class Caramel : Pastry
    {
        public override void Type()
        {
            Console.WriteLine("Карамель");
        }
    }

    class Chocolate : Pastry
    {
        public override void Type()
        {
            Console.WriteLine("Шоколадная конфета");
        }
    }

    class Cookie : Pastry
    {
        public override void Type()
        {
            Console.WriteLine("Печенюшка");
        }
    }

    class BoxOfCandies : Candy
    {
        public override void Type()
        {
            Console.WriteLine("Коробка конфет");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }
}
