using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Delegate is a reference type that is used to refer methods. 
 * A Reference of a method is required when U want to pass a method as an arg to a function like a Callback Func. 
 * With this reference, it is possible to invoke any method that matches the signature even if its not created currently.
 */
namespace SampleConApp
{
    delegate double FuncName(double first, double second);
    class DelegatesAndEvents
    {
        static void TestFunc(FuncName func)
        {
            if (func != null)
            {
                var res = func(123, 234);
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("No Func is associated with this delegate object");
            }
        }
        static void Main(string[] args)
        {
            FuncName fn = new FuncName(addFunc);
            TestFunc(fn);//calling addfunc
            TestFunc((v1, v2) =>//Lambda Expressions.....
            {
                return v1 - v2;
            });//calling a func that is created internally

            TestFunc((v1, v3) => v3 / v1);//Lambda Expression 
            TestFunc(null);//for calling the else condition....
        }

        static double addFunc(double v1, double v2) => v1 + v2;
    }
}
