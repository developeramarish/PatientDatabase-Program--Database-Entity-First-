using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public class PatientSnapshotLoadCurrentData
    {
        Patient patient;
        DatabaseAccess database;

        public PatientSnapshotLoadCurrentData(Patient patient)
        {
            this.patient = patient;
            database = new DatabaseAccess();
        }

        public void loadMorphineEquivalentDoseCurrent()
        {
            List<PatientMedication> patientMedication = getPatientMedication(true);
            StringBuilder sb = new StringBuilder();
            sb.Append(getMorphineEquivalentDoseString(patientMedication));
        }

        public string getMorphineEquivalentDoseString(List<PatientMedication> patientMedication)
        {
            patientMedication = patientMedication.OrderBy(pm => pm.Start_Date).ToList();
            DateTime startDate = patientMedication[0].Start_Date;
            StringBuilder sb = new StringBuilder();
            sb.Append("MED: ")
                .Append(getMorphineEquivalentDose(patientMedication))
                .Append("mg")
                .AppendLine()
                .Append("Start Date: ")
                .Append(startDate.ToShortDateString());
            return sb.ToString();
        }

        public decimal getMorphineEquivalentDose(List<PatientMedication> patientMedication)
        {
            decimal morphineEquivalentDose = 0;
            patientMedication.ForEach(pm =>
                morphineEquivalentDose += (pm.Mg * pm.Medication.Morphine_Equivalent__mg_));
            return morphineEquivalentDose;
        }


        public void loadMedicationInformationCurrent()
        {
            List<PatientMedication> patientMedication = getPatientMedication(true);
            StringBuilder sb = new StringBuilder();
            patientMedication.ForEach(pm => sb.Append(getPatientMedicationString(pm, true)).AppendLine().AppendLine());
        }

        private string getPatientMedicationString(PatientMedication pm, bool currentOnly)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ")
                .Append(pm.Medication.Name)
                .AppendLine()
                .Append("Amount Taken: ")
                .Append(pm.Mg)
                .Append("mg")
                .AppendLine()
                .Append("Start Date: ")
                .Append(pm.Start_Date.ToShortDateString());
            if (!currentOnly)
                sb.Append("End Date: ")
                .Append(pm.End_Date.ToShortDateString());
            return sb.ToString();
        }

        public List<PatientMedication> getPatientMedication(bool currentOnly)
        {
            if (currentOnly)
                return database.getPatientMedications(patient).Where(pm => pm.End_Date.Equals(DateTime.Parse("12/31/9999"))).ToList();
            else
                return database.getPatientMedications(patient);
        }

        public List<PatientPast_Medical_History> getPatientPastMedicalHistory(bool currentOnly)
        {
            if (currentOnly)
                return database.getPatientPastMedicalHistory(patient).Where(pmh => pmh.End_Date.Equals(DateTime.Parse("12/31/9999"))).ToList();
            else
                return database.getPatientPastMedicalHistory(patient);
        }

        public List<PatientPathology> getPatientPathology(bool currentOnly)
        {
            if (currentOnly)
                return database.getPatientPathology(patient).Where(pp => pp.End_Date.Equals(DateTime.Parse("12/31/9999"))).ToList();
            else
                return database.getPatientPathology(patient);
        }

        public List<PatientProblem> getPatientProblem(bool currentOnly)
        {
            if (currentOnly)
                return database.getPatientProblem(patient).Where(pp => pp.End_Date.Equals(DateTime.Parse("12/31/9999"))).ToList();
            else
                return database.getPatientProblem(patient);
        }

        public List<PatientSurgery> getPatientSurgery(bool currentOnly)
        {
            if (currentOnly)
                return database.getPatientSurgery(patient).Where(ps => ps.End_Date.Equals(DateTime.Parse("12/31/9999"))).ToList();
            else
                return database.getPatientSurgery(patient);
        }

        public List<PatientTrauma> getPatientTrauma(bool currentOnly)
        {
            if (currentOnly)
                return database.getPatientTrauma(patient).Where(pt => pt.End_Date.Equals(DateTime.Parse("12/31/9999"))).ToList();
            else
                return database.getPatientTrauma(patient);
        }
    }
}
