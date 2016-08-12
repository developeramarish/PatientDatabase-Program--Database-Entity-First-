using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public partial class PatientDatabaseEntities
    {
        public PatientDatabaseEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}
