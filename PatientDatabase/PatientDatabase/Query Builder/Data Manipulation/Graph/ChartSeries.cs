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
        public QueryEntity Entity { get; set; }
        public bool Show { get; set; }
        DatabaseAccess database;

        public ChartSeries(QueryEntity entity, bool show)
        {
            Entity = entity;
            Show = show;
            database = new DatabaseAccess();
        }

        public Dictionary<int, int> getPoints(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval)
        {
            Dictionary<int, List<decimal>> allPoints = getAllPoints(selectedProtocol, selectedOutcome, startInterval, endInterval);
            Dictionary<int, int> averagedPoints = getAveragedPoints(allPoints);           
            return averagedPoints;
        }

        private Dictionary<int, List<decimal>> getAllPoints(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval)
        {
            Dictionary<int, List<decimal>> allPoints = new Dictionary<int, List<decimal>>();
            List<PatientOutcome> patientOutcomes;
            List<Patient> patients = Entity.getPatients();

            foreach (Patient patient in patients)
            {
                patientOutcomes = database.getPatientOutcome(patient);
                patientOutcomes = patientOutcomes.Where(po => po.Protocol.Equals(selectedProtocol)
                && po.Outcome.Equals(selectedOutcome)
                && po.Interval_Number >= startInterval.Number
                && po.Interval_Number <= endInterval.Number).ToList();
                if (isPatientEligible(patientOutcomes, endInterval))
                {
                    foreach (PatientOutcome po in patientOutcomes)
                    {
                        if (!allPoints.ContainsKey(po.Interval_Number)) allPoints.Add(po.Interval_Number, new List<decimal>());
                        allPoints[po.Interval_Number].Add(po.Result);
                    }
                }
            }
            return allPoints;
        }

        private bool isPatientEligible(List<PatientOutcome> patientOutcomes, Interval endInterval)
        {
            patientOutcomes.OrderBy(po => po.Interval_Number);
            if (patientOutcomes[patientOutcomes.Count - 1].Interval_Number < endInterval.Number) return false;
            else return true;
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

        public string getDataAnalysis(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<int, List<decimal>> allPoints = getAllPoints(selectedProtocol, selectedOutcome, startInterval, endInterval);
            Dictionary<int, int> averagedPoints = getAveragedPoints(allPoints);
            int interval = selectedProtocol.Interval__Months_;
            foreach (KeyValuePair<int, List<decimal>> pair in allPoints) pair.Value.Sort();
            sb.Append(getMeanString(averagedPoints, interval, startInterval, endInterval))
            .AppendLine()
            .Append(getMedianString(allPoints, interval, startInterval, endInterval))
            .AppendLine()
            .Append(getRangeString(allPoints, interval, startInterval, endInterval))
            .AppendLine()
            .Append(getModeString(allPoints, interval, startInterval, endInterval));
            return sb.ToString().Trim();
        }

        private string getMeanString(Dictionary<int, int> averagedPoints, int interval, Interval startInterval, Interval endInterval)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Mean (Displayed):").AppendLine();
            
            for (int i = startInterval.Number; i <= endInterval.Number; i++)
            {
                sb.Append(getMonthLabel(i, interval) + ": "
                    + getAverage(averagedPoints, i))
                    .AppendLine();
            }
            return sb.ToString();
        }

        private string getAverage(Dictionary<int, int> averagedPoints, int index)
        {
            if (averagedPoints.ContainsKey(index)) return averagedPoints[index].ToString();
            else return "N/A";
        }

        private string getMedianString(Dictionary<int, List<decimal>> allPoints, int interval, Interval startInterval, Interval endInterval)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Median:").AppendLine();
            for (int i = startInterval.Number; i <= endInterval.Number; i++)
            {
                sb.Append(getMonthLabel(i, interval) + ": "
                    + getMedian(allPoints, i))
                    .AppendLine();
            }
            return sb.ToString();
        }

        private string getMedian(Dictionary<int, List<decimal>> allPoints, int index)
        {
            if (allPoints.ContainsKey(index))
            {
                List<decimal> points = allPoints[index];
                int center = getCenterIndex(points.Count);
                if (isOdd(points.Count)) return points[center].ToString();
                else return Math.Round((points[center] + points[center - 1]) / 2, 2).ToString();
            }
            else return "N/A";
        }

        private bool isOdd(int count)
        {
            return count % 2 == 1;
        }

        private int getCenterIndex(int count)
        {
            if (isOdd(count)) return (count - 1) / 2;
            else return count / 2;
        }

        private string getRangeString(Dictionary<int, List<decimal>> allPoints, int interval, Interval startInterval, Interval endInterval)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Range:").AppendLine();
            for (int i = startInterval.Number; i <= endInterval.Number; i++)
            {
                sb.Append(getMonthLabel(i, interval) + ": "
                    + getRangeBounds(allPoints, i))
                    .AppendLine();
            }
            return sb.ToString();
        }

        private string getRangeBounds(Dictionary<int, List<decimal>> allPoints, int index)
        {
            if (allPoints.ContainsKey(index))
            {
                List<decimal> points = allPoints[index];
                return points[0] + " - " + points[points.Count - 1];
            }
            else return "N/A";
        }

        private string getModeString(Dictionary<int, List<decimal>> allPoints, int interval, Interval startInterval, Interval endInterval)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Mode:").AppendLine();
            for (int i = startInterval.Number; i <= endInterval.Number; i++)
            {
                sb.Append(getMonthLabel(i, interval) + ": "
                    + getMode(allPoints, i))
                    .AppendLine();
            }
            return sb.ToString();
        }

        private string getMode(Dictionary<int, List<decimal>> allPoints, int index)
        {
            if (allPoints.ContainsKey(index))
            {
                List<decimal> points = allPoints[index];
                StringBuilder sb = new StringBuilder();
                Dictionary<decimal, int> valueCount = getValueCount(points);
                List<decimal> pointsHighestCount = getPointsHighestCount(valueCount);
                foreach (decimal point in pointsHighestCount) sb.Append(point + " ");
                return sb.ToString().Trim().Replace(" ", ", ");
            }
            else return "N/A";
        }

        private Dictionary<decimal, int> getValueCount(List<decimal> points)
        {
            Dictionary<decimal, int> valueCount = new Dictionary<decimal, int>();
            foreach (decimal point in points)
            {
                if (!valueCount.ContainsKey(point)) valueCount.Add(point, 1);
                else valueCount[point] = valueCount[point] + 1;
            }
            return valueCount;
        }

        private List<decimal> getPointsHighestCount(Dictionary<decimal, int> valueCount)
        {
            int highestCount = 0;
            List<decimal> pointsHighestCount = new List<decimal>();
            foreach (KeyValuePair<decimal, int> pair in valueCount)
            {
                if (pair.Value == highestCount) pointsHighestCount.Add(pair.Key);
                else if (pair.Value > highestCount)
                {
                    pointsHighestCount.Clear();
                    highestCount = pair.Value;
                    pointsHighestCount.Add(pair.Key);
                }
            }
            pointsHighestCount.Sort();
            return pointsHighestCount;
        }

        private string getMonthLabel(int intervalIndex, int interval)
        {
            if (intervalIndex == 0) return "Baseline";
            else return (intervalIndex * interval) + " Months";
        }

        public string getSeriesCount(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval)
        {
            return "Graphed Patients: " + getGraphedPatientsCount(selectedProtocol, selectedOutcome, startInterval, endInterval);
        }

        private int getGraphedPatientsCount(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval)
        {
            int count = 0;
            List<PatientOutcome> patientOutcomes;
            List<Patient> patients = Entity.getPatients();
            foreach (Patient patient in patients)
            {
                patientOutcomes = database.getPatientOutcome(patient);
                patientOutcomes = patientOutcomes.Where(po => po.Protocol.Equals(selectedProtocol)
                && po.Outcome.Equals(selectedOutcome)
                && po.Interval_Number >= startInterval.Number
                && po.Interval_Number <= endInterval.Number).ToList();
                if (isPatientEligible(patientOutcomes, endInterval)) count++;
            }
            return count;
        }
    }
}
