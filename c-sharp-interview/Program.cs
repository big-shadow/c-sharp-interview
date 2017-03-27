using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace c_sharp_interview
{
    class Program
    {
        static void Main(string[] args)
        {
            MostDerived o = new MostDerived();
            o.Print("text");

            Console.Read();
        }
    }

    abstract class Base 
    {
        protected Base()
        {
            Console.WriteLine("base constructor.");
            Print("null");
        }

        public virtual void Print(string message)
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

        public override void Print(string message)
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
            instanceInit = " wow, I was instance initialized.";
        }

        public override void Print(string message)
        {
            Console.WriteLine("most derived print method." + typeInit + instanceInit);
        }

        public void GetCaller([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            Console.WriteLine(memberName);
            Console.WriteLine(sourceFilePath);
        }
    }
}
