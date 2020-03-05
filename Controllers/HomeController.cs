using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Chefs_Dishes.Models;

namespace Chefs_Dishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext=context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllChefs = dbContext.Chefs.Include(a =>a.CreatedDishes);
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("new");
        }

        [HttpPost("new/chef")]
        public IActionResult NewChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {   
                DateTime Today= DateTime.Now;
                DateTime DOB = newChef.dob;
                int age = Today.Year - DOB.Year;
                newChef.Age = age;    
                dbContext.Chefs.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }



        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.AllDishes = dbContext.Dishes.Include(d => d.Creator);
            return View("dishes");
        }

        [HttpGet("new/dish")]
        public IActionResult NewDish()
        {
            ViewBag.AllChefs = dbContext.Chefs;
            return View ("newdish");
        }

        [HttpPost("add/dish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                ViewBag.AllChefs = dbContext.Chefs;
                return View("NewDish");
            }
        }

    }
}
