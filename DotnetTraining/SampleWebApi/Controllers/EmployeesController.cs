using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    using SampleWebApi.Models;
    public class EmployeesController : ApiController
    {
        public List<EmpExample> GetAllEmployees()
        {
            var context = new WebApiDataContext();
            var data = context.EmpExamples.ToList();
            return data;
        }
        [Route("api/Depts")]
        public List<string> GetAllDepts()
        {
            return new List<string>
            {
                "Sales","Production","InformationServices", "Transport"
            };
        }

        [HttpGet]
        public EmpExample Find(string id)
        {
            var context = new WebApiDataContext();
            var empid = int.Parse(id);
            var selected = context.EmpExamples.FirstOrDefault(e => e.EmpID == empid);
            return selected;
        }

        [HttpPost]
        public string AddEmployee(EmpExample ex)
        {
            try
            {
                var context = new WebApiDataContext();
                context.EmpExamples.InsertOnSubmit(ex);
                context.SubmitChanges();
                return "Employee Inserted Successfully";
            }
            catch (Exception ecp)
            {
                return ecp.Message;
            }
        }

    }
}
