using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AsyncAwaitDemo
    {
        // Using async Task for the Main method to allow awaiting asynchronous operations
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main Method Started");
            await SomeMethod(); // Awaiting the asynchronous method to ensure it completes before proceeding
            Console.WriteLine("Main Method Ended");
            Console.ReadLine();
        }

        // Async method returning Task instead of void for proper error handling
        public static async Task SomeMethod()
        {
            Console.WriteLine("Some Method Started .........");
            await Wait();
            Console.WriteLine("Some Method Ended");
        }

        // Async method for simulating a delay
        public static async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("3 seconds Executed");
        }
    }
}
