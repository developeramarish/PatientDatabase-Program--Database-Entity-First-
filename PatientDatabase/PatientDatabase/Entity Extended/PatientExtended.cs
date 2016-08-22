using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public partial class Patient
    {
        // gets patient age based on their date of birth
        public int getAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Date_of_Birth.Year;

            if (Date_of_Birth > today.AddYears(-age)) age--;
            return age;
        }

        //public decimal getMorphineEquivalentDose()
        //{
        //    DatabaseAccess database = new DatabaseAccess();
        //    List<PatientMedication> patientMedication = database.getPatientMedications(this);
        //    decimal morphineEquivalentDose = 0;
        //    patientMedication.ForEach(pm => 
        //        morphineEquivalentDose += (pm.Mg * pm.Medication.Morphine_Equivalent__mg_));
        //    return morphineEquivalentDose;
        //}
    }
}
