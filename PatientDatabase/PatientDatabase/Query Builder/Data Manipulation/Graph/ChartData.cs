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
        public ChartDataInformation cdi { get; set; }
        public ChartDataSettings cds { get; set; }

        public ChartData()
        {
            cdi = new ChartDataInformation();
            cds = new ChartDataSettings();
        }

        // Loads data into chart 
        public void loadChartData(Chart chart)
        {
            if (cdi.ChartSeries.Count > 0)
            {
                ClearGraphData(chart);
                int seriesNumber = 0; // series number out of the series that will be shown
                int queryNumber = 0; // series number out of entire list of series
                foreach (ChartSeries cs in cdi.ChartSeries)
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
                setUpMEDTags(chart);
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
            setSeriesChartType(chart, seriesNumber, ChartType.LINE);
            chart.Series[seriesNumber].LegendText = cs.getName();
            chart.Series[seriesNumber].SmartLabelStyle.Enabled = true;
        }

        // sets x axis range for chart depending on what needs to be shown based on chart properties
        private void setAxisXRange(Chart chart)
        {
            if (cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0) // if multiple data points exist
            {
                if (cds.ShowInBetweenIntervals) // all points in between start and end intervals as well
                {
                    // set maximum to end interval, minimum to start interval
                    chart.ChartAreas[0].AxisX.Maximum = cdi.SelectedEndInterval.Number;
                    chart.ChartAreas[0].AxisX.Minimum = cdi.SelectedStartInterval.Number;
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
                cdi.SelectedProtocol, cdi.SelectedOutcome,
                cdi.SelectedStartInterval, cdi.SelectedEndInterval, cds.IncludeOnlyEligibleValues);

            if (points.Count > 0)
            {
                foreach (KeyValuePair<int, int> pair in points)
                {
                    if (cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0) // if multiple data points exist
                    {
                        if (cds.ShowInBetweenIntervals) // plot all points in between start and end intervals as well
                        {
                            chart.Series[seriesNumber].Points.AddXY(pair.Key, pair.Value);
                            //chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].Label = "MED: " + meds[pair.Key];
                            //chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].LabelBorderColor = Color.Black;
                            //chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].LabelBackColor = Color.White;
                            //chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                        }
                        else // otherwise, ignore all intervals that aren't start and end, and turn end interval to location 1 (start location is always 0)
                        {
                            if (pair.Key == cdi.SelectedStartInterval.Number)
                                chart.Series[seriesNumber].Points.AddXY(0, pair.Value);
                            else if (pair.Key == cdi.SelectedEndInterval.Number)
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

        //private void applyMEDTag(int seriesNumber, ChartSeries cs, Chart chart)
        //{
        //    if (cds.ShowMEDTags)
        //    {
        //        Dictionary<int, int> points = cs.getPoints(
        //            cdi.SelectedProtocol, cdi.SelectedOutcome,
        //            cdi.SelectedStartInterval, cdi.SelectedEndInterval, cds.IncludeOnlyEligibleValues);
        //        if (points.Count > 0)
        //        {
        //            foreach (
        //        }



        //      //  chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].Label =


        //    }
        //}




        // after adding all points in, a specific series may need to be adjusted accordingly (eg changing series into a point graph type, etc...)
        // some stuff in here is a little "hacky" to get the chart to look how I want...sorry future me. I tried documenting the best I can
        private void modifySeriesIfNecessary(Dictionary<int, int> points, Chart chart, int seriesNumber)
        {
            if (cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0) // if start and end interval are not the same (more than one data point to plot)
            {
                // if show all intervals inbetween start and end, and include all values, but the value only has a value of one...
                // this method changes the series to a graph type of POINT and then adds in a "buffer point" to allow it exist at point zero (because for some reason the chart control forces it into point one if it's the only point in a series)
                // without this, the point would not be shown because a line requires two points
                if (cds.ShowInBetweenIntervals && !cds.IncludeOnlyEligibleValues && points.Count == 1)
                {
                    setSeriesChartType(chart, seriesNumber, ChartType.POINT);
                    chart.Series[seriesNumber].Points.AddXY(cdi.SelectedEndInterval.Number, 0);
                    chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
                }
                // similar to above, but this only applies when the only intervals shown are start and end
                // if it can only find one or the other value in a series (start or end), it will plot that point exactly as I did it above
                else if (!cds.ShowInBetweenIntervals
                    && !cds.IncludeOnlyEligibleValues
                    && (points.ContainsKey(cdi.SelectedStartInterval.Number) && !points.ContainsKey(cdi.SelectedEndInterval.Number))
                    || (!points.ContainsKey(cdi.SelectedStartInterval.Number) && points.ContainsKey(cdi.SelectedEndInterval.Number)))
                {
                    setSeriesChartType(chart, seriesNumber, ChartType.POINT);
                    chart.Series[seriesNumber].Points.AddXY(cdi.SelectedStartInterval.Number, 0);
                    chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
                    chart.Series[seriesNumber].Points.AddXY(cdi.SelectedEndInterval.Number, 0);
                    chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
                }
            }
            // if only one interval to plot (eg baseline to baseline), just change the graph type to point and create the "buffer" point to circumvent the glitch where it kept putting singular points in a series at "one" instead at "zero"
            else
            {
                setSeriesChartType(chart, seriesNumber, ChartType.POINT);
                chart.Series[seriesNumber].Points.AddXY(-1, 0);
                chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].MarkerSize = 0;
            }

        }

        // sets series chart type and changes properties accordingly to proper formatting
        private void setSeriesChartType(Chart chart, int seriesNumber, ChartType chartType)
        {
            if (chartType == ChartType.LINE)
            {
                chart.Series[seriesNumber].ChartType = SeriesChartType.Line;
                chart.Series[seriesNumber].BorderWidth = 3;
            }
            else if (chartType == ChartType.POINT)
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
            chart.ChartAreas[0].AxisY.Interval = cds.YAxisInterval;
        }

        // shows or hide grid lines on chart
        public void setGridLines(Chart chart)
        {
            if (cds.ShowGridLines)
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
            if (cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0)
            {
                double start = -.5 + cdi.SelectedStartInterval.Number;
                if (cds.ShowInBetweenIntervals) // show all interval labels in between start and end
                {
                    for (int i = cdi.SelectedStartInterval.Number; i <= cdi.SelectedEndInterval.Number; i++)
                    {
                        double end = start + 1;
                        int month = i * cdi.SelectedProtocol.Interval__Months_;
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, cdi.Intervals[i].getMonthLabel(), 0, LabelMarkStyle.None);
                        start += 1;
                    }
                }
                else // show only interval labels start and end
                {
                    chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, cdi.SelectedStartInterval.getMonthLabel(), 0, LabelMarkStyle.None);
                    chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, cdi.SelectedEndInterval.getMonthLabel(), 0, LabelMarkStyle.None);
                }
            }
            else // if there is only one data point, draw only one label at start
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, cdi.SelectedEndInterval.getMonthLabel(), 0, LabelMarkStyle.None);
            }
        }

        // Moves selected chart series in the list of chartSeries up one spot
        public void moveSeriesUp(int selectedIndex, QueryEntityCollection queryEntityCollection)
        {
            ChartSeries temp = cdi.ChartSeries[selectedIndex];
            cdi.ChartSeries[selectedIndex] = cdi.ChartSeries[selectedIndex - 1];
            cdi.ChartSeries[selectedIndex - 1] = temp;
        }

        // Moves selected chart series in the list of chartSeries down one spot
        public void moveSeriesDown(int selectedIndex, QueryEntityCollection queryEntityCollection)
        {
            ChartSeries temp = cdi.ChartSeries[selectedIndex];
            cdi.ChartSeries[selectedIndex] = cdi.ChartSeries[selectedIndex + 1];
            cdi.ChartSeries[selectedIndex + 1] = temp;
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

        // if ShowPointAverageLabels is true, it shows the selected series' point values as custom labels under the interval labels
        public void SetUpPointAverageLabels(Chart chart)
        {
            if (cdi.ChartSeries[cds.SelectedSeries].Show)
            {
                if (cds.ShowPointAverageLabels)
                {
                    Dictionary<int, int> points = cdi.ChartSeries[cds.SelectedSeries].getPoints(cdi.SelectedProtocol, cdi.SelectedOutcome, cdi.SelectedStartInterval, cdi.SelectedEndInterval, cds.IncludeOnlyEligibleValues);
                    if (cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0)
                    {
                        if (cds.ShowInBetweenIntervals) // show all interval labels in between start and end
                        {
                            double start = -.5 + cdi.SelectedStartInterval.Number;
                            for (int i = cdi.SelectedStartInterval.Number; i <= cdi.SelectedEndInterval.Number; i++)
                            {
                                if (points.ContainsKey(i))
                                {
                                    double end = start + 1;
                                    int month = i * cdi.SelectedProtocol.Interval__Months_;
                                    chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "(" + points[i] + ")", 1, LabelMarkStyle.None);
                                    start += 1;
                                }
                            }
                        }
                        else // show only interval labels start and end
                        {
                            if (points.ContainsKey(cdi.SelectedStartInterval.Number))
                                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "(" + points[cdi.SelectedStartInterval.Number] + ")", 1, LabelMarkStyle.None);
                            if (points.ContainsKey(cdi.SelectedEndInterval.Number))
                                chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "(" + points[cdi.SelectedEndInterval.Number] + ")", 1, LabelMarkStyle.None);
                        }
                    }
                    else
                    {
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "(" + points[cdi.SelectedStartInterval.Number] + ")", 1, LabelMarkStyle.None);
                    }
                }
            }
        }

        public void setUpMEDTags(Chart chart)
        {
            if (cdi.ChartSeries[cds.SelectedSeries].Show)
            {
                if (cds.ShowMEDTags)
                {
                    Dictionary<int, int> meds = cdi.ChartSeries[cds.SelectedSeries].getPatientsIntervalAverageMED(cdi.SelectedProtocol, cdi.SelectedOutcome, cdi.SelectedStartInterval, cdi.SelectedEndInterval, cds.IncludeOnlyEligibleValues);
                    if (cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0)
                    {
                        if (cds.ShowInBetweenIntervals) // show all interval labels in between start and end
                        {
                            double start = -.5 + cdi.SelectedStartInterval.Number;
                            for (int i = cdi.SelectedStartInterval.Number; i <= cdi.SelectedEndInterval.Number; i++)
                            {
                                if (meds.ContainsKey(i))
                                {
                                    double end = start + 1;
                                    int month = i * cdi.SelectedProtocol.Interval__Months_;
                                    chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "MED: " + meds[i], 2, LabelMarkStyle.None);
                                    start += 1;
                                }
                            }
                        }
                        else // show only interval labels start and end
                        {
                            if (meds.ContainsKey(cdi.SelectedStartInterval.Number))
                                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "MED: " + meds[cdi.SelectedStartInterval.Number], 2, LabelMarkStyle.None);
                            if (meds.ContainsKey(cdi.SelectedEndInterval.Number))
                                chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "MED: " + meds[cdi.SelectedEndInterval.Number], 2, LabelMarkStyle.None);
                        }
                    }

                    else
                    {
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "MED: " + meds[cdi.SelectedStartInterval.Number], 2, LabelMarkStyle.None);
                    }

                }
            }

        }
    }
}
