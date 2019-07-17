using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Employee
    {
        public int EmpID { get; set; }
        public string Empname { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public long PhoneNo { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                var temp = obj as Employee;
                return temp.EmpID == this.EmpID;
            }
            else return false;
        }
        //2 objects are said to be equal if their hashcodes are same and the equals method returns true....
        public override int GetHashCode()
        {
            return EmpID.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format($"Name:{Empname}\tAddress:{EmpAddress}\tEmpSalary:{EmpSalary:C},\tEmpPhone:{PhoneNo}");
        }


    }
}
