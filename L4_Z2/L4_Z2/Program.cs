using System;
using System.Diagnostics;

namespace L4_Z2
{
    public class A
    {
        public B[] Arguments;

        public A(B b1, B b2)
        {
            Arguments = new[] { b1, b2 };
        }

        public A(B b1, B b2, B b3)
        {
            Arguments = new[] { b1, b2, b3 };
        }

        public void PrintToDebugPropertiesOfArgs()
        {
            Debug.WriteLine("Arguments properties:");
            Debug.Indent();

            foreach (var arg in Arguments)
                arg.PrintPropertiesToDebug();

            Debug.Unindent();
        }
    }
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
            A example = new A(
                new B(),
                new C("Third class"),
                new D()


            );

            example.PrintToDebugPropertiesOfArgs();
            Console.ReadLine();
        }
    }
}
