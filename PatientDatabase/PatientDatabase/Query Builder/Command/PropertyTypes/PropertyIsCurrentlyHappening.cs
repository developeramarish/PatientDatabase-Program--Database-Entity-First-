using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class PropertyIsCurrentlyHappening : Property
    {
        public PropertyIsCurrentlyHappening(string name, bool standardCommand)
            : base(name, standardCommand)
        {
            Criteria = new CriteriaIsCurrentlyHappening(Entity);
        }

        public PropertyIsCurrentlyHappening(string name, string entity, bool standardCommand)
            : base(name, entity, standardCommand)
        {
            Criteria = new CriteriaIsCurrentlyHappening(Entity);
        }

    }
}
