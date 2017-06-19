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

        public IActionResult Add()
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
            Cheese fetchedCheese = CheeseData.GetById(cheeseId);

            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel
            {
                Name = fetchedCheese.Name,
                Description = fetchedCheese.Description,
                Type = fetchedCheese.Type,
                CheeseId = fetchedCheese.CheeseId
            };

            return View(addEditCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {

            if (ModelState.IsValid)
            {
                Cheese cheese = CheeseData.GetById(addEditCheeseViewModel.CheeseId);
                cheese.Name = addEditCheeseViewModel.Name;
                cheese.Description = addEditCheeseViewModel.Description;
                cheese.Type = addEditCheeseViewModel.Type;
                   
                return Redirect("/Cheese");
            }

            return View(addEditCheeseViewModel);
        }
    }
}
