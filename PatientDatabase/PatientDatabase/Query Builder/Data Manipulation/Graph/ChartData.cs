using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class ChartData
    {
        public List<ChartSeries> ChartSeries { get; set; }

        public ChartData()
        {
            ChartSeries = new List<ChartSeries>();
        }
    }
}
