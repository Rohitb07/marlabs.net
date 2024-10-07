using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class MutexDemo
    {
        // Creating a static Mutex to be shared among threads
        private static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            // Creating multiple threads to demonstrate the Mutex functionality
            for (int i = 1; i <= 3; i++)
            {
                Thread thread = new Thread(MutexDemoFn)
                {
                    Name = "Child Thread: " + i
                };
                thread.Start();
            }

            
        }

        // Method that represents the critical section accessed by multiple threads
        static void MutexDemoFn()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " wants to enter the critical section.");

            // Attempt to acquire the Mutex within a timeout of 1000 milliseconds
            if (mutex.WaitOne(1000))
            {
                try
                {
                    Console.WriteLine("Success: " + Thread.CurrentThread.Name + " has entered the critical section.");
                    Thread.Sleep(2000); // Simulate some work being done
                    Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " has completed.");
                }
                finally
                {
                    mutex.ReleaseMutex(); // Always release the Mutex in the 'finally' block
                }
            }
            else
            {
                Console.WriteLine("Failure: " + Thread.CurrentThread.Name + " could not acquire the Mutex.");
            }
        }

        // Destructor to release the Mutex resources when the object is destroyed
        ~MutexDemo()
        {
            mutex.Dispose();
        }
    }
}
