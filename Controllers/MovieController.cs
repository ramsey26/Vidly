using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random    
        public ActionResult Random()
        {
            Movie oMovie = new Movie() { Name = "Iron Man" };

            var customers = new List<Customer>
            {
                new Customer{Id=1,Name="Ayush"},
                new Customer{Id=2,Name="Bharat"}
            };

            var randomMovieViewModel = new RandomMovieViewModel()
            {
                Movie = oMovie,
                Customers = customers
            };

            return View(randomMovieViewModel);
            //return View(oMovie);
            //  return Content("Hello world");
            // return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, Name = "IronMan" });
           
        }

        public ContentResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("PageIndex ={0} & SortBy={1}", pageIndex, sortBy)); 
        }

        [Route("movie/ReleaseByDate/{year}/{month:regex(\\d{0,2}):range(1,12)}")]
        public ActionResult ReleaseByDate(int year, int month)
        {
            return Content("Year = " + year + "/Month = " + month);
        }
    }
}