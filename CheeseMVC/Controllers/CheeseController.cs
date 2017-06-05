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

        

        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.cheeses = CheeseData.GetAll();

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
        public IActionResult NewCheese(Cheese newCheese)
        {
            if (!String.IsNullOrEmpty(newCheese.Name))
            {
                CheeseData.Add(newCheese);
            }
            else
            {
                return Redirect("/Cheese/Add?error=true");
            }

            return Redirect("/Cheese");

        }
        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DeleteCheese(int cheeseId)
        {
            // Add new cheese to my existing cheeses

            CheeseData.Remove(cheeseId);

            return Redirect("/Cheese");
        }

        public IActionResult  Edit(int cheeseId)
        {
            ViewBag.cheese = CheeseData.GetById(cheeseId);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int cheeseId, string name, string description)
        {

            if (!String.IsNullOrEmpty(name))
            {
                Cheese oldCheese = CheeseData.GetById(cheeseId);
                oldCheese.Name = name;
                oldCheese.Description = description;
            }
            else
            {
                ViewBag.cheese = CheeseData.GetById(cheeseId);
                ViewBag.error = "You have to name a cheese!";
                return View("Edit");
            }

            return Redirect("/Cheese");
        }
    }
}
