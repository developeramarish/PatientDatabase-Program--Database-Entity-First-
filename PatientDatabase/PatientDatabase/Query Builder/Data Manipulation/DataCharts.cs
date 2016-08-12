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
        List<Patient> patients;
        List<Patient> filteredPatients;
        List<Query> queries;
        List<List<Query>> filteredQueries;
        DatabaseAccess database;

        List<Protocol> protocols;
        Protocol selectedProtocol;
        List<Outcome> outcomes;
        Outcome selectedOutcome;
        List<int> intervals;
        int selectedStartInterval;
        int selectedEndInterval;
        Dictionary<int, List<decimal>> points;
        Dictionary<int, int> values;


        public DataCharts(List<Patient> patients, List<Query> queries)
        {
            InitializeComponent();
            this.patients = patients;
            this.queries = queries;
            database = new DatabaseAccess();
            filteredQueries = new List<List<Query>>();
            protocols = new List<Protocol>();
            outcomes = new List<Outcome>();
            intervals = new List<int>();
            points = new Dictionary<int, List<decimal>>();
            values = new Dictionary<int, int>();
        }

        private void DataCharts_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            loadProtocolComboBox();
            cboProtocol.SelectedIndex = 0;
            loadOutcomeComboBox();
            cboOutcome.SelectedIndex = 0;
            loadIntervalComboBox();
            cboStartInterval.SelectedIndex = 0;
            cboEndInterval.SelectedIndex = cboEndInterval.Items.Count - 1;


            loadChartData();
            setUpChartDisplay();
        }

        private void DataCharts_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void loadProtocolComboBox()
        {
            HashSet<Protocol> protocolNames = new HashSet<Protocol>();
            List<PatientProtocol> patientProtocols;
            foreach (Patient patient in patients)
            {
                patientProtocols = database.getPatientProtocol(patient);
                patientProtocols.ForEach(pp => protocolNames.Add(pp.Protocol));

            }
            foreach (Protocol protocol in protocolNames)
            {
                protocols.Add(protocol);
                cboProtocol.Items.Add(protocol.Name);
            }
        }

        private void loadOutcomeComboBox()
        {
            HashSet<Outcome> outcomeNames = new HashSet<Outcome>();
            List<ProtocolOutcome> protocolOutcomes;
            foreach (Protocol protocol in protocols)
            {
                protocolOutcomes = database.getProtocolOutcome(selectedProtocol);
                protocolOutcomes.ForEach(po => outcomeNames.Add(po.Outcome));
            }
            foreach (Outcome outcome in outcomeNames)
            {
                outcomes.Add(outcome);
                cboOutcome.Items.Add(outcome.Name);
            }
        }

        private void loadIntervalComboBox()
        {
            int intervalMonth = selectedProtocol.Interval__Months_;
            int endInterval = selectedProtocol.End_Interval;
            for (int i = 0; i <= endInterval; i++)
            {
                intervals.Add(i);
            }
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
            for (int i = selectedStartInterval; i <= selectedEndInterval; i++)
            {
                points.Add(i, new List<decimal>());
            }

            List<PatientOutcome> patientOutcomes;
            foreach (Patient patient in patients)
            {
                patientOutcomes = database.getPatientOutcome(patient);
                patientOutcomes = patientOutcomes.Where(po => po.Protocol.Equals(selectedProtocol)).ToList();
                foreach (PatientOutcome po in patientOutcomes)
                {
                    int interval = po.Interval_Number;
                    decimal result = po.Result;
                    points[interval].Add(result);
                }
            }
           
            foreach (KeyValuePair<int, List<decimal>> pair in points)
            {
                decimal total = 0;
                pair.Value.ForEach(p => total += p);
                int count = pair.Value.Count;
                decimal average = total / count;
                int roundedAverage = Convert.ToInt32(Math.Round(average, 2));
                chartOutcomeData.Series[0].Points.AddXY(pair.Key, roundedAverage);
                values.Add(pair.Key, roundedAverage);
            }
        }

        private void setUpChartDisplay()
        {
            chartOutcomeData.ChartAreas[0].AxisX.IsMarginVisible = false;

            double start = -.5;
            for (int i = selectedStartInterval; i <= selectedEndInterval; i++)
            {
                double end = start + 1;
                int months = i * selectedProtocol.Interval__Months_;
                string monthLabel;
                if (months == 0) monthLabel = "Baseline";
                else monthLabel = months + " Months";
                chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(start, end, monthLabel, 1, LabelMarkStyle.None);
                chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(start, end, "(" + values[i] + ")", 2, LabelMarkStyle.None);
                start += 1;
            }

            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(-.5, 0.5, "Baseline", 1, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(0.5, 1.5, "3 Months", 1, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(1.5, 2.5, "6 Months", 1, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(2.5, 3.5, "9 Months", 1, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(3.5, 4.5, "12 Months", 1, LabelMarkStyle.None);

            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(-.5, 0.5, "(25)", 2, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(0.5, 1.5, "(3)", 2, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(1.5, 2.5, "(2)", 2, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(2.5, 3.5, "(2)", 2, LabelMarkStyle.None);
            //chartOutcomeData.ChartAreas[0].AxisX.CustomLabels.Add(3.5, 4.5, "(1)", 2, LabelMarkStyle.None);

            chartOutcomeData.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private void cboProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProtocol = protocols[cboProtocol.SelectedIndex];
        }

        private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOutcome = outcomes[cboOutcome.SelectedIndex];
        }

        private void cboStartInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStartInterval = intervals[cboStartInterval.SelectedIndex];
        }

        private void cboEndInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEndInterval = intervals[cboEndInterval.SelectedIndex];
        }
    }
}
