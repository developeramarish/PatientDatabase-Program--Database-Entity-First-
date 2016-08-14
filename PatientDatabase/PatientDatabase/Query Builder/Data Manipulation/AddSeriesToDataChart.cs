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
    public partial class AddSeriesToDataChart : Form
    {
        ChartData chartData;
        public AddSeriesToDataChart(ChartData chartData)
        {
            InitializeComponent();
            this.chartData = chartData;
        }


    }
}
