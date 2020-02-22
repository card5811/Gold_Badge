using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class SideFood
    {
        public string SideName { get; set; }
        public string SideDescription { get; set; }
        public string SideIngredients { get; set; }
        public double SidePrice { get; set; }


        public SideFood(string sideName, string sideDescription, string sideIngredients, double sidePrice)
        {
            SideName = sideName;
            SideDescription = sideDescription;
            SideIngredients = sideIngredients;
            SidePrice = sidePrice;
        }
    }
}
