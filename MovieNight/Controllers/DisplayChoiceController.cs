using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieNight.Models;

namespace MovieNight.Controllers
{
    [Authorize]
    public class DisplayChoiceController : Controller
    {
        private MovieNightDBEntities3 db = new MovieNightDBEntities3();
       
        // GET: DisplayChoice
        public ActionResult Index(int id) //hämtar ID och visar filmen beroende på ID som skickas in.
        {
            PictureTable MovieChosen = db.PictureTable.Find(id);
           
            return View(MovieChosen);
        }


    }
}