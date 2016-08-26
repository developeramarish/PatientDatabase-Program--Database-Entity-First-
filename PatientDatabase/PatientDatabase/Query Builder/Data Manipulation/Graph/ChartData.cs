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
        public GraphType GraphType { get; set; }
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
            GraphType = GraphType.LINE;
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
                        setSeriesColor(seriesNumber, queryNumber, chart);
                        AddDataToChart(seriesNumber, cs, chart);                       
                        seriesNumber++;
                    }
                    queryNumber++;
                }
                setAxisXRange(chart);
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
            setSeriesChartType(chart, seriesNumber, GraphType);
            chart.Series[seriesNumber].LegendText = cs.getName();
        }

        // sets x axis range for chart depending on what needs to be shown based on chart properties
        private void setAxisXRange(Chart chart)
        {
            if (SelectedEndInterval.Number - SelectedStartInterval.Number != 0) // if multiple data points exist
            {
                if (ShowInBetweenIntervals) // all points in between start and end intervals as well
                {
                    // set maximum to end interval, minimum to start interval
                    chart.ChartAreas[0].AxisX.Maximum = SelectedEndInterval.Number;
                    chart.ChartAreas[0].AxisX.Minimum = SelectedStartInterval.Number;
                }
                else // if only show start and end intervals
                {
                    // set maximum to 1 (end interval) and minimum to 0 (start interval)
                    chart.ChartAreas[0].AxisX.Maximum = 1;
                    chart.ChartAreas[0].AxisX.Minimum = 0;
                }
            }
            else // if only one interval (eg baseline to baseline)
            {
                // sort of "hacky" in order to get the one singular label to format correctly, since setting both the maximum and minimum to zero caused issues with the chart control
                chart.ChartAreas[0].AxisX.Maximum = .5;
                chart.ChartAreas[0].AxisX.Minimum = 0;
            }
        }

        // Graphs points on chart
        private void AddDataToChart(int seriesNumber, ChartSeries cs, Chart chart)
        {
            Dictionary<int, int> points = cs.getPoints(
                SelectedProtocol, SelectedOutcome,
                SelectedStartInterval, SelectedEndInterval, IncludeOnlyEligibleValues);

            if (points.Count > 0)
            {
                foreach (KeyValuePair<int, int> pair in points)
                {
                    if (SelectedEndInterval.Number - SelectedStartInterval.Number != 0) // if multiple data points exist
                    {
                        if (ShowInBetweenIntervals) // plot all points in between start and end intervals as well
                        {
                            chart.Series[seriesNumber].Points.AddXY(pair.Key, pair.Value);
                        }
                        else // otherwise, ignore all intervals that aren't start and end, and turn end interval to location 1 (start location is always 0)
                        {
                            if (pair.Key == SelectedStartInterval.Number)
                                chart.Series[seriesNumber].Points.AddXY(0, pair.Value);
                            else if (pair.Key == SelectedEndInterval.Number)
                                chart.Series[seriesNumber].Points.AddXY(1, pair.Value);
                        }
                    }
                    else // if only one data point exists on graph (ex baseline to baseline), add data point at x location zero
                    {
                        chart.Series[seriesNumber].Points.AddXY(0, pair.Value);
                    }
                }
                modifySeriesIfNecessary(points, chart, seriesNumber);
            }
            else chart.Series[seriesNumber].Color = Color.Transparent; // if no points to plot for series, change legend color to transparent so it does not show
        }

        // after adding all points in, a specific series may need to be adjusted accordingly (eg changing series into a point graph type, etc...)
        // some stuff in here is a little "hacky" to get the chart to look how I want...sorry future me. I tried documenting the best I can
        private void modifySeriesIfNecessary(Dictionary<int, int> points, Chart chart, int seriesNumber)
        {
            if (SelectedEndInterval.Number - SelectedStartInterval.Number != 0) // if start and end interval are not the same (more than one data point to plot)
            {
                // if show all intervals inbetween start and end, and include all values, but the value only has a value of one...
                // this method changes the series to a graph type of POINT and then adds in a "buffer point" to allow it exist at point zero (because for some reason the chart control forces it into point one if it's the only point in a series)
                // without this, the point would not be shown because a line requires two points
                if (ShowInBetweenIntervals && !IncludeOnlyEligibleValues && points.Count == 1)
                {
                    setSeriesChartType(chart, seriesNumber, GraphType.POINT);
                    chart.Series[seriesNumber].Points.AddXY(SelectedEndInterval.Number, 0);
                    chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
                }
                // similar to above, but this only applies when the only intervals shown are start and end
                // if it can only find one or the other value in a series (start or end), it will plot that point exactly as I did it above
                else if (!ShowInBetweenIntervals
                    && !IncludeOnlyEligibleValues
                    && (points.ContainsKey(SelectedStartInterval.Number) && !points.ContainsKey(SelectedEndInterval.Number))
                    || (!points.ContainsKey(SelectedStartInterval.Number) && points.ContainsKey(SelectedEndInterval.Number)))
                {
                    setSeriesChartType(chart, seriesNumber, GraphType.POINT);
                    chart.Series[seriesNumber].Points.AddXY(SelectedStartInterval.Number, 0);
                    chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
                    chart.Series[seriesNumber].Points.AddXY(SelectedEndInterval.Number, 0);
                    chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
                }
            }
            // if only one interval to plot (eg baseline to baseline), just change the graph type to point and create the "buffer" point to circumvent the glitch where it kept putting singular points in a series at "one" instead at "zero"
            else
            {
                setSeriesChartType(chart, seriesNumber, GraphType.POINT);
                chart.Series[seriesNumber].Points.AddXY(-1, 0);
                chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
            }
        }

        // sets series chart type and changes properties accordingly to proper formatting
        private void setSeriesChartType(Chart chart, int seriesNumber, GraphType graphType)
        {
            if (graphType == GraphType.LINE)
            {
                chart.Series[seriesNumber].ChartType = SeriesChartType.Line;
                chart.Series[seriesNumber].BorderWidth = 3;
            }
            else if (graphType == GraphType.POINT)
            {
                chart.Series[seriesNumber].ChartType = SeriesChartType.Point;
                chart.Series[seriesNumber].MarkerStyle = MarkerStyle.Circle;
                chart.Series[seriesNumber].MarkerSize = 10;
            }
        }

        // Sets the color of line on graph based on the position of the series in the query manager list
        // ensures same series will always have same color line
        private void setSeriesColor(int seriesNumber, int queryNumber, Chart chart)
        {
            chart.Series[seriesNumber].Color = getSeriesColor(queryNumber);
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
            if (SelectedEndInterval.Number - SelectedStartInterval.Number != 0)
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
            else // if there is only one data point, draw only one label at start
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, SelectedEndInterval.getMonthLabel(), 0, LabelMarkStyle.None);
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
                    Dictionary<int, int> points = ChartSeries[SelectedSeries].getPoints(SelectedProtocol, SelectedOutcome, SelectedStartInterval, SelectedEndInterval, IncludeOnlyEligibleValues);
                    if (SelectedEndInterval.Number - SelectedStartInterval.Number != 0)
                    {
                        double start = -.5 + SelectedStartInterval.Number;
                        if (ShowInBetweenIntervals) // show all interval labels in between start and end
                        {
                            for (int i = SelectedStartInterval.Number; i <= SelectedEndInterval.Number; i++)
                            {
                                if (points.ContainsKey(i))
                                {
                                    double end = start + 1;
                                    int month = i * SelectedProtocol.Interval__Months_;
                                    chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "(" + points[i] + ")", 1, LabelMarkStyle.None);
                                    start += 1;
                                }
                            }
                        }
                        else // show only interval labels start and end
                        {
                            if (points.ContainsKey(SelectedStartInterval.Number))
                                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "(" + points[SelectedStartInterval.Number] + ")", 1, LabelMarkStyle.None);
                            if (points.ContainsKey(SelectedEndInterval.Number))
                                chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "(" + points[SelectedEndInterval.Number] + ")", 1, LabelMarkStyle.None);
                        }
                    }
                    else
                    {
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "(" + points[SelectedStartInterval.Number] + ")", 1, LabelMarkStyle.None);
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
