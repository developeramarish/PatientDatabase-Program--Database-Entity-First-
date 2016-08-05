using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CriteriaEntity : Criteria
    {
        public CriteriaEntity(string entity)
            : base(entity)
        {
            criteriaOptions = new CriteriaOption[]
            {
                new CriteriaOption("Is Equal To", true)
            };
        }

        public override int getFilterReqNumber(string criteriaOption)
        {
            return 1;
        }

        public override string getFilterInstructions(string criteriaOption)
        {
            return "Req 1: [" + Entity + " ID] (Use ID Helper)";
        }
    }
}
