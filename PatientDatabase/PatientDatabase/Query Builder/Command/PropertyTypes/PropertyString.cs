using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class PropertyString : Property
    {
        public PropertyString(string name, bool standardCommand)
            : base(name, standardCommand)
        {
            Criteria = new CriteriaString(Entity);
        }

        public PropertyString(string name, string entity, bool standardCommand)
            : base(name, entity, standardCommand)
        {
            Criteria = new CriteriaString(Entity);
        }


    }
}
