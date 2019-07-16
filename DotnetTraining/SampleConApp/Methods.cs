using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Methods are either static or instance based. 
//C# does not support global functions, so static methods can be used as replacement of global members. It can be accessed by the classname almost behaving like a singleton.
//Static members cannot call instance members even if its in the same class. U must create an instance of the class and then call it.  
//Instance members can call the static members. 
//Static members can be invoked only thro the classname, not by any other means. 
//Instance members are created to hold or manipulate data specific to each instances like Book, Patient, Customer, Employee, Student......
//Static is something that is shared among all the instances or maintiains singleton. 

//Among the methods, u can pass parameters by value, by ref, by out and by params. 
namespace SampleConApp
{
    class SampleClass
    {
        static int data;
        public static void SetData(int data) => SampleClass.data = data;
        public static void TestFunc() => Console.WriteLine("The data is " + data);
    }

    class Tester
    {
        public void TestFunc(int value)
        {
            SampleClass.SetData(value);
        }

        public void ViewData()
        {
            SampleClass.TestFunc();
        }
    }
    class Methods
    {
        static void MathFunc(double v1, double v2, ref double res1, ref double res2)
        {
            res1 = v1 + v2;
            if (v2 == 0)
                res2 = v1;
            else
                res2 = v1 - v2;
        }

        static void ComplexMathFunc(double v1, double v2, out double res1, out double res2)
        {
            res1 = v1 * v2;
            if (v2 == 0)
                res2 = 0;
            else
                res2 = v1 / v2;
        }

        //Variable no of parameters is called Params....
        static double SumFunc(params int[] values)
        {
            //There can be only one params parameter per function. It should the last of the parameter list. params cannot be mixed with ref or  out keywords. 
            double res = 0;
            foreach (var item in values)
                res += item;
            return res;
        }
        static void Main(string[] args)
        {
            // staticmethods();
            double r1 =0, r2 =0;//Must initialize for pass by ref....
            MathFunc(123, 23, ref r1, ref r2);
            Console.WriteLine($"The result of Added value is {r1} and subtracted value is {r2}");
            //When U pass an out parameter, U need not initialize the value as it is set by the called Function itself before it returns to the caller. 
            ComplexMathFunc(123, 23, out r1, out r2);
            Console.WriteLine($"The result of Multiplied value is {r1} and Divided value is {r2}");

            Console.WriteLine(  "The Added sum is " + SumFunc(243, 234, 234, 234, 4, 5, 45, 6, 6,54, 66345, 5, 345, 34, 5345));
        }

        private static void staticmethods()
        {
            Tester tst = new Tester();
            tst.TestFunc(234);

            Tester tst2 = new Tester();
            tst2.ViewData();
            tst2.TestFunc(235456);

            tst.ViewData();
        }
    }
}
