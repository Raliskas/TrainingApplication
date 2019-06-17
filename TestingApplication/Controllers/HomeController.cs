using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingApplication.Models;

namespace TestingApplication.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db;
        public HomeController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NextTestOrFinish()
        {
            return View("TestingPage");
        }
        //[HttpPost]
        //public IActionResult NextTestOrFinish(Remember remember)
        //{
        //    return View("TestingPage");
        //}
        public ViewResult UsersList()
        {
            return View(db.Users.ToList());
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View("CreateUser");
        }
        [HttpPost]
        public string CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return "Пользователь, " + user.FirstName + " сохранён";
        }
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
