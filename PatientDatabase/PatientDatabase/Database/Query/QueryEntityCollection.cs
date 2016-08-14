using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class QueryEntityCollection
    {
        public List<QueryEntity> QueryEntities { get; }
        public QueryEntityCollection()
        {
            QueryEntities = new List<QueryEntity>();
        }

        public bool isNameValid(string name, int editQueryIndex)
        {
            if (name == "" || isRepeat(name, editQueryIndex)) return false;           
            else return true;
        }

        private bool isRepeat(string name, int editQueryIndex)
        {
            for (int i = 0; i < QueryEntities.Count; i++)
            {
                if (name == QueryEntities[i].Name && i != editQueryIndex) return true;
            }
            return false;
        }

        public string getDuplicateName(string name)
        {
            int copyNumber = 1;
            while (isRepeat(name + " (" + copyNumber.ToString() + ")", -1)) copyNumber++;
            return name + " (" + copyNumber.ToString() + ")";
        }
    }
}
