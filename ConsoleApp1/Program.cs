using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 100;
            Console.WriteLine("Hello World!");

            string name = "John";
            string dept = "Sales";

            byte a = 111;
            byte b = 111;
            byte c;

            try
            {
                checked
                {
                    c = (byte)((byte)a * (byte)b);
                }
                Console.WriteLine("The result of the multiplication is: " + c);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow occurred during byte multiplication. The result is too large to fit in a byte.");
            }
        }
    }
}
