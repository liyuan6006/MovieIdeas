using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieIdeas.DAL;
using MovieIdeas.Models;

namespace MovieIdeas.Controllers
{
    public class MovieController : Controller
    {
        private MovieIdeasContext db = new MovieIdeasContext();

        // GET: Movie
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var movies = from s in db.Movies
                         select s;
            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Name);
                    break;
            }
            return View(movies.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,EnrollmentDate")] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movieToUpdate = db.Movies.Find(id);
            if (TryUpdateModel(movieToUpdate, "",new string[] { "Name", "EnrollmentDate" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(movieToUpdate);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                /*
                 * If improving performance in a high-volume application is a priority, 
                 * you could avoid an unnecessary SQL query to retrieve the row 
                 * by replacing the lines of code that call the Find and Remove methods with the following code:
                */

                //Movie movie = db.Movies.Find(id);
                //db.Movies.Remove(movie);

                /*
                 This code instantiates a Movie entity using only the primary key value 
                 and then sets the entity state to Deleted. T
                 hat's all that the Entity Framework needs in order to delete the entity.
                 */
                Movie movieToDelete = new Movie() { ID = id };
                db.Entry(movieToDelete).State = EntityState.Deleted;

                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {

                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
