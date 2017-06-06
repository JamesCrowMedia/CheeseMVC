using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        

        // GET: /<controller>/
        public IActionResult Index()
        {

            List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }

        public IActionResult Add(bool error = false)
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();

            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };
                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
            

            

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
