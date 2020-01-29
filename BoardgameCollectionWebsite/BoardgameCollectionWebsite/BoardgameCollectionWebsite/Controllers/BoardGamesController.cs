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
    public class BoardGamesController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardGames
        public ActionResult Index()
        {
            return View(db.BoardGames.ToList());
        }

        // GET: BoardGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // GET: BoardGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoardGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalBoardgameID,BoardgameID,Thumbnail,Image,Title,Description,PublicationYear,MinPlayers,MaxPlayers,PlayingTime,MaxPlayTime,MinPlayTime,MinAge")] BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                db.BoardGames.Add(boardGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boardGame);
        }

        // GET: BoardGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // POST: BoardGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalBoardgameID,BoardgameID,Thumbnail,Image,Title,Description,PublicationYear,MinPlayers,MaxPlayers,PlayingTime,MaxPlayTime,MinPlayTime,MinAge")] BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardGame);
        }

        // GET: BoardGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // POST: BoardGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardGame boardGame = db.BoardGames.Find(id);
            db.BoardGames.Remove(boardGame);
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
