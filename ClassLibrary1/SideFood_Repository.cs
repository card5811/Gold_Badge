using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class SideFoodRepository
    {
        protected readonly List<SideFood> _sideFoodDirectory = new List<SideFood>();

        public bool AddContentToSideFood(SideFood sideContent)
        {
            int directoryLength = _sideFoodDirectory.Count();
            _sideFoodDirectory.Add(sideContent);
            bool wasAdded = directoryLength + 1 == _sideFoodDirectory.Count();
            return wasAdded;
        }

        public SideFood GetContentBySideFoodName(string sideName)
        {
            foreach (SideFood sideContent in _sideFoodDirectory)
            {
                if (sideContent.SideName.ToLower() == sideName.ToLower())
                {
                    return sideContent;
                }
                else
                    Console.WriteLine("Item Not Found.");
            }
        }

        public bool DeleteExistingMenuItemByName(string sideName)
        {
            SideFood foundSideContent = GetContentBySideFoodName(sideName);
            bool deletedResult = _sideFoodDirectory.Remove(foundSideContent);
            return deletedResult;
        }
    }
}
