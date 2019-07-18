using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    enum Place { Bangalore, Chennai, Hyderabad, Hubli, Mangalore };
    interface ITicketManager
    {
        void AddTicket(Place destination, Place source, DateTime dateOfJourney, int amount);
        void Modify(int TicketID, Place destination, Place source, DateTime dateOfJourney, int amount);
        double CancelTicket(int ticketId);
        DataTable FindTickets(Place source, Place destination);
        DataTable FindTickets(DateTime dateOfJourney);
    }
    class TicketManager : ITicketManager
    {
        const string fileName = "Data.Bin";

        DataTable table = null;
        public TicketManager()
        {
            table = deSerialize();
            if (table == null)
            {
                table = new DataTable("Tickets");
                //create the table structure...
                table.Columns.Add("TicketID", typeof(int));
                table.Columns.Add("Source", typeof(string));
                table.Columns.Add("Destination", typeof(string));
                table.Columns.Add("Date", typeof(DateTime));
                table.Columns.Add("Amount", typeof(int));
                table.PrimaryKey = new DataColumn[] { table.Columns[0] };
                table.AcceptChanges();
            }
        }
        public void AddTicket(Place destination, Place source, DateTime dateOfJourney, int amount)
        {     
            DataRow row = table.NewRow();//Creates a blank row with the schema of the table cols...
            row[0] = row.Table.Rows.Count + 1;
            row[1] = source;
            row[2] = destination;
            row[3] = dateOfJourney;
            row[4] = amount;
            table.Rows.Add(row);//Add the row to the table's Rows Collection.
            table.AcceptChanges();
            serializeData(table);
        }

        private DataTable deSerialize()
        {
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter fm = new BinaryFormatter();
                    var table = fm.Deserialize(fs) as DataTable;
                    return table;
                }
            }
            return null;
        }
        private void serializeData(DataTable table)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter fm = new BinaryFormatter();
                fm.Serialize(fs, table);
            }
        }

        public double CancelTicket(int ticketId)
        {
            var amount = 0.0;
            table = deSerialize();
            foreach(DataRow row in table.Rows)
            {
                if(row[0].ToString() == ticketId.ToString())
                {
                    amount = Convert.ToDouble(row[4]);
                    amount -= (amount * 15 / 100);
                    row.Delete();//Sets the state as delete.
                    table.AcceptChanges();
                    break;
                }
            }
            serializeData(table);
            return amount;
        }

        public DataTable FindTickets(Place source, Place destination)
        {
            if (table == null)
                table = deSerialize();
            var copy = table.Copy();
            copy.Rows.Clear();//Clears all the rows....
            foreach(DataRow row in table.Rows)
            {
                if((row[1].ToString() == source.ToString()) && (row[2].ToString() == destination.ToString()))
                {
                    DataRow newRow = copy.NewRow();
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        newRow[i] = row[i];
                    }
                    copy.Rows.Add(newRow);
                    copy.AcceptChanges();
                }
            }
            return copy;
        }

        public DataTable FindTickets(DateTime dateOfJourney)
        {
            throw new NotImplementedException();
        }

        public void Modify(int TicketID, Place destination, Place source, DateTime dateOfJourney, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
