using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        static private List<Cheese> cheeses = new List<Cheese>();

        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        public static void Remove(int cheeseId)
        {
            cheeses.RemoveAll(x => x.CheeseId.Equals(cheeseId));
        }

        public static Cheese GetById(int cheeseId)
        {
            return cheeses.Single(x => x.CheeseId == cheeseId);
        }
    }
}
