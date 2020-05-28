using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD12.Models;
using APBD12.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD12.Controllers
{
    public class PatientsController : Controller
    {
        private IDbService service;
        public PatientsController(IDbService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var result = service.GetPatients();
            return View(result);
        }
        public IActionResult GetPatientDetails(Patient patient)
        {
            var result = service.GetPatientDetails(patient);      
            return View(result);
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
                service.AddPatient(patient);
                return View("Add");
        }

        public IActionResult AddPatient()
        {           
            return View();
        }
        public IActionResult DeletePatient(Patient patient)
        {
            service.DeletePatient(patient);
            return View("Removed");
        }
    }
}