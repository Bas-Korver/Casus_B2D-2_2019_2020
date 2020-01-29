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
    public class UserBoardgameFavouritesController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: UserBoardgameFavourites
        public ActionResult Index()
        {
            var userBoardgameFavourites = db.UserBoardgameFavourites.Include(u => u.AspNetUser).Include(u => u.BoardGame);
            return View(userBoardgameFavourites.ToList());
        }

        // GET: UserBoardgameFavourites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgameFavourite userBoardgameFavourite = db.UserBoardgameFavourites.Find(id);
            if (userBoardgameFavourite == null)
            {
                return HttpNotFound();
            }
            return View(userBoardgameFavourite);
        }

        // GET: UserBoardgameFavourites/Create
        public ActionResult Create()
        {
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            return View();
        }

        // POST: UserBoardgameFavourites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserBoardgameFavouriteID,ASPUsersID,LocalBoardgameID")] UserBoardgameFavourite userBoardgameFavourite)
        {
            if (ModelState.IsValid)
            {
                db.UserBoardgameFavourites.Add(userBoardgameFavourite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgameFavourite.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgameFavourite.LocalBoardgameID);
            return View(userBoardgameFavourite);
        }

        // GET: UserBoardgameFavourites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgameFavourite userBoardgameFavourite = db.UserBoardgameFavourites.Find(id);
            if (userBoardgameFavourite == null)
            {
                return HttpNotFound();
            }
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgameFavourite.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgameFavourite.LocalBoardgameID);
            return View(userBoardgameFavourite);
        }

        // POST: UserBoardgameFavourites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserBoardgameFavouriteID,ASPUsersID,LocalBoardgameID")] UserBoardgameFavourite userBoardgameFavourite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userBoardgameFavourite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgameFavourite.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgameFavourite.LocalBoardgameID);
            return View(userBoardgameFavourite);
        }

        // GET: UserBoardgameFavourites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgameFavourite userBoardgameFavourite = db.UserBoardgameFavourites.Find(id);
            if (userBoardgameFavourite == null)
            {
                return HttpNotFound();
            }
            return View(userBoardgameFavourite);
        }

        // POST: UserBoardgameFavourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserBoardgameFavourite userBoardgameFavourite = db.UserBoardgameFavourites.Find(id);
            db.UserBoardgameFavourites.Remove(userBoardgameFavourite);
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
