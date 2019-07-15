using System;
/*
 * A Class is a User defined reference type that has data and operations to manipulate the data. 
 * Class in C# will have properties, methods and events.
 * Data with accessors are called Properties. 
 * Methods are functions that are usually used to manipulate the data. 
 * Events are actions performed on the object thro CallBack Functions.
 * Class design are based on SOLID Principles of OOP. 
 * When U create a Class, U get a host of features like Inheritance, Polymorphism, Encapsulation and Abstraction. 
 * U can go with struct in C# for smaller versions of these classes.
 * Single Resposibility Principle: One class should do only one job. 
 */

namespace SampleConApp
{

    
    class Employee//A Class that is designed to store the data of a real time entity is called as Entity Class.....
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { private get; set; }
        public int Age
        {
            get
            {
                TimeSpan span = DateTime.Now - DateOfBirth;
                double years = span.Days / 365.25;
                return (int)years;
            }

        }
        public double Salary { get; set; }
    }

    class Stock
    {
        private int _stockID;

        public Stock(int id, double price)
        {
            _stockID = id;
            StockPrice = price;
        }
        public string StockName { get; set; }
        public double StockPrice { get; private set; }
        public void UpdateStockPrice(double amount)
        {
            StockPrice = amount;
        }
        public int Quantity { get; set; } = 100;//New in C# 5.0
    }
    //Repository Classes are those that give and take the data from a storage device like a Database or a File or any stream. 
    class StockMarket
    {
        private Stock[] _stocks = new Stock[100];
        //CRUD operations.....
        public void AddNewStock(Stock stk)
        {
            Console.WriteLine($"{stk.StockName} is Added to the database");
        }

        public void UpdateStock(Stock stk)
        {
            Console.WriteLine($"{stk.StockName} is updated to the database");
        }

        public Stock[] GetAllStocks()
        {
            return _stocks;
        }

        public void DeleteStock(int id)
        {
            Console.WriteLine("The Stock with id {0} is deleted from our database", id);
        }
    }

    class ClassesAndObjects
    {
        static void Main(string[] args)
        {
            //employeeExample();
            //stockBrokerExample();
            marketExample();
        }

       
        private static void marketExample()
        {
            StockMarket bse = new StockMarket();
            bse.AddNewStock(new Stock(213, 650) { StockName ="Infosys", Quantity = 6500 });
            bse.AddNewStock(new Stock(214, 450) { StockName ="Wipro", Quantity = 4500 });
            bse.AddNewStock(new Stock(215, 350) { StockName ="MindTree", Quantity = 6000 });
            bse.AddNewStock(new Stock(216, 1650) { StockName ="Indian Oil", Quantity = 7500 });

            bse.UpdateStock(new Stock(214, 550) { StockName = "Wipro", Quantity = 3500 });
            bse.DeleteStock(215);
        }

        private static void stockBrokerExample()
        {
            Console.WriteLine("Welcome to the brokers to Register their stocks with us");
            Console.WriteLine("Enter the Stock ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price of this stock");
            double price = double.Parse(Console.ReadLine());
            Stock stk = new Stock(id, price);//Object instantiation..
            Console.WriteLine("Please provide few more details before we publish UR stock");
            Console.WriteLine("Enter the name for the stock");
            stk.StockName = Console.ReadLine();

            Console.WriteLine("Enter the Quantity of the stocks");
            stk.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Thanks for registering UR stock, will update further");

            Console.WriteLine("The Stock Name:{0}\nThe Price:{1:C}\nThe Quantity:{2}", stk.StockName, stk.StockPrice, stk.Quantity);
        }

        private static void employeeExample()
        {
            int id = Prompt.GetNumber("Enter the ID of the Employee");

            
            string name = Prompt.GetString("Enter the Name");

            string address = Prompt.GetString("Enter the Address");

            DateTime dob = Prompt.GetDate("Enter the date of birth as dd/MM/yyyy");

            double salary = Prompt.GetDouble("Enter the Salary");

            Employee emp = new Employee//New Object instantiation called Object Initializer
            {
                FullName = name,
                Address = address,
                Salary = salary,
                DateOfBirth = dob,
                ID = id
            };//The variable of the class is called as object. It has to be instantiated using new keyword. Classes are reference types, so they are created inside Managed Heap. It is the place where the object memory is allocated and its address is placed in the object. 

            Console.WriteLine($"The Name entered is {emp.FullName}\nThe Address is {emp.Address}. His Age is {emp.Age} and his salary is {emp.Salary:C}");
        }
    }
    //If U have functions that are repeatedly used in ur program, U could mark the function as static so that I could call the function without creating an object of that class, increases the performance. 
    
}
