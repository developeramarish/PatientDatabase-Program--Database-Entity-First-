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
using System.Data.Entity.Core.Objects.DataClasses;
using LinqKit;

namespace PatientDatabase
{
    public partial class DatabaseAccess
    {
        PatientDatabaseEntities pde;
        public string ConnectionString { get; set; }

        public void establishConnection()
        {
            using (pde = new PatientDatabaseEntities(ConnectionString))
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
                return pde.Medications.FirstOrDefault(m => m.Id == id);
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
                return pde.Past_Medical_History.FirstOrDefault(pmh => pmh.Id == id);
            }
        }

        public List<Past_Medical_History> loadPastMedicalHistoryTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Past_Medical_History.ToList();
                else
                    return pde.Past_Medical_History.Where(pmh => pmh.Name.StartsWith(filter)).OrderBy(pmh => pmh.Name).ToList();
            }
        }

        public Pathology loadPathology(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Pathologies.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Pathology> loadPathologyTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Pathologies.ToList();
                else
                    return pde.Pathologies.Where(p => p.Name.StartsWith(filter)).OrderBy(p => p.Name).ToList();
            }
        }

        public Problem loadProblem(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Problems.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Problem> loadProblemTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Problems.ToList();
                else
                    return pde.Problems.Where(p => p.Name.StartsWith(filter)).OrderBy(p => p.Name).ToList();
            }
        }

        public Surgery loadSurgery(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Surgeries.FirstOrDefault(s => s.Id == id);
            }
        }

        public List<Surgery> loadSurgeryTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Surgeries.ToList();
                else
                    return pde.Surgeries.Where(s => s.Name.StartsWith(filter)).OrderBy(s => s.Name).ToList();
            }
        }

        public Trauma loadTrauma(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Traumata.FirstOrDefault(t => t.Id == id);
            }
        }

        public List<Trauma> loadTraumaTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Traumata.ToList();
                else
                    return pde.Traumata.Where(t => t.Name.StartsWith(filter)).OrderBy(t => t.Name).ToList();
            }
        }

        public Treatment loadTreatment(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Treatments.FirstOrDefault(t => t.Id == id);
            }
        }

        public List<Treatment> loadTreatmentTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Treatments.ToList();
                else
                    return pde.Treatments.Where(t => t.Name.StartsWith(filter)).OrderBy(t => t.Name).ToList();
            }
        }

        public Protocol loadProtocol(int id)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Protocols.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Protocol> loadProtocolTable(string filter)
        {
            using (pde = new PatientDatabaseEntities())
            {
                if (filter == "")
                    return pde.Protocols.ToList();
                else
                    return pde.Protocols.Where(p => p.Name.StartsWith(filter)).OrderBy(t => t.Name).ToList();
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

        public List<PatientProtocol> getPatientProtocol(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientProtocols.OrderBy(p => p.Protocol.Id).ToList();
            }
        }

        public List<PatientOutcome> getPatientOutcome(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Patients.FirstOrDefault(p => p.Id == patient.Id).PatientOutcomes.OrderBy(p => p.Outcome.Id).ThenBy(p => p.Protocol.Id).ToList();
            }
        }

        public PatientImage getPatientImage(Patient patient)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.PatientImages.FirstOrDefault(pi => pi.PatientID == patient.Id);
            }
        }

        public List<ProtocolOutcome> getProtocolOutcome(Protocol protocol)
        {
            using (pde = new PatientDatabaseEntities())
            {
                return pde.Protocols.FirstOrDefault(p => p.Id == protocol.Id).ProtocolOutcomes.OrderBy(p => p.Outcome.Id).ToList();
            }
        }

        public List<Patient> loadPatientsFromQuery(List<Query> queries)
        {
            queries = formatQueriesList(queries);
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

        // applies continue and standalone groups where needed to each query for structuring purposes
        private List<Query> formatQueriesList(List<Query> queries)
        {
            if (queries.Count > 0) queries[0].And = true; // first query MUST be AND otherwise it won't work
            for (int i = 0; i < queries.Count; i++)
            {
                if (queries[i].And && locationExistsInQueriesList(queries, i + 1))
                {
                    if (!queries[i + 1].Or) queries[i].StandAlone = true;
                    else if (queries[i + 1].Or) queries[i].StartGroup = true;
                }
                else if (queries[i].And && !locationExistsInQueriesList(queries, i + 1)) queries[i].StandAlone = true;
                else if (queries[i].Or && locationExistsInQueriesList(queries, i + 1))
                {
                    if (!queries[i + 1].Or) queries[i].EndGroup = true;
                    else if (queries[i + 1].Or) queries[i].ContinueGroup = true;
                }
                else if (queries[i].Or && !locationExistsInQueriesList(queries, i + 1)) queries[i].EndGroup = true;
            }
            return queries;
        }

        private bool locationExistsInQueriesList(List<Query> queries, int index)
        {
            return index >= 0 & index <= queries.Count - 1;
        }

        [DbFunction("PatientDatabaseModel.Store", "getAge")]
        public int? getAge(DateTime bday, DateTime currentDate)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}
