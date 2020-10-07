using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Employees
{
    public class BadgeRepo
    {
        public int Num { get; set; }
        public List<string> DrAccess { get; set; }
        public string DisplayDrs(List<string> listOfDoors)
        {
            string doors = string.Join(" & ", listOfDoors);
            return doors;
        }
        public string DisplayDrsWithComma(List<string> listOfDoors)
        {
            string doors = string.Join(" , ", listOfDoors);
            return doors;
        }
        public BadgeRepo()
        {
        }
        public BadgeRepo(int number)
        {
            Num = number;
        }


        public BadgeRepo(int number, List<string> doorAccess)
        {
            Num = number;
            DrAccess = doorAccess;
        }
    }
}
