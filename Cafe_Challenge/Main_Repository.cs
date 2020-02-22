using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Challenge
{
    public class Main_Repository
    {

        protected readonly List<MainFood> _Directory = new List<MainFood>();

        //MainFood

        public bool AddContentToMainFood(MainFood content)
        {
            int directoryLength = _Directory.Count();
            _Directory.Add(content);
            bool wasAdded = directoryLength + 1 == _Directory.Count();
            return wasAdded;
        }

        public List<MainFood> GetAllContent()
        {
            return _Directory;
        }

        public MainFood GetFoodByName(string mainName)
        {
            foreach (MainFood content in _Directory)
            {
                if (content.MainFoodName.ToLower() == mainName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public MainFood GetFoodByNumber(int menuNumber)
        {
            foreach (MainFood content in _Directory)
            {
                if (content.MenuNumber == menuNumber)
                    return content;
            }
            return null;
        }

        public bool DeleteExistingContent(string mainName)
        {
            MainFood foundItem = GetFoodByName(mainName);
            bool deleteResult = _Directory.Remove(foundItem);
            return deleteResult;
        }
    }


}
