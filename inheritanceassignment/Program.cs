using System;

namespace ConsoleApp1
{
    internal class InheritanceAssign
    {
        static void Main()
        {
            // Creating an instance of class C and displaying its values
            C objC = new C(11, 22, 33);
            objC.DisplayValues();
        }
    }

    class A
    {
        public int a; // Public field in base class

        public A(int i)
        {
            a = i;
        }
    }

    class B : A
    {
        public int b; // Public field in derived class

        public B(int i, int j) : base(i)
        {
            b = j;
        }

        public void DisplayMessage()
        {
            Console.WriteLine("Hello from class B");
        }
    }

    class C : B
    {
        public int c; // Public field in the most derived class

        public C(int i, int j, int k) : base(i, j)
        {
            c = k;
        }

        public void DisplayValues()
        {
            base.DisplayMessage();
            Console.WriteLine("Values are: a = " + a + ", b = " + b + ", c = " + c);
        }
    }
}
