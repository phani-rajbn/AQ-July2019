using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyLib;
//Assembly(Dlls) are of 2 types: Private Assemblies and Shared Assemblies.
//Default is private assemblies, a local copy of the DLL will reside in the executing directory of the Application that consumes it. 
namespace SampleConApp
{
    class SharedAssembly
    {
        static void Main(string[] args)
        {
            var com = new AssemblyClass();
            try
            {
                var data = com.GetAllEmployees();
                foreach(DataRow row in data.Rows)
                {
                    Console.WriteLine(row[1]);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch(EmployeeDBException ex)
            {
                Console.WriteLine(ex.Message);
                if(ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}
