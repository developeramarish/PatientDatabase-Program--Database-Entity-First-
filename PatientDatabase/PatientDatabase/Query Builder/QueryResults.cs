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
    public partial class QueryResults : Form
    {
        List<Patient> patients;
        List<Patient> filteredPatients;
        List<Query> queries;
        List<List<Query>> filteredQueries;
        DatabaseAccess database;
        int tabCount = 0;


        List<DataGridView> dgvQueries;
        

        public QueryResults(List<Patient> patients, List<Query> queries)
        {
            InitializeComponent();
            this.patients = patients;
            this.queries = queries;
            database = new DatabaseAccess();
            dgvQueries = new List<DataGridView>();
            filteredQueries = new List<List<Query>>();
        }

        private void QueryResults_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            LoadDataGridViewCurrentQuery();
            int count = patients.Count;
            int total = database.getTableRecordCount("Patient");
            txtCount.Text = "Returned " + count + " of " + total
                + " Total Patients ----- " + getPercentage(count, total).ToString() + "%";
            
            //  chartOutcomeData.ChartAreas["ChartArea1"].Axes[0].IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            // chartOutcomeData.ChartAreas["ChartArea1"].Axes[0].Interval = 1;

            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.Series["Series1"].Points.AddXY(0, 125);
            chart1.Series["Series1"].Points.AddXY(1, 3);
            chart1.Series["Series1"].Points.AddXY(2, 2);
            chart1.Series["Series1"].Points.AddXY(3, 2);
            chart1.Series["Series1"].Points.AddXY(4, 1);

            chart1.ChartAreas[0].AxisX.CustomLabels.Add(-.5, 0.5, "Baseline", 1, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(0.5, 1.5, "3 Months", 1, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(1.5, 2.5, "6 Months", 1, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(2.5, 3.5, "9 Months", 1, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(3.5, 4.5, "12 Months", 1, LabelMarkStyle.None);

            chart1.ChartAreas[0].AxisX.CustomLabels.Add(-.5, 0.5, "(25)", 2, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(0.5, 1.5, "(3)", 2, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(1.5, 2.5, "(2)", 2, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(2.5, 3.5, "(2)", 2, LabelMarkStyle.None);
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(3.5, 4.5, "(1)", 2, LabelMarkStyle.None);

            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }
        
        private decimal getPercentage(decimal count, decimal total)
        {
            return Math.Round(count / total * 100, 2);
        }

        private void LoadDataGridViewCurrentQuery()
        {
            queries.ForEach(q => dgvCurrentQuery.Rows.Add(q.getGateText(), q.Property, q.Criteria, q.Filter));
            foreach (DataGridViewRow row in dgvCurrentQuery.Rows) row.DefaultCellStyle.BackColor = Color.LightGray;
            MakeDataGridViewAutoSizeHeight(dgvCurrentQuery);
        }

        private void MakeDataGridViewAutoSizeHeight(DataGridView dgv)
        {
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void MakeDataGridViewColumnsNotSortable(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void QueryResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            QueryResultStatistics qrs = new QueryResultStatistics(patients);
            qrs.ShowDialog();
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage();
            tabCount++;
            tabPage.Text = "Filter " + tabCount;
            tabPage.BorderStyle = BorderStyle.FixedSingle;
            tabPage.BackColor = Color.White;

            // Data grid view
            DataGridView dgv = new DataGridView();
            dgvQueries.Add(dgv);
            tabPage.Controls.Add(dgv);
            tbControl.TabPages.Add(tabPage);
            setDataGridViewCurrentQuery(dgv);



        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            int current = tbControl.SelectedIndex;
            if (current != 0)
            {
                tbControl.TabPages.RemoveAt(tbControl.SelectedIndex);
                tbControl.SelectedIndex = current - 1;
            }
        }

        private int getTabLocation(int selectedIndex)
        {
            return selectedIndex - 1;
        }

        private void btnFullView_Click(object sender, EventArgs e)
        {
            //DataCharts dc = new DataCharts(patients);
            //dc.Show();
        }
    }
}
