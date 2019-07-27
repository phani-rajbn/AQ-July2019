using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApp.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult NewPatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPatient(PatientTable patient)
        {
            var context = new PatientDataContext();
            context.PatientTables.InsertOnSubmit(patient);
            context.SubmitChanges();
            return RedirectToAction("Dashboard");
        }

        
        public JsonResult FindDoctors(string id)
        {
            var context = new PatientDataContext();
            var docs = from doc in context.DoctorTables
                       where doc.Speciality == id
                       select new
                       {
                           doc.DoctorID,
                           doc.Doctor,
                           doc.Fees
                       };

            return Json(docs.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Fees(string id)
        {
            var docId = int.Parse(id);
            var context = new PatientDataContext();
            var doc = context.DoctorTables.FirstOrDefault(d => d.DoctorID == docId);
            return Json(doc.Fees, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindInfo()
        {
            return PartialView();
        }
        public JsonResult PId(string id)
        {
            var pId = int.Parse(id);
            var context = new PatientDataContext();
            var patient = context.PatientTables.FirstOrDefault(p => p.PatientID == pId);
            if (patient == null)
            {
                pId = context.PatientTables.Max(p => p.PatientID) + 1;
                var data = new
                {
                    PatientID = pId,
                    PatientName = string.Empty,
                    PatientContact = 0
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = new
                {
                    patient.PatientID,
                    patient.PatientName,
                    patient.PatientContact
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
    }
}