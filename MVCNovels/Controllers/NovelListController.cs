using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCNovels.Models;
using PagedList;

namespace MVCNovels.Controllers
{
    public class NovelListController : Controller
    {
        private NovelListDBEntities db = new NovelListDBEntities();

        // GET: NovelList
        [Authorize]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var novels = from s in db.NovelLists
                           select s;


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                novels = novels.Where(s => s.Name.Contains(searchString)
                             );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    novels = novels.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    novels = novels.OrderBy(s => s.Chapter);
                    break;
                case "date_desc":
                    novels = novels.OrderByDescending(s => s.Chapter);
                    break;
                default:
                    novels = novels.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(novels.ToPagedList(pageNumber, pageSize));
        }

        // GET: NovelList/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NovelList novelList = db.NovelLists.Find(id);
            if (novelList == null)
            {
                return HttpNotFound();
            }
            return View(novelList);
        }

        // GET: NovelList/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: NovelList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,Chapter,Genre")] NovelList novelList)
        {
            if (ModelState.IsValid)
            {
                db.NovelLists.Add(novelList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(novelList);
        }

        // GET: NovelList/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NovelList novelList = db.NovelLists.Find(id);
            if (novelList == null)
            {
                return HttpNotFound();
            }
            return View(novelList);
        }

        // POST: NovelList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Name,Chapter,Genre")] NovelList novelList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(novelList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(novelList);
        }

        // GET: NovelList/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NovelList novelList = db.NovelLists.Find(id);
            if (novelList == null)
            {
                return HttpNotFound();
            }
            return View(novelList);
        }

        // POST: NovelList/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NovelList novelList = db.NovelLists.Find(id);
            db.NovelLists.Remove(novelList);
            db.SaveChanges();
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
