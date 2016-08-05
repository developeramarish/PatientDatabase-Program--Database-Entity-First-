using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class PropertyBoolean : Property
    {
        public string[] Choices { get; }

        public PropertyBoolean(string name, bool standardCommand, string[] choices)
            : base(name, standardCommand)
        {
            Choices = choices;
            Criteria = new CriteriaBoolean(Entity, Choices);
        }

        public PropertyBoolean(string name, string entity, bool standardCommand, string[] choices)
            : base(name, entity, standardCommand)
        {
            Choices = choices;
            Criteria = new CriteriaBoolean(Entity, Choices);
        }
    }
}