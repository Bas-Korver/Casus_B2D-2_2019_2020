using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoardgameCollectionWebsite.Models;

namespace BoardgameCollectionWebsite.Controllers
{
    public class BoardgameCategoriesController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameCategories
        public ActionResult Index()
        {
            var boardgameCategories = db.BoardgameCategories.Include(b => b.BoardGame).Include(b => b.Category);
            return View(boardgameCategories.ToList());
        }

        // GET: BoardgameCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameCategory boardgameCategory = db.BoardgameCategories.Find(id);
            if (boardgameCategory == null)
            {
                return HttpNotFound();
            }
            return View(boardgameCategory);
        }

        // GET: BoardgameCategories/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalCategoryID = new SelectList(db.Categories, "LocalCategoryID", "CategoryName");
            return View();
        }

        // POST: BoardgameCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameCategoryID,LocalBoardgameID,LocalCategoryID")] BoardgameCategory boardgameCategory)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameCategories.Add(boardgameCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameCategory.LocalBoardgameID);
            ViewBag.LocalCategoryID = new SelectList(db.Categories, "LocalCategoryID", "CategoryName", boardgameCategory.LocalCategoryID);
            return View(boardgameCategory);
        }

        // GET: BoardgameCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameCategory boardgameCategory = db.BoardgameCategories.Find(id);
            if (boardgameCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameCategory.LocalBoardgameID);
            ViewBag.LocalCategoryID = new SelectList(db.Categories, "LocalCategoryID", "CategoryName", boardgameCategory.LocalCategoryID);
            return View(boardgameCategory);
        }

        // POST: BoardgameCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameCategoryID,LocalBoardgameID,LocalCategoryID")] BoardgameCategory boardgameCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameCategory.LocalBoardgameID);
            ViewBag.LocalCategoryID = new SelectList(db.Categories, "LocalCategoryID", "CategoryName", boardgameCategory.LocalCategoryID);
            return View(boardgameCategory);
        }

        // GET: BoardgameCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameCategory boardgameCategory = db.BoardgameCategories.Find(id);
            if (boardgameCategory == null)
            {
                return HttpNotFound();
            }
            return View(boardgameCategory);
        }

        // POST: BoardgameCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameCategory boardgameCategory = db.BoardgameCategories.Find(id);
            db.BoardgameCategories.Remove(boardgameCategory);
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
