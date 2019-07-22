using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace SampleWebDll
{
    public interface IDBComponent
    {
        void AddProduct(int id, string name, double price, int quantity);
        void UpdateProduct(int id, string name, double price, int quantity);
        DataSet GetAllRecords();
        void DeleteProduct(int id);
    }

    class DisconnectedComponent : IDBComponent
    {
        public readonly string strCon = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        public void AddProduct(int id, string name, double price, int quantity)
        {
            SqlConnection con = new SqlConnection(strCon);
            string strQuery = string.Format("Insert into ProductTable values({0},'{1}',{2},{3})", id, name, price, quantity);
            SqlCommand cmd = new SqlCommand(strQuery, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllRecords()
        {
            var adapter = new SqlDataAdapter("Select * from ProductTable", strCon);
            DataSet ds = new DataSet("SampleData");
            adapter.Fill(ds, "TableOfProducts");//It Opens the closed connection, fills the data and immediately closes the Connection. 
            adapter = new SqlDataAdapter("SELECT * FROM EMPTABLE", strCon);
            adapter.Fill(ds, "TableOfEmployees");
            return ds;
        }

        public void UpdateProduct(int id, string name, double price, int quantity)
        {
            throw new NotImplementedException();
        }
    }

    public static class DBFactory
    {
        public static IDBComponent GetComponent()
        {
            return new DisconnectedComponent();
        }
    }
}
