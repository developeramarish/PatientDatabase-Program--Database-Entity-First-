using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public partial class Patient
    {
        DatabaseAccess database = new DatabaseAccess();

        // gets patient age based on their date of birth
        public int getAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Date_of_Birth.Year;

            if (Date_of_Birth > today.AddYears(-age)) age--;
            return age;
        }

        public decimal getMorphineEquivalentDose(Protocol protocol, Interval interval)
        {
            List<PatientMedication> patientMedication = database.getPatientMedications(this)
                .Where(pm => pm.Start_Date <= getIntervalStartDate(protocol, interval)
                && pm.End_Date >= getIntervalEndDate(protocol, interval)).ToList();

            decimal morphineEquivalentDose = 0;
            patientMedication.ForEach(pm =>
                morphineEquivalentDose += (pm.Mg * pm.Medication.Morphine_Equivalent__mg_));
            return morphineEquivalentDose;
        }

        public DateTime getIntervalStartDate(Protocol protocol, Interval interval)
        {
            return database.getPatientProtocol(this).FirstOrDefault(pp => pp.ProtocolID == protocol.Id).Start_Date;
        }

        public DateTime getIntervalEndDate(Protocol protocol, Interval interval)
        {
            return database.getPatientProtocol(this).FirstOrDefault(pp => pp.ProtocolID == protocol.Id).End_Date;
        }
    }
}
