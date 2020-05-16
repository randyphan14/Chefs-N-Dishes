using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private YourContext dbContext;
        public HomeController(YourContext context)
        {
            dbContext = context;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
                .Include(chef => chef.CreatedDishes)
                .ToList();
            ViewBag.Chefs = AllChefs;
            return View();
        }

        [HttpGet]
        [Route("dishes")]
        public IActionResult ViewDishes()
        {
            List<Dish> AllDishes = dbContext.Dishes
                .Include(dish => dish.Creator)
                .ToList();

            ViewBag.Dishes = AllDishes;
            return View();
        }

        [HttpGet]
        [Route("new")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost]
        [Route("insertchef")]
        public IActionResult InsertChef(Chef user)
        {
            if(ModelState.IsValid)
            {
                if(user.Birthday >= DateTime.Today)
                {
                    ModelState.AddModelError("Birthday", "Date of Birth must be a date from the past");
                    return View("NewChef");
                }

                Chef newChef = new Chef
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Birthday = user.Birthday
                };
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }

        [HttpGet]
        [Route("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(chef => chef.CreatedDishes).ToList();
            ViewBag.Chefs = AllChefs;
            return View();
        }

        [HttpPost]
        [Route("CreateDish")]
        public IActionResult CreateDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
        
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("ViewDishes");
            }
            else
            {
                List<Chef> Allchefs = dbContext.Chefs.ToList();
                ViewBag.Chefs = Allchefs;
                return View("NewDish");
            }
        }
    }
}
