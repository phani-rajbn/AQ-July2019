using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

//Assembly(Dlls) are of 2 types: Private Assemblies and Shared Assemblies.
//Default is private assemblies, a local copy of the DLL will reside in the executing directory of the Application that consumes it. 
namespace SampleConApp
{
    class SharedAssembly
    {
        static string dllFile = @"B:\Programs\AQJul2019\DotnetTraining\AssemblyLib\bin\Debug\AssemblyLib.dll";
        static Assembly dllInfo;
        static Type classDetails;
        static MethodInfo selectedMethod;
        static object instance;
        static void Main(string[] args)
        {
            //callingMethod();
            //callingMethodThroReflection();
            dllInfo = Assembly.LoadFile(dllFile);
            classDetails = dllInfo.GetType("AssemblyLib.AssemblyClass");
            selectedMethod = classDetails.GetMethod("AddFunc");
            ParameterInfo[] parameters = selectedMethod.GetParameters();
            object[] pmValues = new object[parameters.Length];
            int index = 0;
            foreach (var pm in parameters)
            {
                Console.WriteLine("Enter the value of {0} with data type {1}", pm.Name, pm.ParameterType.Name);
                pmValues[index] = Convert.ChangeType(Console.ReadLine(), pm.ParameterType);
                index++;
            }
            Console.WriteLine("All is set");
            instance = Activator.CreateInstance(classDetails);
            var result = selectedMethod.Invoke(instance, pmValues);
            Console.WriteLine("The result: " + result);
        }

        private static void callingMethodThroReflection()
        {
            //Manually loading the dll, getting the info(Metadata) about the dll at runtime is called as REFLECTION.
            //U may have to probe the classes, methods, parameters, return types of those method and then invoke the methods all done thro code....
            dllInfo = Assembly.LoadFile(dllFile);
            if(dllInfo == null)
            {
                Console.WriteLine("Failed to load the dll\nExiting...");
                return;
            }
            var types = dllInfo.GetTypes();
            foreach (var type in types) Console.WriteLine(type.FullName);
            Console.WriteLine("Enter the type that U want to instantiate");
            string input = Console.ReadLine();
            classDetails = dllInfo.GetType(input,true);
            if (classDetails == null)
            {
                Console.WriteLine("Invalid classname");
                return;
            }
            Console.WriteLine("Lets display all its methods");
            foreach(var method in classDetails.GetMethods())
                Console.WriteLine(method.Name);
            Console.WriteLine("Select the method from the list above");
            selectedMethod = classDetails.GetMethod(Console.ReadLine());
            if (selectedMethod == null)
            {
                Console.WriteLine("Invalid Method selected");
                return;
            }
            if(selectedMethod.GetParameters().Length != 0)
            {
                var parameters = selectedMethod.GetParameters();
                foreach(var pm in parameters)
                    Console.WriteLine(pm.Name + "\t" + pm.ParameterType.Name);
            }
            instance = Activator.CreateInstance(classDetails);
            var result = selectedMethod.Invoke(instance, null);
            if(selectedMethod.ReturnType.Name == "DataTable")
            {
                var table = result as DataTable;
                foreach(DataRow row in table.Rows)
                    Console.WriteLine(row[1]);
            }

        }

        //Add the reference of the dll and use the namespace before U uncomment and run the code....
        private static void callingMethod()
        {
            //var com = new AssemblyClass();
            //try
            //{
            //    var data = com.GetAllEmployees();
            //    foreach(DataRow row in data.Rows)
            //    {
            //        Console.WriteLine(row[1]);
            //    }
            //    Console.WriteLine("Press any key to exit...");
            //    Console.ReadKey();
            //}
            //catch(EmployeeDBException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    if(ex.InnerException != null)
            //    {
            //        Console.WriteLine(ex.InnerException.Message);
            //    }
            //}
        }
    }
}
