using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieNight.Controllers
{[Authorize]
    public class HomeController : Controller
    {
        private MovieNightDBEntities3 db = new MovieNightDBEntities3();

        // GET: Home
        public ActionResult Index()
        {
            List<PictureTable> ListOfMovies = db.PictureTable.ToList();
            return View(ListOfMovies);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return RedirectToAction("Index");
            }
            PictureTable movieToDelete = db.PictureTable.Find(id);
            return View(movieToDelete);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PictureTable movieToDelete = db.PictureTable.Find(id);  
            db.PictureTable.Remove(movieToDelete);                 
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult searchTitle(string search)
        {
            var test = db.MovieTable.Where(x => x.Year.Contains(search) || search == null).ToList();
            return RedirectToAction("Index", "Home", test);

        }


        [HttpPost]
        public ActionResult Index(string Year, string Quality,string Genre) //Sök funktionen, kollar alla möjliga olika sök combo, t.ex. all - SUHD - Drama eller 2018 - 4k - crime
        {
            List<PictureTable> ListOfMovies = db.PictureTable.ToList();

            if (Year.ToLower() == "all" && Quality.ToLower() != "all" && Genre.ToLower() != "all")
            {
                ListOfMovies = db.PictureTable.Where(x => x.MovieTable.Quality.Contains(Quality) && x.MovieTable.Genre.Contains(Genre) || Year == null || Quality == null || Genre == null).ToList();
            }
            else if (Quality.ToLower() == "all" && Genre.ToLower() != "all" && Year.ToLower() == "all")
            {
                ListOfMovies = db.PictureTable.Where(x => x.MovieTable.Genre.Contains(Genre) || Year == null || Quality == null || Genre == null).ToList();
            }
            else if (Genre.ToLower() == "all" && Year.ToLower() != "all" && Quality.ToLower() != "all")
            {
                ListOfMovies = db.PictureTable.Where(x => x.MovieTable.Year.Contains(Year) && x.MovieTable.Quality.Contains(Quality) || Year == null || Quality == null || Genre == null).ToList();
            }

            else if (Genre.ToLower() != "all" && Year.ToLower() != "all" && Quality.ToLower() != "all")
            {
                ListOfMovies = db.PictureTable.Where(x => x.MovieTable.Year.Contains(Year) && x.MovieTable.Quality.Contains(Quality) && x.MovieTable.Genre.Contains(Genre) || Year == null || Quality == null || Genre == null).ToList();

            }
            else if (Genre.ToLower() == "all" && Year.ToLower() == "all" && Quality.ToLower() != "all")
            {
                ListOfMovies = db.PictureTable.Where(x => x.MovieTable.Quality.Contains(Quality) || Year == null || Quality == null || Genre == null).ToList();

            }
            else if (Genre.ToLower() == "all" && Year.ToLower() != "all" && Quality.ToLower() == "all")
            {
                ListOfMovies = db.PictureTable.Where(x => x.MovieTable.Year.Contains(Year) || Year == null || Quality == null || Genre == null).ToList();

            }

            else if (Genre.ToLower() == "all" && Year.ToLower() == "all" && Quality.ToLower() == "all")
            {
                return View(ListOfMovies);
            }

                if (ListOfMovies.Count <= 0) //ser till att layout=null inte blir out of bound.
            {
                List<PictureTable> ListOfMovies2 = db.PictureTable.ToList();

                return View(ListOfMovies2);
            }
            return View(ListOfMovies);

        }





        public ActionResult movieIDdelete()       // Dessa vyer är för att välja vilket ID från radera och uppdatera och skicka det vidare till dess motsvarande vyer.
        {
            List<PictureTable> ListOfMovies = db.PictureTable.ToList();
            return View(ListOfMovies);
        }
        public ActionResult movieIDupdate()
        {
            List<PictureTable> ListOfMovies = db.PictureTable.ToList();
            return View(ListOfMovies);
        }
    }
}