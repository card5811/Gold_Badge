using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Challenege
{
    public class Badge_Repo
    {
       protected readonly Dictionary<int, List<string>> _access = new Dictionary<int, List<string>>();
        

        public bool AddToDictionary(int id, Badge badge)
        { 
            int dictionaryLength = _access.Count();
            _access.Add(badge.ID, badge.Doors );
            bool wasAdded = dictionaryLength + 1 == _access.Count();
            return wasAdded;
        }

        public Dictionary<int,List<string>> GetAllContent()
        {
            return _access;
        }

        public List<string> GetContentById(int id)
        {
            _access.TryGetValue(id, out var doors);
            return  doors;
        }

        public bool UpdateExistingContent(Dictionary<int, List<string>>.KeyCollection keys, int originalid, List<string> newAccess)
        {
            var oldAccess = GetContentById(originalid);
            if (oldAccess != null)
            {
                oldAccess = newAccess;
                return true;
            }
            return false;
        }

        public bool DeleteExistingContent(int id)
        {
            List<string> foundItem = GetContentById(id);
            bool deletedResult = _access.Remove(id);
            return deletedResult;
        }
    }
}
