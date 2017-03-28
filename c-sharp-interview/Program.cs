using System;
using System.IO;
using System.Runtime.CompilerServices;

/// <summary>
/// An 120 line example of some C# specific programming things. 
/// Specifically, order of instantiation, attributes/decorators, and some light reflection.
/// </summary>
namespace c_sharp_interview
{
    [Author("Ray Winkelman")]
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0}--- Calling the MostDerived constructor, with a call to the virtual method in the Base class.", Environment.NewLine);
            MostDerived o = new MostDerived();

            Console.WriteLine("{0}--- Calling print() with MostDerived instance.", Environment.NewLine);
            o.Print();

            Console.WriteLine("{0}--- Calling GetCaller()", Environment.NewLine);
            o.GetCaller();

            Console.Read();
        }
    }

    /// <summary>
    /// Base class is the last to be type initialized, and the first to be instance initialized.
    /// </summary>
    abstract class Base
    {
        protected Base()
        {
            Console.WriteLine("Base constructor.");
            Print();
        }

        public virtual void Print()
        {
            Console.WriteLine("Base print method.");
        }
    }

    class Medial : Base
    {
        public Medial()
        {
            Console.WriteLine("Medial constructor.");
        }

        public override void Print()
        {
            Console.WriteLine("Medial print method.");
        }
    }

    /// <summary>
    /// MostDerived class is the first to be type inialized, and the last to be instance initialized.
    /// </summary>
    sealed class MostDerived : Medial
    {
        string _instanceMessage = null;
        const string _typeMessage = "[I've been type initialized]";

        public MostDerived()
        {
            _instanceMessage = "[[I've also been instance initialized]]";
            Console.WriteLine("MostDerived constructor. {0} {1}", _typeMessage, _instanceMessage);
        }

        public override void Print()
        {
            Console.WriteLine("MostDerived print method. {0} {1}", _typeMessage, _instanceMessage);
        }

        // Showing a typical usage of System attributes here. Nothing spectacular - but useful in logging libraries.
        public void GetCaller([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine(memberName);
            Console.WriteLine(Path.GetFileName(sourceFilePath));
            Console.WriteLine("line: " + sourceLineNumber);
        }

        public static void GetAttribute(Type t)
        {
            // Get instance of the attribute.
            AuthorAttribute authorAttribute = (AuthorAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorAttribute));

            if (authorAttribute == null)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                // Get the Name value.
                Console.WriteLine("The Name Attribute is: {0}.", authorAttribute.Name);
            }
        }
    }

    /// <summary>
    /// The Author Attribute!
    /// </summary>
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