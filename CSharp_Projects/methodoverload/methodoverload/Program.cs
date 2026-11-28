using System;
using MethodOverriding;

namespace MethodOverriding
{
    class Base_class
    {
        public /*virtual*/ void ShowOverride()
        {
            Console.WriteLine("This is base class");
        }
    }

    // creating child class
    class Derived_class : Base_class
    {
        public /*override*/ void ShowOverride()
        {
            Console.WriteLine("This is child class");
        }
    }

    // execution
    class MainMethod
    {
        static void Main(string[] args)
        {
            // instantiation
            Base_class b = new Base_class();
            b.ShowOverride();

            // child class
            Base_class d = new Derived_class();
            d.ShowOverride();


            Console.ReadKey();
        } // main method
    } // MainMethod class
} // namespace

//*********with virtual and override*********


/*using System;

namespace MethodOverriding
{
    class Base_class
    {
        public virtual
void ShowOverride()
{
    Console.WriteLine("This is base class");
}
    }

    // creating child class
    class Derived_class : Base_class
{
    public override void ShowOverride()
    {
        Console.WriteLine("This is child class");
    }
}

// execution
class MainMethod
{
    static void Main(string[] args)
    {
        // instantiation
        Base_class b = new Base_class();
        b.ShowOverride();

        // child class
        Base_class d = new Derived_class();
        d.ShowOverride();


        Console.ReadKey();
    } 
} 
}
*/