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
        public bool ShowInBetweenIntervals { get; set; }
        public int YAxisInterval { get; set; }
        public bool ShowGridLines { get; set; }
        public bool ShowPointAverageLabels { get; set; }
        public int SelectedSeries { get; set; }
        public bool IncludeOnlyEligibleValues { get; set; }
        public SeriesChartType SeriesChartType { get; set; }
        DatabaseAccess database = new DatabaseAccess();

        public ChartData()
        {
            ChartSeries = new List<ChartSeries>();
            Protocols = new List<Protocol>();
            Outcomes = new List<Outcome>();
            Intervals = new List<Interval>();
            StartIntervals = new List<Interval>();
            EndIntervals = new List<Interval>();
            ShowInBetweenIntervals = true;
            YAxisInterval = 20;
            ShowGridLines = true;
            ShowPointAverageLabels = false;
            SelectedSeries = 0;
            IncludeOnlyEligibleValues = true;
            SeriesChartType = SeriesChartType.Line;
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
                //if (i != endInterval) StartIntervals.Add(new Interval(i, intervalLength));
                //if (i != 0) EndIntervals.Add(new Interval(i, intervalLength));
            }
        }

        // Loads all eligible start intervals based on the End Interval (any start interval greater than or equal to end interval is removed)
        public void loadStartIntervals()
        {
            int intervalLength = SelectedProtocol.Interval__Months_;
            int endInterval = SelectedProtocol.End_Interval;
            StartIntervals.Clear();
            for (int i = 0; i < endInterval; i++)
            {
                if (i < SelectedEndInterval.Number)
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
            for (int i = 1; i <= currentHighestInterval; i++)
            {
                EndIntervals.Add(new Interval(i, intervalLength));
            }
        }

        // Loads data into chart 
        public void loadChartData(Chart chart)
        {
            if (ChartSeries.Count > 0)
            {
                ClearGraphData(chart);
                int seriesNumber = 0; // series number out of the series that will be shown
                int queryNumber = 0; // series number out of entire list of series
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
                setUpChartLabels(chart);
                SetUpPointAverageLabels(chart);
            }
        }

        // Resets graph data by clearing all existing series and points
        private void ClearGraphData(Chart chart)
        {
            chart.Series.Clear();
            foreach (var series in chart.Series) series.Points.Clear();
            chart.ChartAreas[0].AxisX.CustomLabels.Clear();
        }

        // Adds new series to chart from the List of chartSeries objects created earlier
        private void AddNewSeries(int seriesNumber, ChartSeries cs, Chart chart)
        {
            chart.Series.Add(new Series());
            chart.Series[seriesNumber].ChartType = SeriesChartType.Line;
            chart.Series[seriesNumber].BorderWidth = 3;
            chart.Series[seriesNumber].LegendText = cs.getName();
        }

        // Graphs points on chart
        private void AddDataToChart(int seriesNumber, ChartSeries cs, Chart chart)
        {
            Dictionary<int, int> points = cs.getPoints(
                SelectedProtocol, SelectedOutcome,
                SelectedStartInterval, SelectedEndInterval, IncludeOnlyEligibleValues);
            foreach (KeyValuePair<int, int> pair in points)
            {
                if (ShowInBetweenIntervals) // plot all points in between start and end intervals as well
                    chart.Series[seriesNumber].Points.AddXY(pair.Key, pair.Value);  
                else // otherwise, ignore all intervals that aren't start and end, and turn end interval to location 1
                {
                    if (pair.Key == SelectedStartInterval.Number)                   
                        chart.Series[seriesNumber].Points.AddXY(pair.Key, pair.Value);                    
                    else if (pair.Key == SelectedEndInterval.Number)                   
                        chart.Series[seriesNumber].Points.AddXY(1, pair.Value);                  
                }
            }
        }

        // Sets the color of line on graph based on the position of the series in the query manager list
        // ensures same series will always have same color line
        private void setSeriesColor(int seriesNumber, int queryNumber, Chart chart)
        {
            chart.Series[seriesNumber].Color = getSeriesColor(queryNumber);
            foreach (DataPoint point in chart.Series[seriesNumber].Points)
            {
                point.Color = chart.Series[seriesNumber].Color;
            }
        }

        // General settings for chart are set here
        private void setChartAreaSettings(Chart chart)
        {
            setGridLines(chart);
            foreach (var areas in chart.ChartAreas) areas.AxisX.CustomLabels.Clear();
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[0].AxisY.Interval = YAxisInterval;
        }

        // shows or hide grid lines on chart
        public void setGridLines(Chart chart)
        {
            if (ShowGridLines)
            {
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            }
            else
            {
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            }
        }

        // Adds custom chart labels to chart (inverval names)
        private void setUpChartLabels(Chart chart)
        {
            double start = -.5 + SelectedStartInterval.Number;
            if (ShowInBetweenIntervals) // show all interval labels in between start and end
            {
                for (int i = SelectedStartInterval.Number; i <= SelectedEndInterval.Number; i++)
                {
                    double end = start + 1;
                    int month = i * SelectedProtocol.Interval__Months_;
                    chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, Intervals[i].getMonthLabel(), 0, LabelMarkStyle.None);
                    start += 1;
                }
            }
            else // show only interval labels start and end
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, SelectedStartInterval.getMonthLabel(), 0, LabelMarkStyle.None);
                chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, SelectedEndInterval.getMonthLabel(), 0, LabelMarkStyle.None);
            }
        }

        // Moves selected chart series in the list of chartSeries up one spot
        public void moveSeriesUp(int selectedIndex, QueryEntityCollection queryEntityCollection)
        {
            ChartSeries temp = ChartSeries[selectedIndex];
            ChartSeries[selectedIndex] = ChartSeries[selectedIndex - 1];
            ChartSeries[selectedIndex - 1] = temp;
        }

        // Moves selected chart series in the list of chartSeries down one spot
        public void moveSeriesDown(int selectedIndex, QueryEntityCollection queryEntityCollection)
        {
            ChartSeries temp = ChartSeries[selectedIndex];
            ChartSeries[selectedIndex] = ChartSeries[selectedIndex + 1];
            ChartSeries[selectedIndex + 1] = temp;
        }

        // gets color of series based on location in query manager
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
        //**** REFACOTR
        public void SetUpPointAverageLabels(Chart chart)
        {
            if (ChartSeries[SelectedSeries].Show)
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Clear();
                setUpChartLabels(chart);
                if (ShowPointAverageLabels)
                {
                    double start = -.5 + SelectedStartInterval.Number;
                    Dictionary<int, int> points = ChartSeries[SelectedSeries].getPoints(SelectedProtocol, SelectedOutcome, SelectedStartInterval, SelectedEndInterval, IncludeOnlyEligibleValues);
                    if (ShowInBetweenIntervals) // show all interval labels in between start and end
                    {
                        for (int i = SelectedStartInterval.Number; i <= SelectedEndInterval.Number; i++)
                        {
                            double end = start + 1;
                            int month = i * SelectedProtocol.Interval__Months_;
                            chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "(" + points[i] + ")", 1, LabelMarkStyle.None);
                            start += 1;
                        }
                    }
                    else // show only interval labels start and end
                    {
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, SelectedStartInterval.getMonthLabel(), 0, LabelMarkStyle.None);
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, SelectedEndInterval.getMonthLabel(), 0, LabelMarkStyle.None);

                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "(" + points[SelectedStartInterval.Number] + ")", 1, LabelMarkStyle.None);
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "(" + points[SelectedEndInterval.Number] + ")", 1, LabelMarkStyle.None);
                    }
                }
            }
            else
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Clear();
                setUpChartLabels(chart);
            }
        }
    }
}
