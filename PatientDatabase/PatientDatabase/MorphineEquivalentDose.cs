using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class MorphineEquivalentDose
    {
        public decimal MED { get; set; }
        public List<PatientMedication> MakeUp { get; set; }

        public MorphineEquivalentDose(decimal med, List<PatientMedication> makeUp)
        {
            MED = med;
            MakeUp = makeUp.OrderBy(pm => pm.Mg).ToList();
        }
    }
}
