using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Infrastructure;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAddService _addService;
        /*private readonly PersonDBContext _personDBContext;*/

        public HomeController(ILogger<HomeController> logger, IAddService addService)
        {
            _addService = addService;
            _logger = logger;
            /*_personDBContext = personDBContext;*/
        }

        public IActionResult Index()
        {
            PersonModel person = new PersonModel();
            /*person.Name = "Sachin";
            person.Address = "Kanpur";
            person.Marks = 25;
            person.Number = 8303546207;
            _addService.add(person);*/
            return View();
        }

        [HttpPost]
        public IActionResult Index(PersonModel person)
        {
            try
            {
                /*Console.WriteLine(person);*/
                
                person.Name = HttpContext.Request.Form["Name"].ToString();
                person.Number = Convert.ToUInt64(HttpContext.Request.Form["Phone"]);
                person.Address = HttpContext.Request.Form["Address"].ToString();
                person.Marks = Convert.ToUInt64(HttpContext.Request.Form["Number"]);
                _addService.add(person);
                return RedirectToAction("Index");
            }
            catch
            {
                Console.WriteLine("sorry!");
                return View();
            }
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


/*
 
# Create the database object in service's constructor
# By using database object call the add function of the database in the overrided function
# Create an object of service in the contructor of the controller
# Using the service object call the add function of service into endPoint


 */