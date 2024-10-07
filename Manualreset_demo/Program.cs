using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class ManualResetQuestion
    {
        // Initialize ManualResetEvent in a non-signaled state
        static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            // Start a single thread to perform the writing operation
            new Thread(Write) { Name = "WriterThread" }.Start();

            // Start multiple threads to perform the reading operation
            for (int i = 0; i < 5; i++)
            {
                new Thread(Read) { Name = $"ReaderThread-{i + 1}" }.Start();
            }
        }

        // The write operation, executed by a single thread
        public static void Write()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} (ID: {Thread.CurrentThread.ManagedThreadId}) is writing....");
            mre.Reset(); // Block all reader threads
            Thread.Sleep(5000); // Simulate a write operation
            Console.WriteLine($"{Thread.CurrentThread.Name} (ID: {Thread.CurrentThread.ManagedThreadId}) writing completed.");
            mre.Set(); // Allow all reader threads to proceed
        }

        // The read operation, executed by multiple threads
        public static void Read()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} (ID: {Thread.CurrentThread.ManagedThreadId}) is waiting to read....");
            mre.WaitOne(); // Wait until the write operation completes
            Console.WriteLine($"{Thread.CurrentThread.Name} (ID: {Thread.CurrentThread.ManagedThreadId}) is reading....");
            Thread.Sleep(2000); // Simulate a read operation
            Console.WriteLine($"{Thread.CurrentThread.Name} (ID: {Thread.CurrentThread.ManagedThreadId}) reading completed.");
        }
    }
}
