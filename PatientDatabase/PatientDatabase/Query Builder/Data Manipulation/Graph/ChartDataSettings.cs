using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public class ChartDataSettings
    {
        public bool ShowInBetweenIntervals { get; set; }
        public int YAxisInterval { get; set; }
        public bool ShowGridLines { get; set; }
        public bool ShowPointAverageLabels { get; set; }
        public int SelectedSeries { get; set; }
        public bool IncludeOnlyEligibleValues { get; set; }
        public bool ShowMEDTags { get; set; }

        public ChartDataSettings()
        {
            ShowInBetweenIntervals = true;
            YAxisInterval = 20;
            ShowGridLines = true;
            ShowPointAverageLabels = true;
            SelectedSeries = 0;
            IncludeOnlyEligibleValues = true;
            ShowMEDTags = true;
        }

        // sets x axis range for chart depending on what needs to be shown based on chart properties
        public void setAxisXRange(Chart chart, ChartDataInformation cdi)
        {
            if (isMultipleIntervals(cdi) && ShowInBetweenIntervals) // if multiple data points exist
            {
                // set maximum to end interval, minimum to start interval
                chart.ChartAreas[0].AxisX.Maximum = cdi.SelectedEndInterval.Number;
                chart.ChartAreas[0].AxisX.Minimum = cdi.SelectedStartInterval.Number;             
            }
            else if (isMultipleIntervals(cdi) && !ShowInBetweenIntervals) // if only show start and end intervals
            {
                // set maximum to 1 (end interval) and minimum to 0 (start interval)
                chart.ChartAreas[0].AxisX.Maximum = 1;
                chart.ChartAreas[0].AxisX.Minimum = 0;
            }
            else if (!isMultipleIntervals(cdi)) // if only one interval (eg baseline to baseline)
            {
                // sort of "hacky" in order to get the one singular label to format correctly, since setting both the maximum and minimum to zero caused issues with the chart control
                chart.ChartAreas[0].AxisX.Maximum = .5;
                chart.ChartAreas[0].AxisX.Minimum = 0;
            }
        }

        // General settings for chart are set here
        public void setChartAreaSettings(Chart chart)
        {
            setGridLines(chart);
            foreach (var areas in chart.ChartAreas) areas.AxisX.CustomLabels.Clear();
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[0].AxisY.Interval = YAxisInterval;
            chart.Legends[0].MaximumAutoSize = 25;
            chart.Legends[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
    }

        // shows or hide grid lines on chart
        public void setGridLines(Chart chart)
        {
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = ShowGridLines;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = ShowGridLines;
        }

        public bool isMultipleIntervals(ChartDataInformation cdi)
        {
            return cdi.SelectedEndInterval.Number - cdi.SelectedStartInterval.Number != 0;
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
    }
}
