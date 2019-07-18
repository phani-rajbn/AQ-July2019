using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace SampleConApp
{
    //Async Programming can be done with delegates. 
    //.NET gives 2 delegates for any kind of functions: void(Action) and non void(Func).
    class AsynchronousProgramming
    {
        static Func<double, double, double> fun;
        static int BigFunction()
        {
            int res = 0;
            for (int i = 0; i < 10; i++)
            {
                res += i;
                Console.Beep();
                Console.WriteLine("Beep#{0}", i);
            }
            return res;
        }
        static void Main(string[] args)
        {
            //firstExample();
            secondExample();
        }

        private static void secondExample()
        {
            Func<int> fun = BigFunction;
            IAsyncResult res = fun.BeginInvoke((iRes) =>
            {
                var asyncResult = (AsyncResult)iRes;
                var ourDelegate = asyncResult.AsyncDelegate as Func<int>;
                int actualResult = ourDelegate.EndInvoke(iRes);
                Console.WriteLine("The result is " + actualResult);
            }, null);
            //while(res.IsCompleted == false)
            //{
                
            //    Console.WriteLine("Please wait till we get the Result..");
            //    Thread.Sleep(200);
            //    Console.Clear();               
            //}
            Console.WriteLine("The End of our Program....");
        }

        private static void firstExample()
        {
            fun = (v1, v2) => v1 + v2;
            Console.WriteLine(fun(123, 234));
            //Action action = new Action(BigFunction);
            //Action action = BigFunction;
            Func<int> action = BigFunction;
            IAsyncResult res = action.BeginInvoke(null, null);///Invoke a method asychronously...
            AnotherFunc();
            int result = action.EndInvoke(res);//Calling Func will wait for the async function to complete...
            Console.WriteLine("The result is " + result);
        }

        private static void AnotherFunc()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Beep();
                Console.WriteLine("Another Func's Beep#{0}", i);
            }
        }
    }
}
