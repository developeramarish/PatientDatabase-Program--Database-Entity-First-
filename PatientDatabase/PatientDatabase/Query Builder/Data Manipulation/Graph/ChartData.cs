using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public class ChartData
    {
        public List<ChartSeries> ChartSeries { get; set; }
        public List<Protocol> Protocols { get; set; }
        public Protocol SelectedProtocol { get; set; }
        public List<Outcome> Outcomes { get; set; }
        public Outcome SelectedOutcome { get; set; }
        public List<Interval> Intervals { get; set; }
        public List<Interval> StartIntervals { get; set; }
        public List<Interval> EndIntervals { get; set; }
        public Interval SelectedStartInterval { get; set; }
        public Interval SelectedEndInterval { get; set; }
        DatabaseAccess database = new DatabaseAccess();

        public ChartData()
        {
            ChartSeries = new List<ChartSeries>();
            Protocols = new List<Protocol>();
            Outcomes = new List<Outcome>();
            Intervals = new List<Interval>();
            StartIntervals = new List<Interval>();
            EndIntervals = new List<Interval>();
        }

        public void loadChartSeries(List<QueryEntity> queryEntities)
        {
            ChartSeries.Clear();
            foreach (QueryEntity qe in queryEntities)
            {
                ChartSeries.Add(new ChartSeries(qe, false));
            }
        }

        public void loadProtocols()
        {
            HashSet<Protocol> protocolsUnique = new HashSet<Protocol>();
            ChartSeries.ForEach(cs => protocolsUnique = getUniqueProtocols(cs, protocolsUnique));
            protocolsUnique.ToList().ForEach(p => Protocols.Add(p));
        }

        private HashSet<Protocol> getUniqueProtocols(ChartSeries cs, HashSet<Protocol> protocolsUnique)
        {
            List<PatientProtocol> patientProtocols;
            List<Patient> patients = cs.Entity.getPatients();
            foreach (Patient patient in patients)
            {
                patientProtocols = database.getPatientProtocol(patient);
                patientProtocols.ForEach(pp => protocolsUnique.Add(pp.Protocol));
            }
            return protocolsUnique;
        }

        public void loadOutcomes()
        {
            List<ProtocolOutcome> protocolOutcomes;
            foreach (Protocol protocol in Protocols)
            {
                protocolOutcomes = database.getProtocolOutcome(SelectedProtocol);
                protocolOutcomes.ForEach(po => Outcomes.Add(po.Outcome));
            }
        }

        public void loadIntervals()
        {
            int intervalLength = SelectedProtocol.Interval__Months_;
            int endInterval = SelectedProtocol.End_Interval;
            for (int i = 0; i <= endInterval; i++)
            {
                Intervals.Add(new Interval(i, intervalLength));
                if (i != endInterval) StartIntervals.Add(new Interval(i, intervalLength));
                if (i != 0) EndIntervals.Add(new Interval(i, intervalLength));
            }
        }

        public void loadStartIntervals()
        {
            int intervalLength = SelectedProtocol.Interval__Months_;
            int endInterval = SelectedProtocol.End_Interval;
            StartIntervals.Clear();
            for (int i = 0; i <= endInterval; i++)
            {
                if (i < SelectedEndInterval.Number)
                    StartIntervals.Add(new Interval(i, intervalLength));
            }
        }

        public void loadChartData(Chart chart)
        {
            if (ChartSeries.Count > 0)
            {
                ClearGraphData(chart);
                int seriesNumber = 0;
                int queryNumber = 0;
                foreach (ChartSeries cs in ChartSeries)
                {
                    if (cs.Show)
                    {
                        AddNewSeries(seriesNumber, cs, chart);
                        AddDataToChart(seriesNumber, cs, chart);
                        setSeriesColor(seriesNumber, queryNumber, chart);
                        seriesNumber++;
                    }
                    queryNumber++;
                }
                setChartAreaSettings(chart);
                setUpChartDisplay(chart);
            }
        }

        private void ClearGraphData(Chart chart)
        {
            chart.Series.Clear();
            foreach (var series in chart.Series) series.Points.Clear();
        }

        private void AddNewSeries(int seriesNumber, ChartSeries cs, Chart chart)
        {
            chart.Series.Add(new Series());
            chart.Series[seriesNumber].ChartType = SeriesChartType.Line;
            chart.Series[seriesNumber].BorderWidth = 3;
            chart.Series[seriesNumber].LegendText = cs.Entity.Name.ToString();
        }

        private void AddDataToChart(int seriesNumber, ChartSeries cs, Chart chart)
        {
            Dictionary<int, int> points = cs.getPoints(
                SelectedProtocol, SelectedOutcome,
                SelectedStartInterval, SelectedEndInterval);
            foreach (KeyValuePair<int, int> pair in points)
            {
                chart.Series[seriesNumber].Points.AddXY(pair.Key, pair.Value);
            }
        }

        private void setSeriesColor(int seriesNumber, int queryNumber, Chart chart)
        {
            chart.Series[seriesNumber].Color = getSeriesColor(queryNumber);
            foreach (DataPoint point in chart.Series[seriesNumber].Points)
            {
                point.Color = chart.Series[seriesNumber].Color;
            }
        }

        private void setChartAreaSettings(Chart chart)
        {
            foreach (var areas in chart.ChartAreas) areas.AxisX.CustomLabels.Clear();
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private void setUpChartDisplay(Chart chart)
        {
            double start = -.5 + SelectedStartInterval.Number;
            for (int i = SelectedStartInterval.Number; i <= SelectedEndInterval.Number; i++)
            {
                double end = start + 1;
                int month = i * SelectedProtocol.Interval__Months_;
                chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, Intervals[i].getMonthLabel(), 1, LabelMarkStyle.None);
                start += 1;
            }
        }

        public void moveSeriesUp(int selectedIndex, QueryEntityCollection queryEntityCollection)
        {
            QueryEntity temp = queryEntityCollection.QueryEntities[selectedIndex];
            queryEntityCollection.QueryEntities[selectedIndex] = queryEntityCollection.QueryEntities[selectedIndex - 1];
            queryEntityCollection.QueryEntities[selectedIndex - 1] = temp;

            ChartSeries temp2 = ChartSeries[selectedIndex];
            ChartSeries[selectedIndex] = ChartSeries[selectedIndex - 1];
            ChartSeries[selectedIndex - 1] = temp2;
        }

        public void moveSeriesDown(int selectedIndex, QueryEntityCollection queryEntityCollection)
        {
            QueryEntity temp = queryEntityCollection.QueryEntities[selectedIndex];
            queryEntityCollection.QueryEntities[selectedIndex] = queryEntityCollection.QueryEntities[selectedIndex + 1];
            queryEntityCollection.QueryEntities[selectedIndex + 1] = temp;

            ChartSeries temp2 = ChartSeries[selectedIndex];
            ChartSeries[selectedIndex] = ChartSeries[selectedIndex + 1];
            ChartSeries[selectedIndex + 1] = temp2;
        }

        public Color getSeriesColor(int queryNumber)
        {
            switch (queryNumber)
            {
                case 0: return Color.FromArgb(255, 65, 140, 240);
                case 1: return Color.FromArgb(255, 253, 180, 65);
                case 2: return Color.FromArgb(255, 224, 64, 10);
                case 3: return Color.FromArgb(255, 5, 100, 146);
                case 4: return Color.FromArgb(255, 191, 191, 191);
                case 5: return Color.FromArgb(255, 26, 59, 105);
                case 6: return Color.FromArgb(255, 255, 227, 130);
                case 7: return Color.FromArgb(255, 18, 156, 221);
                case 8: return Color.FromArgb(255, 202, 107, 75);
                case 9: return Color.FromArgb(255, 0, 92, 219);
                case 10: return Color.FromArgb(255, 243, 210, 136);
                case 11: return Color.FromArgb(255, 80, 99, 129);
                case 12: return Color.FromArgb(255, 241, 185, 168);
                case 13: return Color.FromArgb(255, 224, 131, 10);
                case 14: return Color.FromArgb(255, 120, 147, 190);
                default: return Color.Black;
            }
        }
    }
}
