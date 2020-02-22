using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MainFood
    {
        public int MenuNumber { get; set; }
        public string MainFoodName { get; set; }
        public string MainDescription { get; set; }
        public string MainIngredients { get; set; }
        public double MainPrice { get; set; }

        public bool WCheese { get; set; }


        public MainFood(string mainFood, string mainDescription, string mainIngredient, double mainPrice, int menuNumber)
        {
            MenuNumber = menuNumber;
            MainFoodName = mainFood;
            MainDescription = mainDescription;
            MainIngredients = mainIngredient;
            MainPrice = mainPrice;
        }
    }
}
