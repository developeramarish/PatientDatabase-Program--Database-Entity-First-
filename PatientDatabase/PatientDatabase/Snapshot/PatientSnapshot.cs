using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public partial class PatientSnapshot : Form
    {
        PatientSnapshotLogic logic;
        Size formStandardSize;
        Size chartStandardSize;
        public PatientSnapshot(Patient patient)
        {
            InitializeComponent();
            logic = new PatientSnapshotLogic(patient);
            formStandardSize = new Size(this.Width, this.Height);
            chartStandardSize = new Size(chartOutcomeData.Width, chartOutcomeData.Height);
        }

        private void PatientSnapshot_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            logic.onFormLoad(panelGeneral, panelChart, panelMedicalData);
            chartOutcomeData.Size = new Size(chartOutcomeData.Width, chartOutcomeData.Height);
        }

        private void PatientSnapshot_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GlobalFormManager.OpenNewForm(new MainMenu(), this);
            GlobalFormManager.CloseCurrentForm(this);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalFormManager.Home(this);
        }

        private void dgvPatientGeneralInfo_SelectionChanged(object sender, EventArgs e)
        {
            dgvPatientGeneralInfo.ClearSelection();
        }

        private void cboProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.ProtocolComboBoxIndexChanged(cboProtocol, cboOutcome, cboEndInterval, chartOutcomeData);
        }

        private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.OutcomeComboBoxIndexChanged(cboOutcome, chartOutcomeData);
        }

        private void cboStartInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.StartIntervalComboBoxIndexChanged(cboStartInterval, chartOutcomeData);
        }

        private void cboEndInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.EndIntervalComboBoxIndexChanged(cboEndInterval, cboStartInterval, chartOutcomeData);
        }

        private void onlyShowStartAndEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.toggleIntervalViewType(chartOutcomeData, onlyShowStartAndEndToolStripMenuItem);
        }

        private void YAxisInterval20toolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.setChartYAxisInterval(20, chartOutcomeData, YAxisInterval20toolStripMenuItem,
               yAxisScaleToolStripMenuItem);
        }

        private void YAxisInterval10toolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.setChartYAxisInterval(10, chartOutcomeData, YAxisInterval10toolStripMenuItem,
               yAxisScaleToolStripMenuItem);
        }

        private void YAxisInterval5toolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.setChartYAxisInterval(5, chartOutcomeData, YAxisInterval5toolStripMenuItem,
               yAxisScaleToolStripMenuItem);
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.toggleChartGridLines(chartOutcomeData, showGridToolStripMenuItem);
        }

        private void StandardWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.changeChartDimensions(new Size(747, chartOutcomeData.Height), chartOutcomeData,
                widthToolStripMenuItem, StandardWidthToolStripMenuItem, panelChartOutline);
        }

        private void LargeWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.changeChartDimensions(new Size(1447, chartOutcomeData.Height), chartOutcomeData,
                widthToolStripMenuItem, LargeWidthToolStripMenuItem, panelChartOutline);
        }

        private void StandardHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.changeChartDimensions(new Size(chartOutcomeData.Width, 409), chartOutcomeData,
                heightToolStripMenuItem, StandardHeightToolStripMenuItem, panelChartOutline);
        }

        private void LargeHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.changeChartDimensions(new Size(chartOutcomeData.Width, 908), chartOutcomeData,
                heightToolStripMenuItem, LargeHeightToolStripMenuItem, panelChartOutline);
        }
    }
}
