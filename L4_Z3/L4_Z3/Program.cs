using System;
using System.Diagnostics;

namespace L4_Z3
{
    public class B
    {
        public virtual void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Class B hasn't properties");
        }
    }
    public class C : B
    {
        public string Name { get; set; } = "";

        public C(string name)
        {
            Name = name;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Class C properties:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(Name)}: {Name}");
            Debug.Unindent();
        }
    }
    public class D : B
    {
        public DateTime TimeOfCreation { get; }

        public D()
        {
            TimeOfCreation = DateTime.Now;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Class D properties:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(TimeOfCreation)}: {TimeOfCreation}");
            Debug.Unindent();
        }
    }
    public class E : B
    {
        public uint Id { get; }

        private static uint LastId = 0;

        public E()
        {
            Id = ++LastId;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Class E properties:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(Id)}: {Id}");
            Debug.Unindent();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            var C = new C("third class");
            var D = new D();
            var E = new E();




            C.PrintPropertiesToDebug();
            D.PrintPropertiesToDebug();
            E.PrintPropertiesToDebug();
            Console.ReadLine();
        }
    }
}
