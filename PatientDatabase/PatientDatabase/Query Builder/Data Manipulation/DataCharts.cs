using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public partial class DataCharts : Form
    {
        DatabaseAccess database;
        List<Query> masterQuery;
        List<Protocol> protocols;
        Protocol selectedProtocol;
        List<Outcome> outcomes;
        Outcome selectedOutcome;
        List<int> intervals;
        int selectedStartInterval;
        int selectedEndInterval;
        bool chartLoad = true;
        ChartData chartData;

        public DataCharts(List<Query> queries)
        {
            InitializeComponent();
            database = new DatabaseAccess();
            protocols = new List<Protocol>();
            outcomes = new List<Outcome>();
            intervals = new List<int>();
            chartData = new ChartData();
            masterQuery = queries;
        }

        private void DataCharts_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            chartData.ChartSeries.Add(new ChartSeries("Original Query", masterQuery, true));
            loadSeriesListBox();
            setListBoxSelectedIndex(lstSeries, 0);
            loadProtocols();
            protocols.ForEach(p => cboProtocol.Items.Add(p.Name));
            setComboBoxSelectedIndex(cboProtocol, 0);
        }

        private void setListBoxSelectedIndex(ListBox listbox, int index)
        {
            if (listbox.Items.Count > 0) listbox.SelectedIndex = index;
        }

        private void setComboBoxSelectedIndex(ComboBox comboBox, int index)
        {
            if (comboBox.Items.Count > 0) comboBox.SelectedIndex = index;
        }

        private void DataCharts_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void loadSeriesListBox()
        {
            chartData.ChartSeries.ForEach(cs => lstSeries.Items.Add(cs.Name));
        }

        private void loadProtocols()
        {
            HashSet<Protocol> uniqueProtocols = getUniqueProtocols();
            uniqueProtocols.ToList().ForEach(p => protocols.Add(p));           
        }

        private HashSet<Protocol> getUniqueProtocols()
        {
            HashSet<Protocol> uniqueProtocols = new HashSet<Protocol>();
            List<PatientProtocol> patientProtocols;
            List<Patient> patients = database.loadPatientsFromQuery(masterQuery);
            foreach (Patient patient in patients)
            {
                patientProtocols = database.getPatientProtocol(patient);
                patientProtocols.ForEach(pp => uniqueProtocols.Add(pp.Protocol));
            }
            return uniqueProtocols;
        }

        private void loadOutcomes()
        {
            List<ProtocolOutcome> protocolOutcomes;
            foreach (Protocol protocol in protocols)
            {
                protocolOutcomes = database.getProtocolOutcome(selectedProtocol);
                protocolOutcomes.ForEach(po => outcomes.Add(po.Outcome));
            }
        }

        private void loadIntervals()
        {
            int endInterval = selectedProtocol.End_Interval;
            for (int i = 0; i <= endInterval; i++) intervals.Add(i);
        }

        private void loadIntervalComboBoxes()
        {
            int intervalMonth = selectedProtocol.Interval__Months_;
            foreach (int interval in intervals)
            {
                if (interval == 0)
                {
                    cboStartInterval.Items.Add("Baseline");
                    cboEndInterval.Items.Add("Baseline");
                }
                else
                {
                    cboStartInterval.Items.Add((interval * intervalMonth) + " Months");
                    cboEndInterval.Items.Add((interval * intervalMonth) + " Months");
                }
            }
        }

        private void loadChartData()
        {
            ClearGraphData();
            int seriesNumber = 0;
            foreach (ChartSeries cs in chartData.ChartSeries)
            {
                if (cs.Show)
                {
                    AddNewSeries(seriesNumber);
                    AddDataToChart(seriesNumber, cs);
                    seriesNumber++;
                }
            }
        }

        private void ClearGraphData()
        {
            chartOutcomeData.Series.Clear();
            foreach (var series in chartOutcomeData.Series) series.Points.Clear();
        }

        private void AddNewSeries(int seriesNumber)
        {
            chartOutcomeData.Series.Add(new Series());
            chartOutcomeData.Series[seriesNumber].ChartType = SeriesChartType.Line;
            chartOutcomeData.Series[seriesNumber].BorderWidth = 3;
            chartOutcomeData.Series[seriesNumber].LegendText = lstSeries.SelectedItem.ToString();
        }

        private void AddDataToChart(int seriesNumber, ChartSeries cs)
        {
            Dictionary<int, int> points = cs.getPoints(selectedProtocol, selectedOutcome, selectedStartInterval, selectedEndInterval);
            foreach (KeyValuePair<int, int> pair in points)
            {
                chartOutcomeData.Series[seriesNumber].Points.AddXY(pair.Key, pair.Value);
            }
        }

        private void setUpChartDisplay()
        {
            setChartAreaSettings();
            Dictionary<int, int> points = chartData.ChartSeries[lstSeries.SelectedIndex].getPoints(selectedProtocol, selectedOutcome, selectedStartInterval, selectedEndInterval);
            double start = -.5 + selectedStartInterval;
            for (int i = selectedStartInterval; i <= selectedEndInterval; i++)
            {
                double end = start + 1;
                int month = i * selectedProtocol.Interval__Months_;            
                chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(start, end, getMonthLabel(month), 1, LabelMarkStyle.None);
                if (chartData.ChartSeries[lstSeries.SelectedIndex].Show)
                {
                    chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "(" + points[i] + ")", 2, LabelMarkStyle.None);
                }
                start += 1;
            }
        }

        private void setChartAreaSettings()
        {
            foreach (var areas in chartOutcomeData.ChartAreas) areas.AxisX.CustomLabels.Clear();
            chartOutcomeData.ChartAreas[0].AxisX.IsMarginVisible = false;
            chartOutcomeData.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private string getMonthLabel(int month)
        {
            if (month == 0) return "Baseline";
            else return month + " Months";
        }

        private void cboProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProtocol = protocols[cboProtocol.SelectedIndex];
            chartLoad = false;
            loadOutcomes();
            outcomes.ForEach(o => cboOutcome.Items.Add(o.Name));
            setComboBoxSelectedIndex(cboOutcome, 0);
            loadIntervals();
            loadIntervalComboBoxes();
            setComboBoxSelectedIndex(cboStartInterval, 0);
            setComboBoxSelectedIndex(cboEndInterval, cboEndInterval.Items.Count - 1);
            chartLoad = true;
            loadChart();
        }

        private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOutcome = outcomes[cboOutcome.SelectedIndex];
            loadChart();
        }

        private void cboStartInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStartInterval = intervals[cboStartInterval.SelectedIndex];
            loadChart();
        }

        private void cboEndInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEndInterval = intervals[cboEndInterval.SelectedIndex];
            loadChart();
        }

        private void loadChart()
        {
            if (chartLoad)
            {
                loadChartData();
                setUpChartDisplay();
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            chartData.ChartSeries[lstSeries.SelectedIndex].toggleShow();
            loadChart();
        }
    }
}
