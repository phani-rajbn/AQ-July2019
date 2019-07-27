using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientApp.Controllers
{
    public class PatientInfoController : ApiController
    {
        public List<PatientDetails> GetAllPatients(string id)
        {
            var pId = int.Parse(id);
            var context = new PatientDataContext();
            var list = from p in context.PatientTables
                       where p.PatientID == pId
                       orderby p.EntryId descending
                       select new PatientDetails
                       {
                           PatientID = p.PatientID,
                          Name = p.PatientName,
                          Disease =  p.Disease,
                          Doctor = p.DoctorTable.Doctor,
                          Amount= p.Amount
                       };
            return list.ToList();
        }
    }

    public class PatientDetails
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public long Contact { get; set; }
        public string Disease { get; set; }
        public string Doctor { get; set; }
        public int Amount { get; set; }
    }
}
