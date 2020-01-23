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
    public class BoardgameArtistsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameArtists
        public ActionResult Index()
        {
            var boardgameArtists = db.BoardgameArtists.Include(b => b.Artist).Include(b => b.BoardGame);
            return View(boardgameArtists.ToList());
        }

        // GET: BoardgameArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameArtist boardgameArtist = db.BoardgameArtists.Find(id);
            if (boardgameArtist == null)
            {
                return HttpNotFound();
            }
            return View(boardgameArtist);
        }

        // GET: BoardgameArtists/Create
        public ActionResult Create()
        {
            ViewBag.LocalArtistID = new SelectList(db.Artists, "LocalArtistID", "ArtistName");
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            return View();
        }

        // POST: BoardgameArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameArtistID,LocalBoardgameID,LocalArtistID")] BoardgameArtist boardgameArtist)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameArtists.Add(boardgameArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalArtistID = new SelectList(db.Artists, "LocalArtistID", "ArtistName", boardgameArtist.LocalArtistID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameArtist.LocalBoardgameID);
            return View(boardgameArtist);
        }

        // GET: BoardgameArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameArtist boardgameArtist = db.BoardgameArtists.Find(id);
            if (boardgameArtist == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalArtistID = new SelectList(db.Artists, "LocalArtistID", "ArtistName", boardgameArtist.LocalArtistID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameArtist.LocalBoardgameID);
            return View(boardgameArtist);
        }

        // POST: BoardgameArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameArtistID,LocalBoardgameID,LocalArtistID")] BoardgameArtist boardgameArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalArtistID = new SelectList(db.Artists, "LocalArtistID", "ArtistName", boardgameArtist.LocalArtistID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameArtist.LocalBoardgameID);
            return View(boardgameArtist);
        }

        // GET: BoardgameArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameArtist boardgameArtist = db.BoardgameArtists.Find(id);
            if (boardgameArtist == null)
            {
                return HttpNotFound();
            }
            return View(boardgameArtist);
        }

        // POST: BoardgameArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameArtist boardgameArtist = db.BoardgameArtists.Find(id);
            db.BoardgameArtists.Remove(boardgameArtist);
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
