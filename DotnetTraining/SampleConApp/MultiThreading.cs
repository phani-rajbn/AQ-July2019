using System;
using System.Threading;

/*
 * Thread is the prefered way of creating Async calls if U want to control the flow of the Async operations like Pausing, Suspending, and Resuming and so forth....
 * A Thread is a path of Execution. Every Process will have atleast one thread called The Main Thread. 
 * However, U could create Apps that run on multiple threads for perform time critical tasks asynchronously.
 * In .NET, a Thread is a class that performs a functionality asynchronously.
 * A Thread is associated with a Thread Function thro a Delegate called  ThreadStart. 
 * All threads are kernal objects that are executed in Kernel mode of the OS.
 * It has a method called Start that begins the Thread. 
 */
namespace SampleConApp
{
    class MultiThreading
    {
        static Mutex mutex = null;
        static MultiThreading()
        {
            if(Mutex.TryOpenExisting("Mutex", out mutex))
            {
                //mutex.WaitOne();
            }
            else
            {
                mutex = new Mutex(false, "Mutex");
            }
        }
        static double result = 0;
        static void ThreadFunc()
        {

            //lock (typeof(MultiThreading))//Monitor is a class of .NET that provides Critical Section Support to the section of code that U want to synchronize. It is similar to Mutex except, Mutex is used for Inter process communication. 
            //          {
            //mutex.WaitOne();
                for (int i = 0; i < 10; i++)
                {
                    result += (i + 1);
                    Console.WriteLine("Thread Beep #" + i);
                    Console.WriteLine("Result:" + result);
                    Console.Beep();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("The result is " + result);
            //            }
            //mutex.ReleaseMutex();
        }
        static Thread th = null;
        static Thread th2 = null;
        static void Main(string[] args)
        {
            if (mutex != null)
                mutex.WaitOne();
            firstThreadExample();
            secondThreadExample();
            otherFuncOfMain();
            Console.ReadKey();
            mutex.ReleaseMutex();
        }

        private static void secondThreadExample()
        {
            th2 = new Thread(new ThreadStart(ThreadFunc));
            th2.Start();
        }

        private static void firstThreadExample()
        {
            th = new Thread(new ThreadStart(ThreadFunc));
            th.Start();
        }

        private static void otherFuncOfMain()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread Beep #" + i);
                Console.Beep();
                Thread.Sleep(1000);
                //if (i == 5)
                //    th.Suspend();
            }
//            th.Resume();
        }
    }
}
