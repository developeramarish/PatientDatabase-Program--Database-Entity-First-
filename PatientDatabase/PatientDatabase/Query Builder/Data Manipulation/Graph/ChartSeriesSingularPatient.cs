using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class ChartSeriesSingularPatient : ChartSeries
    {
        public ChartSeriesSingularPatient(Patient patient)
            :base(patient)
        {

        }

        public override string getName()
        {
            return "Outcome Data";
        }

        public override List<Patient> getPatients()
        {
            return new List<Patient> { patient };
        }

        public override Dictionary<int, int> getPoints(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval, bool includeOnlyEligibleValues)
        {
            Dictionary<int, int> allPoints = new Dictionary<int, int>();
            List<PatientOutcome> patientOutcomes = database.getPatientOutcome(patient);
            patientOutcomes = patientOutcomes.Where(po => po.Protocol.Equals(selectedProtocol)
            && po.Outcome.Equals(selectedOutcome)
            && po.Interval_Number >= startInterval.Number
            && po.Interval_Number <= endInterval.Number).ToList();
            foreach (PatientOutcome po in patientOutcomes)
            {
                allPoints.Add(po.Interval_Number, (Int32)Math.Round(po.Result, 0));
            }
            return allPoints;
        }
    }
}
