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
    public class BoardgameMechanicsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameMechanics
        public ActionResult Index()
        {
            var boardgameMechanics = db.BoardgameMechanics.Include(b => b.BoardGame).Include(b => b.Mechanic);
            return View(boardgameMechanics.ToList());
        }

        // GET: BoardgameMechanics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameMechanic boardgameMechanic = db.BoardgameMechanics.Find(id);
            if (boardgameMechanic == null)
            {
                return HttpNotFound();
            }
            return View(boardgameMechanic);
        }

        // GET: BoardgameMechanics/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalMechanicID = new SelectList(db.Mechanics, "LocalMechanicID", "MechanicName");
            return View();
        }

        // POST: BoardgameMechanics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameMechanicID,LocalBoardgameID,LocalMechanicID")] BoardgameMechanic boardgameMechanic)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameMechanics.Add(boardgameMechanic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameMechanic.LocalBoardgameID);
            ViewBag.LocalMechanicID = new SelectList(db.Mechanics, "LocalMechanicID", "MechanicName", boardgameMechanic.LocalMechanicID);
            return View(boardgameMechanic);
        }

        // GET: BoardgameMechanics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameMechanic boardgameMechanic = db.BoardgameMechanics.Find(id);
            if (boardgameMechanic == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameMechanic.LocalBoardgameID);
            ViewBag.LocalMechanicID = new SelectList(db.Mechanics, "LocalMechanicID", "MechanicName", boardgameMechanic.LocalMechanicID);
            return View(boardgameMechanic);
        }

        // POST: BoardgameMechanics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameMechanicID,LocalBoardgameID,LocalMechanicID")] BoardgameMechanic boardgameMechanic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameMechanic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameMechanic.LocalBoardgameID);
            ViewBag.LocalMechanicID = new SelectList(db.Mechanics, "LocalMechanicID", "MechanicName", boardgameMechanic.LocalMechanicID);
            return View(boardgameMechanic);
        }

        // GET: BoardgameMechanics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameMechanic boardgameMechanic = db.BoardgameMechanics.Find(id);
            if (boardgameMechanic == null)
            {
                return HttpNotFound();
            }
            return View(boardgameMechanic);
        }

        // POST: BoardgameMechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameMechanic boardgameMechanic = db.BoardgameMechanics.Find(id);
            db.BoardgameMechanics.Remove(boardgameMechanic);
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
