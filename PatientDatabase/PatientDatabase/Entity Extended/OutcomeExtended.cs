using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public partial class Outcome
    {
        public override bool Equals(object obj)
        {
            return this.Id == ((Outcome)obj).Id
                && this.Name == ((Outcome)obj).Name;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
