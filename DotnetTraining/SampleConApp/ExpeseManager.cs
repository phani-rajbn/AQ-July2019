using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ExpenseDemo
{
    class Expense
    {
        public int ExpenseID { get; set; }
        public string Detail { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public void Copy(Expense copy)
        {
            this.ExpenseID = copy.ExpenseID;
            this.Detail = copy.Detail;
            this.Amount = copy.Amount;
            this.Date = copy.Date;
        }

        public override string ToString()
        {
            string details = string.Format("Date:{0}\nDetail:{1}\nAmount:{2:C}\n", Date.ToLongDateString(), Detail, Amount);
            return details;
        }

        public override bool Equals(object obj)
        {
            if(obj is Expense)
            {
                var temp = obj as Expense;
                return temp.ExpenseID == ExpenseID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ExpenseID.GetHashCode() ;
        }
    }

    class ExpenseManager
    {
        private Expense[] _expenses = new Expense[size];

        private const int size = 100;


       
        public virtual void AddNewExpense(Expense ex)
        {
            for (int i = 0; i < size; i++)
            {
                if(_expenses[i] == null)
                {
                    _expenses[i] = new Expense();
                    _expenses[i].Copy(ex);
                    return;
                }
            }
        }

        public virtual Expense[] GetAllExpenses()
        {
            return _expenses;
        }

    }

    class ListExpenseManager : ExpenseManager
    {
        HashSet<Expense> _allExpenes = new HashSet<Expense>();
        public override void AddNewExpense(Expense ex)
        {
            if (!_allExpenes.Add(ex))
                throw new Exception("ExpenseID already Exists");
        }
        public override Expense[] GetAllExpenses()
        {
            var data = _allExpenes.ToArray();
            return data;
        }
    }

    class MainProgram
    {
        private static void clear()
        {
            Console.WriteLine("Press any key to clear");
            Console.ReadKey();
            Console.Clear();
        }
        static ExpenseManager mgr = new ListExpenseManager();
        static void createExpense()
        {
            var expense = new Expense
            {
                ExpenseID = Prompt.GetNumber("Enter the ID of the Expense"),
                Amount = Prompt.GetDouble("Enter the Cost of the Expense"),
                Detail = Prompt.GetString("Enter the Details of the Expense"),
                Date = Prompt.GetDate("Enter the date of Expense as dd/MM/yyyy")
            };
            mgr.AddNewExpense(expense);
        }

        static string getMenu()
        {
            var menu = "~~~~~~~~~~~~~~~~~Expense Manager Software~~~~~~~~~~~~~~~~~~~~~~~\n";
            menu += "TO ADD NEW EXPENSE------------------>PRESS 1\n";
            menu += "TO FIND EXPENSE BY DATE------------->PRESS 2\n";
            menu += "TO FIND EXPENSE BY DETAIL----------->PRESS 3\n";
            menu += "PS:Any other key is considered as EXIT";
            return menu;
        }

        static void Main(string[] args)
        {
            string menu = getMenu();
            do
            {
                string choice = Prompt.GetString(menu);
                switch (choice)
                {
                    case "1":
                        createExpense();
                        break;
                    case "2":
                        readExpensesByDate();
                        break;
                    case "3":
                        readExpensesByDetail();
                        break;
                    default:
                        return;//exit the App....
                }
                clear();
            } while (true);
        }

        private static void readExpensesByDetail()
        {
            var expenses = mgr.GetAllExpenses();
            var detail = Prompt.GetString("Enter the detail to find");
            foreach(var ex in expenses)
            {
                if((ex != null) && ( ex.Detail.Contains(detail)))
                    Console.WriteLine(ex);
            }
        }

        private static void readExpensesByDate()
        {
            var expenses = mgr.GetAllExpenses();
            var selectedDate = Prompt.GetDate("Enter the date to find all expenses");
            foreach(Expense ex in expenses)
            {
                if((ex != null) && (ex.Date.ToString("dd/MM/yyyy") == selectedDate.ToString("dd/MM/yyyy")))
                    Console.WriteLine(ex);                   
            }
        }
    }
}