using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public class LineGraph : ChartData
    {
        public override void loadChartData(Chart chart)
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
                        Dictionary<int, int> points = getChartSeriesPoints(cs);
                        AddNewSeries(seriesNumber, cs, chart);
                        setSeriesColor(seriesNumber, queryNumber, chart);
                        AddDataToChart(seriesNumber, points, chart);
                        seriesNumber++;
                    }
                    queryNumber++;
                }
                cds.setAxisXRange(chart, cdi);
                cds.setChartAreaSettings(chart);
                setUpChartLabels(chart);
            }
        }

        public override void setUpChartLabels(Chart chart)
        {
            ClearLabelData(chart);
            setUpChartIntervalLabels(chart);
            Dictionary<int, int> selectedSeriesPoints = getChartSeriesPoints(cdi.ChartSeries[cds.SelectedSeries]);
            setUpPointAverageLabels(chart, selectedSeriesPoints);
            setUpMEDTags(chart);
        }

        // Adds new series to chart from the List of chartSeries objects created earlier
        protected void AddNewSeries(int seriesNumber, ChartSeries cs, Chart chart)
        {
            chart.Series.Add(new Series());
            chart.Series[seriesNumber].ChartType = SeriesChartType.Line;
            chart.Series[seriesNumber].BorderWidth = 3;
            chart.Series[seriesNumber].LegendText = cs.getName();
            chart.Series[seriesNumber].SmartLabelStyle.Enabled = true;
            chart.Series[seriesNumber].MarkerStyle = MarkerStyle.Circle;
            chart.Series[seriesNumber].MarkerSize = 22;
        }

        public void AddDataToChart(int seriesNumber, Dictionary<int, int> points, Chart chart)
        {
            if (points.Count > 0)
            {
                // if multiple data points exist and if all intervals from start to end are to be shown
                if (isMultipleIntervals() && cds.ShowInBetweenIntervals)
                {
                    bool gap = false;
                    for (int i = cdi.SelectedStartInterval.Number; i <= cdi.SelectedEndInterval.Number; i++)
                    {
                        if (points.ContainsKey(i))
                        {
                            chart.Series[seriesNumber].Points.AddXY(i, points[i]);
                            if (gap)
                            {
                                // if gap, create dotted line connection
                                chart.Series[seriesNumber].Points[chart.Series[seriesNumber].Points.Count - 1].BorderDashStyle = ChartDashStyle.Dash;
                                gap = false;
                            }
                        }
                        else gap = true;
                    }
                    if (points.Count == 1) chart.Series[seriesNumber].Points.AddXY(-1, 0);
                }
                // if multiple data points exist and only start and end intervals are to be shown
                else if (isMultipleIntervals() && !cds.ShowInBetweenIntervals)
                {
                    if (points.ContainsKey(cdi.SelectedStartInterval.Number))
                    {
                        chart.Series[seriesNumber].Points.AddXY(-1, 0);
                        chart.Series[seriesNumber].Points.AddXY(0, points[cdi.SelectedStartInterval.Number]);
                    }
                    if (points.ContainsKey(cdi.SelectedEndInterval.Number))
                        chart.Series[seriesNumber].Points.AddXY(1, points[cdi.SelectedEndInterval.Number]);
                }
                // if only one data point exists
                else if (!isMultipleIntervals())
                {
                    chart.Series[seriesNumber].Points.AddXY(-1, 0);
                    if (points.ContainsKey(cdi.SelectedStartInterval.Number))
                    {
                        chart.Series[seriesNumber].Points.AddXY(0, points[cdi.SelectedStartInterval.Number]);
                    }
                }
            }
        }

        public bool isMultipleIntervals()
        {
            return cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0;
        }

        // Sets the color of line on graph based on the position of the series in the query manager list
        // ensures same series will always have same color line
        private void setSeriesColor(int seriesNumber, int queryNumber, Chart chart)
        {
            chart.Series[seriesNumber].Color = cds.getSeriesColor(queryNumber);
        }

        // Adds custom chart labels to chart (inverval names)
        private void setUpChartIntervalLabels(Chart chart)
        {
            if (isMultipleIntervals() && cds.ShowInBetweenIntervals)
            {
                double start = -.5 + cdi.SelectedStartInterval.Number;
                for (int i = cdi.SelectedStartInterval.Number; i <= cdi.SelectedEndInterval.Number; i++)
                {
                    double end = start + 1;
                    int month = i * cdi.SelectedProtocol.Interval__Months_;
                    chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, cdi.Intervals[i].getMonthLabel(), 0, LabelMarkStyle.None);
                    start += 1;
                }
            }
            else if (isMultipleIntervals() && cds.ShowInBetweenIntervals) // show only interval labels start and end
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, cdi.SelectedStartInterval.getMonthLabel(), 0, LabelMarkStyle.None);
                chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, cdi.SelectedEndInterval.getMonthLabel(), 0, LabelMarkStyle.None);
            }
            else if (!isMultipleIntervals()) // if there is only one data point, draw only one label at start
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, cdi.SelectedEndInterval.getMonthLabel(), 0, LabelMarkStyle.None);
            }
        }

        // if ShowPointAverageLabels is true, it shows the selected series' point values as custom labels under the interval labels
        public void setUpPointAverageLabels(Chart chart, Dictionary<int, int> points)
        {
            if (cds.ShowPointAverageLabels && cdi.ChartSeries[cds.SelectedSeries].Show)
            {
                if (isMultipleIntervals() && cds.ShowInBetweenIntervals)
                {
                    double start = -.5 + cdi.SelectedStartInterval.Number;
                    for (int i = cdi.SelectedStartInterval.Number; i <= cdi.SelectedEndInterval.Number; i++)
                    {
                        double end = start + 1;
                        if (points.ContainsKey(i))
                        {
                            int month = i * cdi.SelectedProtocol.Interval__Months_;
                            chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "OUT: " + points[i], 1, LabelMarkStyle.None);                            
                        }
                        else
                        {
                            chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "OUT: N/A", 1, LabelMarkStyle.None);
                        }
                        start += 1;
                    }
                }
                else if (isMultipleIntervals() && !cds.ShowInBetweenIntervals) // show only interval labels start and end
                {
                    if (points.ContainsKey(cdi.SelectedStartInterval.Number))
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "OUT: " + points[cdi.SelectedStartInterval.Number], 1, LabelMarkStyle.None);
                    else
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "OUT: N/A", 1, LabelMarkStyle.None);
                    if (points.ContainsKey(cdi.SelectedEndInterval.Number))
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "OUT: " + points[cdi.SelectedEndInterval.Number], 1, LabelMarkStyle.None);
                    else
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "OUT: N/A", 1, LabelMarkStyle.None);
                }
                else if (!isMultipleIntervals())
                {
                    if (points.ContainsKey(cdi.SelectedEndInterval.Number))
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "OUT: " + points[cdi.SelectedStartInterval.Number], 1, LabelMarkStyle.None);
                    else
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "OUT: N/A", 1, LabelMarkStyle.None);
                }

            }
        }

        public void setUpMEDTags(Chart chart)
        {
            if (cds.ShowMEDTags && cdi.ChartSeries[cds.SelectedSeries].Show)
            {
                Dictionary<int, int> meds = cdi.ChartSeries[cds.SelectedSeries].getPatientsIntervalAverageMED(cdi.SelectedProtocol, cdi.SelectedOutcome, cdi.SelectedStartInterval, cdi.SelectedEndInterval, cds.IncludeOnlyEligibleValues);
                if (isMultipleIntervals() && cds.ShowInBetweenIntervals)
                {
                    double start = -.5 + cdi.SelectedStartInterval.Number;
                    for (int i = cdi.SelectedStartInterval.Number; i <= cdi.SelectedEndInterval.Number; i++)
                    {
                        double end = start + 1;
                        if (meds.ContainsKey(i))
                        {
                            int month = i * cdi.SelectedProtocol.Interval__Months_;
                            chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "MED: " + meds[i], 2, LabelMarkStyle.None);
                            
                        }
                        else
                        {
                            chart.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "MED: N/A", 2, LabelMarkStyle.None);
                        }
                        start += 1;
                    }
                }
                else if (isMultipleIntervals() && !cds.ShowInBetweenIntervals) // show only interval labels start and end
                {
                    if (meds.ContainsKey(cdi.SelectedStartInterval.Number))
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "MED: " + meds[cdi.SelectedStartInterval.Number], 2, LabelMarkStyle.None);
                    else
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "MED: N/A", 2, LabelMarkStyle.None);
                    if (meds.ContainsKey(cdi.SelectedEndInterval.Number))
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "MED: " + meds[cdi.SelectedEndInterval.Number], 2, LabelMarkStyle.None);
                    else
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(.5, 1.5, "MED: N/A", 2, LabelMarkStyle.None);
                }
                else if (!isMultipleIntervals())
                {
                    if (meds.ContainsKey(cdi.SelectedEndInterval.Number))
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "MED: " + meds[cdi.SelectedStartInterval.Number], 2, LabelMarkStyle.None);
                    else
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(-.5, .5, "MED: N/A", 2, LabelMarkStyle.None);
                }

            }
            

        }
    }
}
