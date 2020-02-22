using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MainFoodRepository
    {
        protected readonly List<MainFood> _mainFoodDirectory = new List<MainFood>();

        public bool AddContentToMainFood(MainFood content)
        {
            int directoryLength = _mainFoodDirectory.Count();
            _mainFoodDirectory.Add(content);
            bool wasAdded = directoryLength + 1 == _mainFoodDirectory.Count();
            return wasAdded;
        }

        public MainFood GetContentByTitle(string mainName)
        {
            foreach (MainFood content in _mainFoodDirectory)
            {
                if (content.MainFoodName.ToLower() == mainName.ToLower())
                {
                    return content;
                }
            }
        }

        public MainFood GetContentByNumber(int menuNumber)
        {
            foreach (MainFood content in _mainFoodDirectory)
                if (content.MenuNumber.ToString() == menuNumber.ToString())
                {
                    return content;
                }
        }

        public bool DeleteExistingMenuItemByName(string mainFood)
        {
            MainFood foundContent = GetContentByTitle(mainFood);
            bool deletedResult = _mainFoodDirectory.Remove(foundContent);
            return deletedResult;
        }
    }
}
