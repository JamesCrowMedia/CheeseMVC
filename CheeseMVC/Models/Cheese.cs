using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

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
