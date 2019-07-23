using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class FirstDemoController : Controller
    {
        //Controllers contain methods called Actions. Each Action is a URL Request
        public string FirstAction()
        {
            return "Hello World from ASP.NET MVC";
        }
        //Every response is a string representation of the data that U want to display.....
        public ViewResult FirstEmployee()
        {

            //ViewResult is a class that represents a Result of an Action as a View. ViewResult is derived from an abstract class called  ActionResult. Every Action is expected to return an ActionResult or any of its Derived class objects. 
            var model = new Employee
            {
                EmpID = 123, EmpName ="Phaniraj", EmpAddress ="Bangalore" 
            };
            return View(model);//View expects to inject a Model to display....
        }

        public ViewResult AllEmployees()
        {
            //create an Array of Employee objects hard coded
            var data = new List<Employee>
            {
                new Employee{ EmpID =111, EmpName ="Phaniraj", EmpAddress ="Bangalore"},
                new Employee{ EmpID =112, EmpName ="Vinod Kumar", EmpAddress ="Shimoga"},
                new Employee{ EmpID =113, EmpName ="Gopalrathnam", EmpAddress ="Chennai"},
                new Employee{ EmpID =114, EmpName ="Selvaraj", EmpAddress ="Vellore"},
                new Employee{ EmpID =115, EmpName ="Suraj", EmpAddress ="Hubli"},
                new Employee{ EmpID =116, EmpName ="Sidhartha", EmpAddress ="Bangalore"}
            };
            return View(data);
            //and return View with the Array
        }
    }
}