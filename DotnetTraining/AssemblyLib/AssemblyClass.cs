using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AssemblyLib
{

    [Serializable]
    public class EmployeeDBException : ApplicationException
    {
        public EmployeeDBException() { }
        public EmployeeDBException(string message) : base(message) { }
        public EmployeeDBException(string message, Exception inner) : base(message, inner) { }
    }

    public class AssemblyClass
    {
        public DataTable GetAllEmployees()
        {
            var con = new SqlConnection("Data Source=.;Initial Catalog=AQDB;Integrated Security=True");
            var cmd = new SqlCommand("SELECT * FROM EMPTABLE", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable("Records");
                table.Load(reader);
                return table;
            }
            catch (Exception ex)
            {
                throw new EmployeeDBException("Selection of records failed", ex);
            }
            finally
            {
                con.Close();
            }
        }

        public double AddFunc(double v1, double v2) => v1 + v2;
    }

   
}
