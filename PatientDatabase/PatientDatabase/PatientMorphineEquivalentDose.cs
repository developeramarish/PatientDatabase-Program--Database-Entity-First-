using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class PatientMorphineEquivalentDose
    {
        public DateTime Date { get; set; }
        public MorphineEquivalentDose MED { get; set; }

        public PatientMorphineEquivalentDose(DateTime date, MorphineEquivalentDose med)
        {
            Date = date;
            MED = med;
        }
    }
}
