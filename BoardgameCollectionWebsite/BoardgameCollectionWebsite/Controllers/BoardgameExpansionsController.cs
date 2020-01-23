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
    public class BoardgameExpansionsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameExpansions
        public ActionResult Index()
        {
            var boardgameExpansions = db.BoardgameExpansions.Include(b => b.BoardGame).Include(b => b.Expansion);
            return View(boardgameExpansions.ToList());
        }

        // GET: BoardgameExpansions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameExpansion boardgameExpansion = db.BoardgameExpansions.Find(id);
            if (boardgameExpansion == null)
            {
                return HttpNotFound();
            }
            return View(boardgameExpansion);
        }

        // GET: BoardgameExpansions/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalExpansionID = new SelectList(db.Expansions, "LocalExpansionID", "ExpansionName");
            return View();
        }

        // POST: BoardgameExpansions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameExpansionID,LocalBoardgameID,LocalExpansionID")] BoardgameExpansion boardgameExpansion)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameExpansions.Add(boardgameExpansion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameExpansion.LocalBoardgameID);
            ViewBag.LocalExpansionID = new SelectList(db.Expansions, "LocalExpansionID", "ExpansionName", boardgameExpansion.LocalExpansionID);
            return View(boardgameExpansion);
        }

        // GET: BoardgameExpansions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameExpansion boardgameExpansion = db.BoardgameExpansions.Find(id);
            if (boardgameExpansion == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameExpansion.LocalBoardgameID);
            ViewBag.LocalExpansionID = new SelectList(db.Expansions, "LocalExpansionID", "ExpansionName", boardgameExpansion.LocalExpansionID);
            return View(boardgameExpansion);
        }

        // POST: BoardgameExpansions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameExpansionID,LocalBoardgameID,LocalExpansionID")] BoardgameExpansion boardgameExpansion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameExpansion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameExpansion.LocalBoardgameID);
            ViewBag.LocalExpansionID = new SelectList(db.Expansions, "LocalExpansionID", "ExpansionName", boardgameExpansion.LocalExpansionID);
            return View(boardgameExpansion);
        }

        // GET: BoardgameExpansions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameExpansion boardgameExpansion = db.BoardgameExpansions.Find(id);
            if (boardgameExpansion == null)
            {
                return HttpNotFound();
            }
            return View(boardgameExpansion);
        }

        // POST: BoardgameExpansions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameExpansion boardgameExpansion = db.BoardgameExpansions.Find(id);
            db.BoardgameExpansions.Remove(boardgameExpansion);
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
