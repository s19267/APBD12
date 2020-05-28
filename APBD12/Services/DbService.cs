using APBD12.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD12.Services
{
    public class DbService : IDbService
    {
        private s19267Context context;

        public DbService(s19267Context context)
        {
            this.context = context;
        }

        public void DeletePatient(Patient patient)
        {
            var result = context.Patient.FirstOrDefault(e => e.IdPatient == patient.IdPatient);
            context.Patient.Remove(result);
            context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            context.Add(patient);
            context.SaveChanges();
        }

        public Patient GetPatientDetails(Patient patient)
        {
            var result = context.Patient.Include(x => x.Prescription).FirstOrDefault(e => e.IdPatient == patient.IdPatient);                                 
            return result;
        }

        public List<Patient> GetPatients()
        {
            return context.Patient.ToList();
        }
    }
}
