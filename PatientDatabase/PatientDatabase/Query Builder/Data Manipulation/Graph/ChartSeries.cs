using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PatientDatabase
{
    public class ChartSeries
    {
        public string Name { get; set; }
        public List<Query> Queries { get; set; }
        public bool Show { get; set; }
        DatabaseAccess database;

        public ChartSeries(string name, List<Query> queries, bool show)
        {
            Name = name;
            Queries = queries;
            Show = show;
            database = new DatabaseAccess();
        }

        public Dictionary<int, int> getPoints(Protocol selectedProtocol, Outcome selectedOutcome, int startInterval, int endInterval)
        {
            List<Patient> patients = database.loadPatientsFromQuery(Queries);
            Dictionary<int, List<decimal>> allPoints = getAllPoints(selectedProtocol, selectedOutcome, startInterval, endInterval, patients);
            Dictionary<int, int> averagedPoints = getAveragedPoints(allPoints);           
            return averagedPoints;
        }

        private Dictionary<int, List<decimal>> getAllPoints(Protocol selectedProtocol, Outcome selectedOutcome, int startInterval, int endInterval, List<Patient> patients)
        {
            Dictionary<int, List<decimal>> allPoints = new Dictionary<int, List<decimal>>();
            List<PatientOutcome> patientOutcomes;
            foreach (Patient patient in patients)
            {
                patientOutcomes = database.getPatientOutcome(patient);
                patientOutcomes = patientOutcomes.Where(po => po.Protocol.Equals(selectedProtocol)
                && po.Outcome.Equals(selectedOutcome)
                && po.Interval_Number >= startInterval
                && po.Interval_Number <= endInterval).ToList();

                foreach (PatientOutcome po in patientOutcomes)
                {
                    if (!allPoints.ContainsKey(po.Interval_Number)) allPoints.Add(po.Interval_Number, new List<decimal>());
                    allPoints[po.Interval_Number].Add(po.Result);
                }
            }
            return allPoints;
        }

        private Dictionary<int, int> getAveragedPoints(Dictionary<int, List<decimal>> allPoints)
        {
            Dictionary<int, int> points = new Dictionary<int, int>();
            foreach (KeyValuePair<int, List<decimal>> pair in allPoints)
            {
                int interval = pair.Key;
                decimal total = 0;
                pair.Value.ForEach(p => total += p);
                int count = pair.Value.Count;
                decimal average = total / count;
                int roundedAverage = Convert.ToInt32(Math.Round(average, 2));
                points.Add(interval, roundedAverage);
            }
            return points;
        }

        public void toggleShow()
        {
            if (Show) Show = false;
            else Show = true;
        }
    }
}
