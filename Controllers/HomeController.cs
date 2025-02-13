using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Manirajan.Models;

namespace Mission06_Manirajan.Controllers
{
    public class HomeController : Controller
    {

        private MovieCollectionContext _context; // Field

        public HomeController(MovieCollectionContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Author()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Collection()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Collection(Record response)
        {
            _context.Records.Add(response); //Add the record to the database
            _context.SaveChanges(); //Save the changes

            return View("Confirmation", response);
        }

    }
}
