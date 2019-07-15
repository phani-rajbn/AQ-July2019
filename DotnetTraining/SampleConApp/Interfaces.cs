using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Sealed Classes and Sealed methods: Do it urself......
/*
 * Interfaces are improvised version of Abstract classes where the interface contain only abstract methods. 
 * It cannot even have fields in it, but it can have properties. 
 * The members are always and only public, so access specifier is mentioned while declaring the interface methods.
 * A Class can implement multiple interfaces at the same level: Multiple interface inheritance. 
 * The class which implements the interface must implement all the methods of the interface, else it should be marked as abstract and the methods should be redeclared as abstract in the implementor class..
 */
namespace SampleConApp
{
    interface IStockMarket
    {
        void AddStock(int id, string name, double amount, int quantity);
        void UpdateStock(int id, string name, double amount, int quantity);
        void DeleteStock(int id);
        DataTable GetAllStocks();
    }

    class StockDBComponent : IStockMarket
    {
        public void AddStock(int id, string name, double amount, int quantity)
        {
            Console.WriteLine("Stock added to the database");
        }

        public void DeleteStock(int id)
        {
            Console.WriteLine("Stock deleted from database");
        }

        public DataTable GetAllStocks()
        {
            return new DataTable("Stocks");
        }

        public void UpdateStock(int id, string name, double amount, int quantity)
        {
            Console.WriteLine("Stock updated");
        }
    }

    class Interfaces
    {
        static void Main(string[] args)
        {
            IStockMarket market = new StockDBComponent();
            try
            {
                market.AddStock(123, "Infosys", 5600, 5000);
                market.AddStock(123, "Infosys", 5600, 5000);
                market.AddStock(123, "Infosys", 5600, 5000);
                market.AddStock(123, "Infosys", 5600, 5000);
                market.DeleteStock(123);
                market.UpdateStock(123, "Infosys", 5600, 5000);
                var table = market.GetAllStocks();
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine(row[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
