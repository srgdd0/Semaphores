using System;
using System.Threading;

class Program
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(3); // create a new SemaphoreSlim object with an initial count of 3

    static void Main()
    {
        for (int i = 1; i <= 5; i++) // create 5 threads
        {
            Thread thread = new Thread(Enter); // create a new thread
            thread.Start(i); // start the thread and pass it a unique ID
        }
    }

    static void Enter(object id)
    {
        Console.WriteLine("Thread {0} is waiting to enter...", id);
        semaphore.Wait(); // acquire the semaphore
        Console.WriteLine("Thread {0} has entered!", id);

        Thread.Sleep(1000); // simulate some work

        Console.WriteLine("Thread {0} is leaving...", id);
        semaphore.Release(); // release the semaphore
    }
}