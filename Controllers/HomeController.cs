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

            return View("Collection", new Record());
        }



        [HttpPost]
        public IActionResult Collection(Record response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add the record to the database
                _context.SaveChanges(); // Save the changes

                return View("Confirmation", response);
            }
            else // Invalid Data
            {
                ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList(); // Get the categories from the database

                return View(response);
            }

        }

        public IActionResult MovieLibrary()
        {
            //Linq
            var movies = _context.Movies
                .OrderBy(x => x.Title).ToList();  // Fetch records as-is

            return View(movies);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);


            ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList(); // Get the categories from the database

            return View("Collection", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Record UpdateInfo)
        {
            _context.Movies.Update(UpdateInfo); // Update the record in the database
            _context.SaveChanges(); // Save the changes
            return RedirectToAction("MovieLibrary");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);      
        }

        [HttpPost]
        public IActionResult Delete(Record DeleteInfo)
        {
            _context.Movies.Remove(DeleteInfo); // Remove the record from the database
            _context.SaveChanges(); // Save the changes

            return RedirectToAction("MovieLibrary");
        }
    }
}
