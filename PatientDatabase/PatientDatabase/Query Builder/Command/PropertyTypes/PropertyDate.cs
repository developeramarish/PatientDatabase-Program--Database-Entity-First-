using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class PropertyDate : Property
    {
        public PropertyDate(string name, bool standardCommand)
            : base(name, standardCommand)
        {
            Criteria = new CriteriaDate(Entity);
        }

        public PropertyDate(string name, string entity, bool standardCommand)
            : base(name, entity, standardCommand)
        {
            Criteria = new CriteriaDate(Entity);
        }

    }
}
