using MovieNight.Models;
using MovieNight.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MovieNight.Controllers
{
    [Authorize]
    public class FiluppladdningController : Controller
    {
        MovieNightDBEntities3 db = new MovieNightDBEntities3();

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(PictureTable addPicture)
        {

            string filename = Path.GetFileNameWithoutExtension(addPicture.thePicture.FileName);  //sparar två seperata bilder i vardera variable. annars sparas samma bild två gånger.
            string extension = Path.GetExtension(addPicture.thePicture.FileName);                //https://www.youtube.com/watch?v=5L5W-AE-sEs&feature=youtu.be&fbclid=IwAR3mzc9FTcpRnx1hNCUL_n_MibWT0tIcQyYTMWBtkO9DA9-9pcW61HdxIic kod hämtad från youtube.
            filename = filename + DateTime.Now.ToString("yymmssffff-smal") + extension;
            addPicture.Background_Smal = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            addPicture.thePicture.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(addPicture.thePicture2.FileName);
            string extension2 = Path.GetExtension(addPicture.thePicture2.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssffff-big") + extension2;
            addPicture.Background_Big = "~/Image/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/Image/"), filename2);
            addPicture.thePicture2.SaveAs(filename2);

            db.PictureTable.Add(addPicture);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public ActionResult update(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            PictureTable movieToUpdate = db.PictureTable.Find(id);
            return View(movieToUpdate);
        }
        [HttpPost]
        public ActionResult update(PictureTable updatePicture)
        {
            string filename = Path.GetFileNameWithoutExtension(updatePicture.thePicture.FileName);  //sparar två seperata bilder i vardera variable. annars sparas samma bild två gånger.
            string extension = Path.GetExtension(updatePicture.thePicture.FileName);                //kod från https://www.youtube.com/watch?v=5L5W-AE-sEs&feature=youtu.be&fbclid=IwAR3mzc9FTcpRnx1hNCUL_n_MibWT0tIcQyYTMWBtkO9DA9-9pcW61HdxIic
            filename = filename + DateTime.Now.ToString("yymmssffff-SmalImage") + extension;
            updatePicture.Background_Smal = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            updatePicture.thePicture.SaveAs(filename);

            string filename2 = Path.GetFileNameWithoutExtension(updatePicture.thePicture2.FileName);
            string extension2 = Path.GetExtension(updatePicture.thePicture2.FileName);
            filename2 = filename2 + DateTime.Now.ToString("yymmssffff-BigImage") + extension2;
            updatePicture.Background_Big = "~/Image/" + filename2;
            filename2 = Path.Combine(Server.MapPath("~/Image/"), filename2);
            updatePicture.thePicture2.SaveAs(filename2);



            db.Entry(updatePicture).State = System.Data.Entity.EntityState.Modified;
            db.Entry(updatePicture.MovieTable).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}