using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CriteriaOption
    {
        public string Name { get; }
        public bool StandardCommand { get; }

        public CriteriaOption(string name, bool standardCommand)
        {
            Name = name;
            StandardCommand = standardCommand;
        }
    }
}
