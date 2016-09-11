using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public abstract class ChartData
    {
        public ChartDataInformation cdi { get; set; }
        public ChartDataSettings cds { get; set; }

        public ChartData()
        {
            cdi = new ChartDataInformation();
            cds = new ChartDataSettings();
        }

        // Loads data into chart 
        public abstract void loadChartData(Chart chart);


        // Resets graph data by clearing all existing series and points
        protected void ClearGraphData(Chart chart)
        {
            chart.Series.Clear();
            foreach (var series in chart.Series) series.Points.Clear();
            chart.ChartAreas[0].AxisX.CustomLabels.Clear();
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

        public abstract void SetUpPointAverageLabels(Chart chart);
    }
}
