using System;
using System.Collections.Generic;
using System.Linq;
//Since .NET 4.0, we got a new set of features added to C# and .NET Framework for better programming abilities. This is for more  productivity and easiness in developing the .NET Code.
namespace NewFeatures
{
    static class MyExtensions
    {
        public static int GetNo(this string words)
        {
            var total = words.Split(',', ' ', ';');
            return total.Length;            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //varUsage();
            //anonymousMethod();
            //lambdaExpression();
            //extensionMethods();
        }

        private static void extensionMethods()
        {
            string words = "var is a convinient";
            int total = words.GetNo();
            Console.WriteLine("The total no of words: " + total);
        }

        private static void lambdaExpression()
        {
            Func<double, double, double> addFunc =  ( v1,  v2) => v1 + v2;
            var res = addFunc(123, 234);
            Console.WriteLine(res);
        }

        private static void anonymousMethod()
        {
            Action myFunc = new Action(delegate ()
            {
                //method is created with no name using delegate: delegate is used for not only creating a delegate but also for instantiating the delegate. 
                Console.WriteLine("Anonymous method");
            });//In .NET 2.0
            myFunc();
        }

        private static void varUsage()
        {
            /*
             * var is a convinient way of declaring local variables in C#. 
             * It is also called as Implicit Typed variables. The variable will hold the datatype based on the value that it has been assigned with. 
             * variables have to be assigned in the declaration statement only.
             * The variable will get all the features of the data type once its assigned including its type conversion rules
             * Unlike object, u dont have to unbox it to perform any datatype specific operations. 
             * var cannot be used as a field of a class, return type of a function or parameters of a function. 
             */
            var values = new Dictionary<string, string>();
            values.Add("Apple", "kashmir");
            values.Add("Oranges", "Nagpur");
            values.Add("Mangoes", "Salem");
            values.Add("Bananas", "Tamilnadu");

            foreach (var pair in values) Console.WriteLine(pair.Key);
        }
    }
}
