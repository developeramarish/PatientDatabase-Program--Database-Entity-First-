using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public abstract class Property
    {
        public string Name { get; }
        public string Entity { get; }
        public bool StandardCommand { get; }
        protected Criteria Criteria;

        public Property(string name, bool standardCommand)
        {
            Name = name;
            Entity = "";
            StandardCommand = standardCommand;
        }

        public Property(string name, string entity, bool standardCommand)
        {
            Name = name;
            Entity = entity;
            StandardCommand = standardCommand;
        }

        public Criteria getCriteria()
        {
            return Criteria;
        }

        public bool enableIDHelper()
        {
            return Entity != "";
        }



    }
}
