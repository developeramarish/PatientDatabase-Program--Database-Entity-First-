using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class PropertyInt : Property
    {
        public string NumberType { get; }
        public string Measurement { get; }

        public PropertyInt(string name, bool standardCommand, string numberType, string measurement)
           : base(name, standardCommand)
        {
            this.NumberType = numberType;
            this.Measurement = measurement;
            Criteria = new CriteriaInt(Entity, NumberType, Measurement);
        }

        public PropertyInt(string name, string entity, bool standardCommand, string numberType, string measurement)
            :base(name, entity, standardCommand)
        {
            this.NumberType = numberType;
            this.Measurement = measurement;
            Criteria = new CriteriaInt(Entity, NumberType, Measurement);
        }  
    }
}
