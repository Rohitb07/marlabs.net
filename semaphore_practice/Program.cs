using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class Semaphore2
    {
        // Initialize the semaphore with a maximum count of 3
        public static Semaphore semaphore = new Semaphore(3, 3);

        static void Main(string[] args)
        {
            // Creating 10 threads to simulate concurrency with the semaphore
            for (int i = 1; i <= 10; i++)
            {
                Thread threadObj = new Thread(DoSomeTask)
                {
                    Name = "Thread " + i
                };
                threadObj.Start();
            }

            // Wait for user input to exit
            Console.ReadKey();
        }

        // Method to perform a task within the critical section
        static void DoSomeTask()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} wants to enter the critical section.");

            try
            {
                // Block the thread until it can enter the semaphore
                semaphore.WaitOne();
                Console.WriteLine($"Success: {Thread.CurrentThread.Name} is processing in the critical section at {DateTime.Now:HH:mm:ss:ffff}");
                Thread.Sleep(5000); // Simulate some work inside the critical section
                Console.WriteLine($"{Thread.CurrentThread.Name} has exited the critical section.");
            }
            finally
            {
                // Release the semaphore to allow other threads to enter
                semaphore.Release();
            }
        }
    }
}
