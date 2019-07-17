using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            try
            {
                ITicketManager mgr = new TicketManager();
                //mgr.AddTicket(Place.Bangalore, Place.Hyderabad, DateTime.Now.AddDays(-25), 960);
                //Console.WriteLine("Ticket is successfully added");
                var amount = mgr.CancelTicket(2);
                Console.WriteLine("The cancelled amount is " + amount);
                var data = mgr.FindTickets(Place.Hyderabad, Place.Bangalore);
                foreach (DataRow row in data.Rows)
                {
                    Console.WriteLine($"Date:{row[3]}\nSource:{row[1]}\nDestination:{row[2]}\nPrice:{row[4]:C}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
