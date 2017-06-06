using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CheeseType Type { get; set; }


        public int CheeseId { get; private set; }
        private static int nextId = 1;

        public Cheese ()
        {
            //Name = name;
            //Description = description;
            CheeseId = nextId;
            nextId++;
        }

    }
}
