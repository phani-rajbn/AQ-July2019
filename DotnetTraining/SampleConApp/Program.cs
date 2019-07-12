//Default namespace is the name of the Project, U could however change it if required.
//.NET Framework has all its API Classes grouped into namespaces, U must use the namespace and then access the classes. Namespace is refered using the using keyword followed by the namespace name that U want to use. 
using System;
namespace SampleConApp
{
    class Firstprogram//Classname and the file name will be same by default for better management, but its not mandatory in C# to have the Filename and the classname as same. 
    {
        static void Main()
        {
            Console.WriteLine("Testing123");
            Console.WriteLine("My Name is Phaniraj");
            Console.WriteLine("I am a Trainer in .NET");
            Console.WriteLine("Enter UR Name");
            string name = Console.ReadLine();//String is a class that represents an array of Charecters. 
            Console.WriteLine("The Name entered is " + name);

            Console.WriteLine("Enter the Age");
            string age = Console.ReadLine();

            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();

            Console.WriteLine("Enter the Salary");
            string salary = Console.ReadLine();

            Console.WriteLine("The Name is {0} from {1}\nMr.{0}'s age {2} and Salary of {3}", name, address, age, salary);
            Console.WriteLine("The no " + 456);
        }
        //Run the program: Ctrl + F5
        /*Points:
         * All IO related operations are strings.
         * Inputs will be as strings
         * Outputs are also strings.
         * WriteLine method evaluates the variable to a string and then writes to the Console. 
         * ReadLine reads the input given by the user and returns a string representation of it. 
         * Programmers have to convert to their required datatypes.
         * Main is the entry point of C# Application. 
         * It is static function, it is inside a Class. Main is not global function. It can be invoked without an object instance. 
         * C# does not support Global functions and Global variables, everything is a part of a class, struct. Main Function has to be invoked without an object which is done thro Static. It need not be public. Main is case sensitive.
         * Main can have only String[] or nothing as its args. 
         * Main can have either int or void as its return type.
         * If there are 2 or more classes that have entry point in ur project, U should provide Project Setting called StartUp Object to specify the class that U want to execute as the Entry point. However the other files and the classes will continue to be compiled when the code is built.  
         */
    }

    class SecondProgram
    {
        static void Main()
        {
            Console.WriteLine("Another Main which is intended to be the entry point");
        }
    }
}
