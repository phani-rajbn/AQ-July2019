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

        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                var temp = obj as Employee;
                return temp.Empname == this.Empname;
            }
            else return false;
        }
        //2 objects are said to be equal if their hashcodes are same and the equals method returns true....
        public override int GetHashCode()
        {
            return Empname.GetHashCode();
        }


    }
}
