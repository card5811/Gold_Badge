using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Challenege
{
    public class Badge
    {
        public Badge() { }
        public int ID { get; set; }
        public List<string> Doors { get; set; }

        public Badge(int id, List<string> doors)
        {
            ID = id;
            Doors = doors;
        }
    }
}
