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
        List<Protocol> protocols;
        Protocol selectedProtocol;
        List<Outcome> outcomes;
        Outcome selectedOutcome;
        List<int> intervals;
        int selectedStartInterval;
        int selectedEndInterval;
        bool chartLoad = true;
        ChartData chartData;

        QueryEntityCollection queryEntityCollection;

        public DataCharts(QueryEntityCollection queryEntityCollection)
        {
            InitializeComponent();
            database = new DatabaseAccess();
            protocols = new List<Protocol>();
            outcomes = new List<Outcome>();
            intervals = new List<int>();
            chartData = new ChartData();
            this.queryEntityCollection = queryEntityCollection;
        }

        private void DataCharts_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            loadChartSeries();
            loadSeriesListBox();
            loadProtocols();
            protocols.ForEach(p => cboProtocol.Items.Add(p.Name));
            setComboBoxSelectedIndex(cboProtocol, 0);
            setListBoxSelectedIndex(lstSeries, 0);
        }

        private void loadChartSeries()
        {
            foreach (QueryEntity qe in queryEntityCollection.QueryEntities)
            {
                chartData.ChartSeries.Add(new ChartSeries(qe, false));
            }
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
            lstSeries.Items.Clear();
            chartData.ChartSeries.ForEach(cs => lstSeries.Items.Add(cs.Entity.Name));
        }

        private void loadProtocols()
        {
            HashSet<Protocol> protocolsUnique = new HashSet<Protocol>();
            chartData.ChartSeries.ForEach(cs => protocolsUnique = getUniqueProtocols(cs, protocolsUnique));
            protocolsUnique.ToList().ForEach(p => protocols.Add(p));
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
            int queryNumber = 0;
            foreach (ChartSeries cs in chartData.ChartSeries)
            {
                if (cs.Show)
                {
                    AddNewSeries(seriesNumber, cs);
                    AddDataToChart(seriesNumber, cs);
                    setSeriesColor(seriesNumber, queryNumber);
                    seriesNumber++;
                }
                queryNumber++;
            }
        }

        private void ClearGraphData()
        {
            chartOutcomeData.Series.Clear();
            foreach (var series in chartOutcomeData.Series) series.Points.Clear();
        }

        private void AddNewSeries(int seriesNumber, ChartSeries cs)
        {
            chartOutcomeData.Series.Add(new Series());
            chartOutcomeData.Series[seriesNumber].ChartType = SeriesChartType.Line;
            chartOutcomeData.Series[seriesNumber].BorderWidth = 3;
            chartOutcomeData.Series[seriesNumber].LegendText = cs.Entity.Name.ToString();
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
            double start = -.5 + selectedStartInterval;
            for (int i = selectedStartInterval; i <= selectedEndInterval; i++)
            {
                double end = start + 1;
                int month = i * selectedProtocol.Interval__Months_;            
                chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(start, end, getMonthLabel(month), 1, LabelMarkStyle.None);
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
            if (chartLoad && chartData.ChartSeries.Count > 0)
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

        private void setSeriesColor(int seriesNumber, int queryNumber)
        {
            Color seriesColor = getSeriesColor(queryNumber);
            chartOutcomeData.Series[seriesNumber].Color = seriesColor;
            foreach (DataPoint point in chartOutcomeData.Series[seriesNumber].Points)
            {
                point.Color = seriesColor;
            }
            
        }

        private Color getSeriesColor(int queryNumber)
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

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstSeries.SelectedIndex > 0)
            {
                int selectedIndex = lstSeries.SelectedIndex;
                QueryEntity temp = queryEntityCollection.QueryEntities[selectedIndex];
                queryEntityCollection.QueryEntities[selectedIndex] = queryEntityCollection.QueryEntities[selectedIndex - 1];
                queryEntityCollection.QueryEntities[selectedIndex - 1] = temp;

                ChartSeries temp2 = chartData.ChartSeries[selectedIndex];
                chartData.ChartSeries[selectedIndex] = chartData.ChartSeries[selectedIndex - 1];
                chartData.ChartSeries[selectedIndex - 1] = temp2;

                loadSeriesListBox();
                setListBoxSelectedIndex(lstSeries, selectedIndex - 1);
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstSeries.SelectedIndex < lstSeries.Items.Count - 1)
            {
                int selectedIndex = lstSeries.SelectedIndex;
                QueryEntity temp = queryEntityCollection.QueryEntities[selectedIndex];
                queryEntityCollection.QueryEntities[selectedIndex] = queryEntityCollection.QueryEntities[selectedIndex + 1];
                queryEntityCollection.QueryEntities[selectedIndex + 1] = temp;

                ChartSeries temp2 = chartData.ChartSeries[selectedIndex];
                chartData.ChartSeries[selectedIndex] = chartData.ChartSeries[selectedIndex + 1];
                chartData.ChartSeries[selectedIndex + 1] = temp2;

                loadSeriesListBox();
                setListBoxSelectedIndex(lstSeries, selectedIndex + 1);
            }
        }

        private void lstSeries_DoubleClick(object sender, EventArgs e)
        {
            chartData.ChartSeries[lstSeries.SelectedIndex].toggleShow();
            loadChart();
        }

        private void lstSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtQueryData.Text = queryEntityCollection.QueryEntities[lstSeries.SelectedIndex].entityToString();
            rtxtQueryData.AppendText(Environment.NewLine + Environment.NewLine);
            rtxtQueryData.AppendText(chartData.ChartSeries[lstSeries.SelectedIndex].getDataAnalysis(selectedProtocol, selectedOutcome, selectedStartInterval, selectedEndInterval));
        }
    }
}
