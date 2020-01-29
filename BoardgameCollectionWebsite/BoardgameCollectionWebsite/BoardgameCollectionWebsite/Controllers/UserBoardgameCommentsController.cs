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
    public class UserBoardgameCommentsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: UserBoardgameComments
        public ActionResult Index()
        {
            var userBoardgameComments = db.UserBoardgameComments.Include(u => u.AspNetUser).Include(u => u.BoardGame);
            return View(userBoardgameComments.ToList());
        }

        // GET: UserBoardgameComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgameComment userBoardgameComment = db.UserBoardgameComments.Find(id);
            if (userBoardgameComment == null)
            {
                return HttpNotFound();
            }
            return View(userBoardgameComment);
        }

        // GET: UserBoardgameComments/Create
        public ActionResult Create()
        {
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            return View();
        }

        // POST: UserBoardgameComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserBoardgameCommentID,ASPUsersID,LocalBoardgameID,BoardgameComment")] UserBoardgameComment userBoardgameComment)
        {
            if (ModelState.IsValid)
            {
                db.UserBoardgameComments.Add(userBoardgameComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgameComment.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgameComment.LocalBoardgameID);
            return View(userBoardgameComment);
        }

        // GET: UserBoardgameComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgameComment userBoardgameComment = db.UserBoardgameComments.Find(id);
            if (userBoardgameComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgameComment.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgameComment.LocalBoardgameID);
            return View(userBoardgameComment);
        }

        // POST: UserBoardgameComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserBoardgameCommentID,ASPUsersID,LocalBoardgameID,BoardgameComment")] UserBoardgameComment userBoardgameComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userBoardgameComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgameComment.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgameComment.LocalBoardgameID);
            return View(userBoardgameComment);
        }

        // GET: UserBoardgameComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgameComment userBoardgameComment = db.UserBoardgameComments.Find(id);
            if (userBoardgameComment == null)
            {
                return HttpNotFound();
            }
            return View(userBoardgameComment);
        }

        // POST: UserBoardgameComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserBoardgameComment userBoardgameComment = db.UserBoardgameComments.Find(id);
            db.UserBoardgameComments.Remove(userBoardgameComment);
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
