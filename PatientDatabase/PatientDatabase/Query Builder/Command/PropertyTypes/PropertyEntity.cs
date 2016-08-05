using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class PropertyEntity : Property
    {
        public PropertyEntity(string name, bool standardCommand)
            : base(name, standardCommand)
        {
            Criteria = new CriteriaEntity(Entity);
        }

        public PropertyEntity(string name, string entity, bool standardCommand)
            : base(name, entity, standardCommand)
        {
            Criteria = new CriteriaEntity(Entity);
        }
    }
}
