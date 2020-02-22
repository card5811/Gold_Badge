using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Challenge
{
    public class MainFood
    {
        public MainFood() { }
        public int MenuNumber { get; set; }
        public string MainFoodName { get; set; }
        public string MainDescription { get; set; }
        public string MainIngredients { get; set; }
        public double MainPrice { get; set; }

        public MainFood(string mainName, string mainDescription, string mainIngredient, double mainPrice, int menuNumber)
        {
            MenuNumber = menuNumber;
            MainFoodName = mainName;
            MainDescription = mainDescription;
            MainIngredients = mainIngredient;
            MainPrice = mainPrice;
        }
    }
}
