using System;
using System.Data.SqlClient;//For SQL server. 
using System.Data.Common;//Interfaces common to all....
using System.Collections.Generic;
using SampleLib;

//USe connected Model to read the records...
namespace SampleConApp
{

    interface IDBComponent
    {
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        List<Employee> GetAllEmployees();
        void DeleteEmployee(int id);
    }

    class EmpDBComponent : IDBComponent
    {
        static SqlConnection con;//for thread safety
        static SqlCommand cmd;
        const string strCon = "Data Source=.;Initial Catalog=AQDB;Integrated Security=True";
        const string strSelect = "Select * from EmpTable";
        const string strInsert = "Insert into EmpTable values(@id, @name, @address, @salary, @phone)";
        const string strupdate = "Update emptable set empname = @name, empAddress = @address, empSalary = @salary, empPhone = @phone where empid = @id";
        const string strDelete = "DELETE FROM EMPTABLE WHERE EMPID = @id";
        public void AddEmployee(Employee emp)
        {
            con = new SqlConnection(strCon);
            cmd = new SqlCommand(strInsert, con);
            cmd.Parameters.AddWithValue("@id", emp.EmpID);
            cmd.Parameters.AddWithValue("@name", emp.Empname);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress );
            cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@phone", emp.PhoneNo);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> _employees = new List<Employee>();
            con = new SqlConnection(strCon);
            cmd = new SqlCommand(strSelect, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var emp = new Employee
                    {
                        EmpID = Convert.ToInt32(reader["EmpID"]),
                        Empname = reader[1].ToString(),
                        EmpAddress = reader[2].ToString(),
                        EmpSalary = Convert.ToDouble(reader[3]),
                        PhoneNo = Convert.ToInt64(reader[4])
                    };
                    _employees.Add(emp);
                }
                return _employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }
    }

    class ConnectedDemo
    {
        const string strCon = "Data Source=.;Initial Catalog=AQDB;Integrated Security=True";
        const string strQuery = "SELECT * FROM EMPTABLE";
        const string strupdate = "Update emptable set empname = @name, empAddress = @address, empSalary = @salary, empPhone = @phone where empid = @id";
        const string strDelete = "DELETE FROM EMPTABLE WHERE EMPID = @id";
        static void Main(string[] args)
        {
            //insertRecord(4, "Gopal", "Chennai", 50000, 2342424556);
            //updateRecord(4, "Gopal", "Madurai", 50000, 2342424556);
            //deleteRecord(4);

            //insertThroDBComponent();
            getRecordsThroDBComponent();
            //viewRecords();

        }

        private static void getRecordsThroDBComponent()
        {
            var records = new EmpDBComponent().GetAllEmployees();
            foreach (Employee emp in records)
                Console.WriteLine(emp);
        }

        private static void insertThroDBComponent()
        {
            IDBComponent com = new EmpDBComponent();
            try
            {
                com.AddEmployee(new Employee
                {
                    EmpID = 6,
                    Empname = "JoyDip Mondal",
                    EmpAddress = "Kolkata",
                    EmpSalary = 40000,
                    PhoneNo = 432475545
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void deleteRecord(int v)
        {
            using(SqlConnection con = new SqlConnection(strCon))
            {
                using(SqlCommand cmd = new SqlCommand(strDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", v);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void updateRecord(int v1, string v2, string v3, int v4, long v5)
        {
            
            using(SqlConnection con = new SqlConnection(strCon))
            {
                var cmd = new SqlCommand(strupdate, con);
                cmd.Parameters.AddWithValue("@name", v2);
                cmd.Parameters.AddWithValue("@address", v3);
                cmd.Parameters.AddWithValue("@salary", v4);
                cmd.Parameters.AddWithValue("@phone", v5);
                cmd.Parameters.AddWithValue("@id", v1);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private static void insertRecord(int v1, string v2, string v3, int v4, uint v5)
        {
            string query = string.Format("Insert into EmpTable values({0},'{1}','{2}',{3},{4})", v1, v2, v3, v4, v5);
            using(SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine("Rows Affected :" + rows);
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if(con.State == System.Data.ConnectionState.Open)
                    con.Close();
                }
            }
        }

        private static void viewRecords()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = strCon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = strQuery;
                try
                {
                    con.Open();
                    var reader = sqlCmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No Rows to read...");
                        return;
                    }
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["EmpName"]);
                        Console.WriteLine(reader["EmpAddress"]);
                        Console.WriteLine(reader[3]);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
