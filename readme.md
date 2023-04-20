# Semaphores 

> This code demonstrates how Semaphores can be used to control access to a shared resource in a multi-threaded application. By limiting the number of threads that can access the shared resource at any given time, we can avoid issues such as race conditions, deadlocks, and resource exhaustion.

```csharp
using System;
using System.Threading;

class Program
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(1); // create a new SemaphoreSlim object with an initial count of 1

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
```

i use the SemaphoreSlim class from the System.Threading namespace to limit the number of threads that can enter a critical section of code at the same time.  

i create a new SemaphoreSlim object with an initial count of 1, meaning that at most 3 threads can enter the critical section simultaneously.

Each thread in the program calls the "Enter" method, which prints a message indicating that it is waiting to enter the critical section, acquires the semaphore, performs some work, and then releases the semaphore before exiting.  

When a thread calls the Wait method on the semaphore, it will block if the semaphore's count is zero, effectively waiting for another thread to release the semaphore. Once a thread successfully acquires the semaphore, it decrements the count by 1, and when it releases the semaphore, the count is incremented by 1.  

