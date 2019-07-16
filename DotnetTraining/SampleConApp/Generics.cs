using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Generic is the type safe collections of .NET introduced in .NET 2.0. Older collections are still used in some apps but of limited support. 
//Gereric is more typesafe and works like Templates of C++. 
//Generic has classes and Interfaces to work as collections where data can be added, removed, and sorted at anypoint of time and behaves like a dynamic Array....
//Most of the generics are extended versions of the older Collection classes. 
//Array->ArrayList(Collections)->List<T>(Generics)
//Hashset for unique collections
//Dictionary for Key-Value pair Collections
//Stack and Queue for sp kind of data storages. 
//Linked List for reference type data storage.

//All these classes have implemented a set of Interfaces which can be implemented by our classes to behave like the std classes of Generics.
//IEnumerable<T>->ICollection<T>->IList<T>, ISet<T>, IDictionary<K,V>.

//A Collection class is one whose object can be used in a foreach statement. 

namespace SampleConApp
{
    
    class Generics
    {
        static void Main(string[] args)
        {
            //listExample();
            //hashsetExample();
            //teamExample();
            //dictionaryExample();
            //queueExample();
            //StackExample();
            customGenericExample();
           
        }

        private static void customGenericExample()
        {
            DataCollection<Employee> employees = new DataCollection<Employee>();
            employees.AddRecord(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            employees.AddRecord(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            employees.AddRecord(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            employees.AddRecord(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            employees.AddRecord(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            var data = employees.GetAllRecords();
            //foreach (var emp in data) Console.WriteLine(emp.Empname);
            //foreach(var emp in employees)
            //    Console.WriteLine(emp.Empname);

            var iterator = employees.GetEnumerator();
            while(iterator.MoveNext())
                Console.WriteLine(iterator.Current.Empname);
        }

        private static void queueExample()
        {
            Queue<string> recentItems = new Queue<string>();
            do
            {
                string item = Prompt.GetString("Enter the item to view");
                if (recentItems.Count == 5)
                    recentItems.Dequeue();//Removes the first item from the Q.
                recentItems.Enqueue(item);
                Console.WriteLine("UR recently viewed items");
                var list = recentItems.Reverse();
                foreach(var i in list)
                    Console.WriteLine(i);
            } while (true);
        }

        private static void dictionaryExample()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            do
            {
                var choice = Prompt.GetString("Press R to Register and L to Login");
                if(choice.ToUpper() == "R")
                {
                    var userId = Prompt.GetString("Enter the userrname to register");
                    var pwd = Prompt.GetString("Enter the Password");
                    if (users.ContainsKey(userId))
                    {
                        Console.WriteLine("User name already registered, please try with new Name");
                    }
                    else
                    {
                        //users.Add(userId, pwd);//throws an Exception if the key already exists...
                        users[userId] = pwd;//It adds a new key and a value pair, but if the key exists, it simply replaces the value.....
                        Console.WriteLine("User registered\nPlease login");
                    }
                }
                else
                {
                    var userId = Prompt.GetString("Enter the userrname to login");
                    var pwd = Prompt.GetString("Enter the Password");
                    if(users[userId] == pwd)
                        Console.WriteLine("Welcome user");
                    else
                        Console.WriteLine("Invalid username or pasword");
                }
            } while (true);
        }

        private static void teamExample()
        {
            HashSet<Employee> team = new HashSet<Employee>();
            team.Add(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            team.Add(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            team.Add(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            team.Add(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            team.Add(new Employee { EmpID = 1, EmpAddress = "BLR", Empname = "Phaniraj", EmpSalary = 45000 });
            Console.WriteLine("The total no of team members: " + team.Count);
        }

        private static void hashsetExample()
        {
            //Hashset takes only unique data in it. No duplicates allowed...
            HashSet<String> basket = new HashSet<string>();
            basket.Add("Apples");
            if (basket.Add("Mangoes")) Console.WriteLine("added"); else Console.WriteLine("Duplicate"); 
            basket.Add("Oranges");
            basket.Add("PineApples");
            basket.Add("Gauvas");
            Console.WriteLine("The No of items in the cart: " + basket.Count);
            foreach (var item in basket) Console.WriteLine(item);
        }

        private static void listExample()
        {
            List<string> basket = new List<string>();
            //Its like a dynamic Array where items can be added, inserted, removed and sorted along with cloning and many more features. It behaves like dynamic Array.
            basket.Add("Apples");//Adds the item to the bottom of the list..
            basket.Add("Mangoes");
            basket.Add("Oranges");
            basket.Add("Peaches");
            basket.Add("Grapes");
            basket.Insert(3, "Bananas");

            foreach (var item in basket) Console.WriteLine(item);

            Console.WriteLine("The size of the collection is " + basket.Count);

            if (basket.Remove("Apples")) Console.WriteLine("Removed"); else Console.WriteLine("does not exist to remove");
            basket.RemoveAt(3);
            Console.WriteLine("The size of the collection is " + basket.Count);
            for (int i = 0; i < basket.Count; i++)
            {
                Console.WriteLine(basket[i]);
            }
        }
    }
}
