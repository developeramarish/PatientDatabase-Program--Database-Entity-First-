using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ShowPointAverageLabels = false;
            SelectedSeries = 0;
            IncludeOnlyEligibleValues = true;
            ShowMEDTags = true;
        }
    }
}
