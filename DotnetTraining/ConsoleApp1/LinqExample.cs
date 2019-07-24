using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NewFeatures
{
    class Dept
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
    }
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int DeptID { get; set; }
    }

    class RepositoryClass
    {
        public static List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            string file = "../../Employees.csv";
            var lines = File.ReadLines(file);
            foreach(var line in lines)
            {
                var words = line.Split(',');
                var emp = new Employee
                {
                    EmpID = int.Parse(words[0]),
                    EmpName = words[1],
                    EmpAddress = words[2],
                    DeptID = int.Parse(words[3])
                };
                list.Add(emp);
            }
            return list;
        }

        public static List<Dept> GetAllDepts()
        {
            return new List<Dept>
            {
                new Dept{ DeptID = 1, DeptName ="Sales"},
                new Dept{ DeptID = 2, DeptName ="After Sales"},
                new Dept{ DeptID = 3, DeptName ="Production"},
                new Dept{ DeptID = 4, DeptName ="Admin"},
                new Dept{ DeptID = 5, DeptName ="IT"}
            };
        }
    }
    class LinqExample
    {
        static Array GetBigGuys(int[] args)
        {
            //var data = from element in args
            //           where element > 10
            //           select element;
            var data = args.Where(e => e > 10).ToArray();
            return data;
        }
        static void Main(string[] args)
        {
            //simpleLinqExample();
            //displayAllNames();
            //displayNamesFromBangalore();
            //displayNamesByOrder();
            //displayNamesAndAddresses();
            //displayNamesByGroups();
            joinExample();
        }

        private static void joinExample()
        {
            var employees = RepositoryClass.GetAllEmployees();
            var depts = RepositoryClass.GetAllDepts();
            var data = from emp in employees
                       join dept in depts on emp.DeptID equals dept.DeptID
                       orderby emp.EmpName
                       group new { emp.EmpName, dept.DeptName }  by dept.DeptName into gr
                       orderby gr.Key descending
                       select gr;
//            foreach (var info in data) Console.WriteLine(info);
            foreach(var gr in data)
            {
                Console.WriteLine("Groups under " + gr.Key);
                foreach(var emp in gr)
                    Console.WriteLine(emp);
            }
        }

        private static void displayNamesByGroups()
        {
            var records = RepositoryClass.GetAllEmployees();
            var groups = from emp in records
                         group new { emp.EmpName, emp.EmpAddress } by emp.EmpAddress into g
                         orderby g.Key
                         select g;
            //An Array of Arrays....
            foreach(var group in groups)
            {
                Console.WriteLine("People working in " + group.Key);
                foreach(var emp in group)
                    Console.WriteLine(emp);
                Console.WriteLine("\n\n\n");
            }
        }

        private static void displayNamesAndAddresses()
        {
            var records = RepositoryClass.GetAllEmployees();
            var data = from emp in records
                       select new { FullName = emp.EmpName , City = emp.EmpAddress };
            //creating an object using new operator with no name is called Anonymous types.
            foreach(var info in data)
                Console.WriteLine(info.FullName);
        }

        private static void displayNamesByOrder()
        {
            var records = RepositoryClass.GetAllEmployees();
            var names = from emp in records
                        orderby emp.EmpName descending
                        select emp.EmpName;
            foreach (var name in names) Console.WriteLine(name);
        }

        private static void displayNamesFromBangalore()
        {
            var records = RepositoryClass.GetAllEmployees();
            var names = from emp in records
                        where emp.EmpAddress == "Bangalore"
                        select emp.EmpName;
            foreach (var name in names) Console.WriteLine(name);
        }

        private static void displayAllNames()
        {
            var rep = RepositoryClass.GetAllEmployees();
            var names = from emp in rep
                        select emp.EmpName;
            foreach (var name in names) Console.WriteLine(name);
        }

        private static void simpleLinqExample()
        {
            var elements = new int[] { 23, 34, 34, 34, 23, 4, 2, 4, 4, 234, 24, 234, 234, 12, 3, 23, 45, 66 };
            //var data = from item in elements
            //         where item > 10
            //       select item;
            var data = GetBigGuys(elements);
            foreach (var item in data) Console.WriteLine(item);
        }
    }
}
