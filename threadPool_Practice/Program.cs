using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class ThreadPoolDemo
    {
        static void Main(string[] args)
        {
            // Set the minimum and maximum threads for the thread pool once, outside the loop
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(4, 4);

            // Queue 200 work items to the thread pool
            for (int i = 0; i < 200; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
            }

            Console.ReadLine();
        }

        // Method to be executed by thread pool threads
        public static void MyMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, " +
                             $"Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);
        }
    }
}
