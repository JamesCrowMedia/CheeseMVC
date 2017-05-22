using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        static private List<Cheese> Cheeses = new List<Cheese>();

        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add(bool error = false)
        {
            if (error)
            {
                ViewBag.error = "You have to name a cheese!";
            }

            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            // Add new cheese to my existing cheeses
            if (!String.IsNullOrEmpty(name))
            {
                Cheese newCheese = new Cheese(name, description);
                Cheeses.Add(newCheese);

                return Redirect("/cheese");
            }
            else
            {
                string error = "Your cheese needs a name";

                return Redirect("/cheese/add?error=True");
            }
        }
        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DeleteCheese(string cheese)
        {
            // Add new cheese to my existing cheeses

            int removeIndex = Cheeses.FindIndex(x => x.Name.Equals(cheese));
            Cheeses.RemoveAt(removeIndex);

            return Redirect("/cheese");
        }
    }
}
