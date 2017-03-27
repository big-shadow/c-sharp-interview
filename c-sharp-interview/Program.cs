using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace c_sharp_interview
{
    [Author("Ray Winkelman")]
    class Program
    {
        static void Main(string[] args)
        {
            MostDerived o = new MostDerived();
            o.Print();
            o.GetCaller();

            Console.Read();
        }
    }

    abstract class Base 
    {
        protected Base()
        {
            Console.WriteLine("base constructor.");
            Print();
        }

        public virtual void Print()
        {
            Console.WriteLine("base print method.");
        }
    }

    class Medial : Base
    {
        public Medial()
        {
            Console.WriteLine("medial constructor.");
        }

        public override void Print()
        {
            Console.WriteLine("medial print method.");
        }
    }

    class MostDerived : Medial
    {
        string instanceInit = null;
        string typeInit = " wow, I was type initialized.";

        public MostDerived()
        {
            Console.WriteLine("most derived constructor.");
            instanceInit = " wow, I was also instance initialized.";
        }

        public override void Print()
        {
            Console.WriteLine("most derived print method." + typeInit + instanceInit);
        }

        public void GetCaller([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine(memberName);
            Console.WriteLine(Path.GetFileName(sourceFilePath));
            Console.WriteLine("line: " + sourceLineNumber);
        }
    }

    // Attribute usage.
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        private string name;
    }
}
