using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        //public override string ToString()
        //{
        //    return string.Format("<h1>Details of Mr.{0}</h1><hr/><p>The Name: {0}</p><p>The Address: {1}</p><p>The Employee's ID: {2}</p>", EmpName, EmpAddress, EmpID);
        //}
    }
}