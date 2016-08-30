using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class ChartDataInformation
    {
        public List<ChartSeries> ChartSeries { get; set; }

        public List<Protocol> Protocols { get; set; }
        public List<Outcome> Outcomes { get; set; }
        public List<Interval> Intervals { get; set; }
        public List<Interval> StartIntervals { get; set; }
        public List<Interval> EndIntervals { get; set; }

        public Protocol SelectedProtocol { get; set; }
        public Outcome SelectedOutcome { get; set; }
        public Interval SelectedStartInterval { get; set; }
        public Interval SelectedEndInterval { get; set; }
        DatabaseAccess database = new DatabaseAccess();

        public ChartDataInformation()
        {
            ChartSeries = new List<ChartSeries>();
            Protocols = new List<Protocol>();
            Outcomes = new List<Outcome>();
            Intervals = new List<Interval>();
            StartIntervals = new List<Interval>();
            EndIntervals = new List<Interval>();
            database = new DatabaseAccess();
        }

        public void loadChartSeries(Patient patient)
        {
            ChartSeries.Clear();
            ChartSeries.Add(new ChartSeriesSingularPatient(patient));
            ChartSeries[0].Show = true;
        }

        // Creates chartSeries from a list of QueryEntity.
        public void loadChartSeries(List<QueryEntity> queryEntities)
        {
            ChartSeries.Clear();
            foreach (QueryEntity qe in queryEntities)
            {
                ChartSeries.Add(new ChartSeriesQueryEntity(qe, false));
            }
        }

        // Loads all eligible protocols the chart can show data for based on patients returned from each chart series
        public void loadProtocols()
        {
            HashSet<Protocol> protocolsUnique = new HashSet<Protocol>();
            ChartSeries.ForEach(cs => protocolsUnique = getUniqueProtocols(cs, protocolsUnique));
            protocolsUnique.ToList().ForEach(p => Protocols.Add(p));
        }

        // Gets all unique protocols from each chart series to ensure each protocol is only counted once
        private HashSet<Protocol> getUniqueProtocols(ChartSeries cs, HashSet<Protocol> protocolsUnique)
        {
            List<PatientProtocol> patientProtocols;
            List<Patient> patients = cs.getPatients();
            foreach (Patient patient in patients)
            {
                patientProtocols = database.getPatientProtocol(patient);
                patientProtocols.ForEach(pp => protocolsUnique.Add(pp.Protocol));
            }
            return protocolsUnique;
        }

        // Loads all eligible outcome selections based on the selected Protocol.
        public void loadOutcomes()
        {
            List<ProtocolOutcome> protocolOutcomes;
            foreach (Protocol protocol in Protocols)
            {
                protocolOutcomes = database.getProtocolOutcome(SelectedProtocol);
                protocolOutcomes.ForEach(po => Outcomes.Add(po.Outcome));
            }
        }

        // Loads Interval choices based on the selected Protocol.
        public void loadIntervals()
        {
            int intervalLength = SelectedProtocol.Interval__Months_;
            int endInterval = SelectedProtocol.End_Interval;
            for (int i = 0; i <= endInterval; i++)
            {
                Intervals.Add(new Interval(i, intervalLength));
            }
        }

        // Loads all eligible start intervals based on the End Interval (any start interval greater than or equal to end interval is removed)
        public void loadStartIntervals()
        {
            int intervalLength = SelectedProtocol.Interval__Months_;
            int endInterval = SelectedProtocol.End_Interval;
            StartIntervals.Clear();
            for (int i = 0; i <= endInterval; i++)
            {
                if (i <= SelectedEndInterval.Number)
                    StartIntervals.Add(new Interval(i, intervalLength));
            }
        }

        // loads all eligible end intervals based the farthest end interval of all patients in all series
        public void loadEndIntervals()
        {
            int currentHighestInterval = 0;
            foreach (ChartSeries series in ChartSeries)
            {
                List<Patient> patients = series.getPatients();
                foreach (Patient patient in patients)
                {
                    List<PatientOutcome> patientOutcomes = database.getPatientOutcome(patient);
                    foreach (PatientOutcome po in patientOutcomes)
                    {
                        if (po.Interval_Number > currentHighestInterval)
                            currentHighestInterval = po.Interval_Number;
                    }
                }
            }
            int intervalLength = SelectedProtocol.Interval__Months_;
            for (int i = 0; i <= currentHighestInterval; i++)
            {
                EndIntervals.Add(new Interval(i, intervalLength));
            }
        }
    }
}
