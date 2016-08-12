using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public partial class Protocol
    {
        public override bool Equals(object obj)
        {
            return this.Id == ((Protocol)obj).Id 
                && this.Name == ((Protocol)obj).Name;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
