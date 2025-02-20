using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Manirajan.Models;

namespace Mission06_Manirajan.Controllers
{
    public class HomeController : Controller
    {
        private JoelHiltonMovieCollectionContext _context; // Field

        public HomeController(JoelHiltonMovieCollectionContext temp) // Constructor
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
            ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList(); // Get the categories from the database

            return View();
        }

        [HttpPost]
        public IActionResult Collection(Record response)
        {
            _context.Movies.Add(response); // Add the record to the database
            _context.SaveChanges(); // Save the changes

            return View("Confirmation", response);
        }

        public IActionResult MovieLibrary()
        {
            //Linq
            var movies = _context.Movies
                .OrderBy(x => x.Title).ToList();  // Fetch records as-is

            return View(movies);
        }
    }
}
