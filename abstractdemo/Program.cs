using System;

namespace abstractdemo
{
    interface IA
    {
        void M();
    }

    interface IB
    {
        void M();
    }

    interface IC : IA, IB
    {
        // No implementation here; implementations go in the implementing class
    }

    interface ISampleInterface
    {
        void SampleMethod();
        void AddMethod();
        void SubtractMethod();
    }

    abstract class Abs
    {
        // Abstract method
        public abstract void display();

        public void fn1()
        {
            Console.WriteLine("fn1");
        }

        public void fn2()
        {
            Console.WriteLine("fn2");
        }
    }

    class Child3 : Abs
    {
        // Sealed method to prevent further overrides
        public sealed override void display()
        {
            Console.WriteLine("display");
        }
    }

    // Child4 class inheriting from Child3 (completed the class definition)
    class Child4 : Child3
    {
        // Child4 cannot override the 'display' method because it's sealed in Child3
    }

    interface IF
    {
        // Interfaces cannot have fields directly. Only properties or methods are allowed.
        void A(int t);
        void M();
    }

    class F : IF
    {
        public void A(int t)
        {
            // Implementation logic here
        }

        public void M()
        {
            Console.WriteLine("IF.M called");
        }
    }

    internal class AbstractDemo : ISampleInterface, IC
    {
        static void Main(string[] args)
        {
            // Creating an instance of F
            F ob = new F();
            ob.M();

            // Creating an instance of AbstractDemo and casting to different interfaces
            AbstractDemo obj = new AbstractDemo();

            IC isInstance = obj;
            ((IB)isInstance).M();

            IB ibInstance = (IB)obj;
            ibInstance.M();
        }

        // Implementation of ISampleInterface methods
        public void AddMethod()
        {
            Console.WriteLine("AddMethod implementation");
        }

        public void SampleMethod()
        {
            Console.WriteLine("SampleMethod implementation");
        }

        public void SubtractMethod()
        {
            Console.WriteLine("SubtractMethod implementation");
        }

        // Explicit interface implementation for IA.M and IB.M
        void IA.M()
        {
            Console.WriteLine("IA.M called");
        }

        void IB.M()
        {
            Console.WriteLine("IB.M called");
        }
    }
}
