using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
//using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Core.Objects.DataClasses;
using LinqKit;

namespace PatientDatabase
{
    public partial class DatabaseAccess
    {
        PatientDatabaseEntities pde;

        public void establishConnection()
        {
            using (pde = new PatientDatabaseEntities())
            {
                Patient patient = pde.Patients.FirstOrDefault();
            }
        }

        public int getTableRecordCount(string table)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (table == "Patient")
                    return pde.Patients.Count();
                else if (table == "Medication")
                    return pde.Medications.Count();
                else if (table == "PastMedicalHistory")
                    return pde.Past_Medical_History.Count();
                else if (table == "Pathology")
                    return pde.Pathologies.Count();
                else if (table == "Problem")
                    return pde.Problems.Count();
                else if (table == "Trauma")
                    return pde.Traumata.Count();
                else if (table == "Treatment")
                    return pde.Treatments.Count();
                else
                    return 0;
            }
        }

        public Patient loadPatient(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == id);
            }
        }

        public Medication loadMedication(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Medications.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Medication> loadMedicationTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Medications.ToList();
                else
                    return pde.Medications.Where(m => m.Name.StartsWith(filter)).OrderBy(m => m.Name).ThenBy(m => m.Type).ToList();
            }
        }

        public Past_Medical_History loadPastMedicalHistory(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Past_Medical_History.FirstOrDefault(p => p.Id == id);
            }
        }

        public Pathology loadPathology(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Pathologies.FirstOrDefault(p => p.Id == id);
            }
        }

        public Problem loadProblem(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Problems.FirstOrDefault(p => p.Id == id);
            }
        }

        public Surgery loadSurgery(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Surgeries.FirstOrDefault(p => p.Id == id);
            }
        }

        public Trauma loadTrauma(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Traumata.FirstOrDefault(p => p.Id == id);
            }
        }

        public Treatment loadTreatment(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Treatments.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<PatientMedication> getPatientMedications(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientMedications.OrderBy(p => p.Medication.Name).ToList();
            }
        }

        public List<PatientPast_Medical_History> getPatientPastMedicalHistory(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientPast_Medical_History.OrderBy(p => p.Past_Medical_History.Name).ToList();
            }
        }

        public List<PatientPathology> getPatientPathology(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientPathologies.OrderBy(p => p.Pathology.Name).ToList();
            }
        }

        public List<PatientProblem> getPatientProblem(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientProblems.OrderBy(p => p.Problem.Name).ToList();
            }
        }

        public List<PatientSurgery> getPatientSurgery(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientSurgeries.OrderBy(p => p.Surgery.Name).ToList();
            }
        }

        public List<PatientTrauma> getPatientTrauma(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientTraumas.OrderBy(p => p.Trauma.Name).ToList();
            }
        }

        public List<PatientTreatment> getPatientTreatment(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientTreatments.OrderBy(p => p.Treatment.Name).ToList();
            }
        }

        public List<Patient> loadPatientsFromQuery(List<Query> queries)
        {
            using (PatientDatabaseEntities pde = new PatientDatabaseEntities())
            {
                IQueryable<Patient> queryBuilder = pde.Set<Patient>();
                var predicate = PredicateBuilder.True<Patient>();
                foreach (Query query in queries)
                {
                    if (query.StandAlone || query.StartGroup)
                    {
                        predicate = PredicateBuilder.True<Patient>();
                        predicate = predicate.And(query.runQuery());
                    }
                    else if (query.ContinueGroup || query.EndGroup)
                    {
                        predicate = predicate.Or(query.runQuery());
                    }
                    if (query.StandAlone || query.EndGroup) queryBuilder = queryBuilder.Where(predicate);
                }
                return queryBuilder.AsExpandable().OrderBy(p => p.Last_Name).ThenBy(p => p.First_Name).ToList();
            }
        }

        [DbFunction("PatientDatabaseModel.Store", "getAge")]
        public int? getAge(DateTime bday, DateTime currentDate)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}
