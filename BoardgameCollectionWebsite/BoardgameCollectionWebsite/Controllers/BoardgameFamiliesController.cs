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
    public class BoardgameFamiliesController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameFamilies
        public ActionResult Index()
        {
            var boardgameFamilies = db.BoardgameFamilies.Include(b => b.BoardGame).Include(b => b.Family);
            return View(boardgameFamilies.ToList());
        }

        // GET: BoardgameFamilies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameFamily boardgameFamily = db.BoardgameFamilies.Find(id);
            if (boardgameFamily == null)
            {
                return HttpNotFound();
            }
            return View(boardgameFamily);
        }

        // GET: BoardgameFamilies/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalFamilyID = new SelectList(db.Families, "LocalFamilyID", "FamilyName");
            return View();
        }

        // POST: BoardgameFamilies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameFamilyID,LocalBoardgameID,LocalFamilyID")] BoardgameFamily boardgameFamily)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameFamilies.Add(boardgameFamily);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameFamily.LocalBoardgameID);
            ViewBag.LocalFamilyID = new SelectList(db.Families, "LocalFamilyID", "FamilyName", boardgameFamily.LocalFamilyID);
            return View(boardgameFamily);
        }

        // GET: BoardgameFamilies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameFamily boardgameFamily = db.BoardgameFamilies.Find(id);
            if (boardgameFamily == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameFamily.LocalBoardgameID);
            ViewBag.LocalFamilyID = new SelectList(db.Families, "LocalFamilyID", "FamilyName", boardgameFamily.LocalFamilyID);
            return View(boardgameFamily);
        }

        // POST: BoardgameFamilies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameFamilyID,LocalBoardgameID,LocalFamilyID")] BoardgameFamily boardgameFamily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameFamily).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameFamily.LocalBoardgameID);
            ViewBag.LocalFamilyID = new SelectList(db.Families, "LocalFamilyID", "FamilyName", boardgameFamily.LocalFamilyID);
            return View(boardgameFamily);
        }

        // GET: BoardgameFamilies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameFamily boardgameFamily = db.BoardgameFamilies.Find(id);
            if (boardgameFamily == null)
            {
                return HttpNotFound();
            }
            return View(boardgameFamily);
        }

        // POST: BoardgameFamilies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameFamily boardgameFamily = db.BoardgameFamilies.Find(id);
            db.BoardgameFamilies.Remove(boardgameFamily);
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
