using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class DatabaseController : Controller
    {
        public ActionResult AllEmployees()
        {
            MyDataEntities context = new MyDataEntities();
            var modelData = context.EmpTables.ToList();
            return View(modelData);
        }
        public ActionResult Edit(string id)
        {
            MyDataEntities context = new MyDataEntities();
            int empid = int.Parse(id);
            var record = context.EmpTables.FirstOrDefault((emp) => emp.EmpID == empid);
            if(record == null)
            {
                throw new Exception("No Employee found");
            }
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(EmpTable postedData)
        {
            //Create the Context object
            MyDataEntities context = new MyDataEntities();
            //Find the matching record
            var rec = context.EmpTables.FirstOrDefault((e) => e.EmpID == postedData.EmpID);
            //Set the values to the record
            rec.EmpName = postedData.EmpName;
            rec.EmpAddress = postedData.EmpAddress;
            rec.EmpSalary = postedData.EmpSalary;
            rec.EmpPhone = postedData.EmpPhone;
            //Update the record to the database
            context.SaveChanges();//Commmit the transaction....
            //Redirect to the AllEmployees Page....
            return RedirectToAction("AllEmployees");
        }

        public ActionResult AddEmployee()
        {
            return View(new EmpTable());
        }

       
        public ActionResult SaveData(EmpTable emp)
        {
            var context = new MyDataEntities();
            context.EmpTables.Add(emp);
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        public ActionResult Delete(string id)
        {
            MyDataEntities context = new MyDataEntities();
            int empid = int.Parse(id);
            var record = context.EmpTables.FirstOrDefault((emp) => emp.EmpID == empid);
            if (record == null)
            {
                throw new Exception("No Employee found to delete");
            }
            context.EmpTables.Remove(record);
            context.SaveChanges();
            return View("AllEmployees",context.EmpTables.ToList());
        }
    }
}