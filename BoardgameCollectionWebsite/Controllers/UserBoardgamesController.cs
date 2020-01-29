using BoardgameCollectionWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class UserBoardgamesController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: UserBoardgames
        public ActionResult Index()
        {
            var userBoardgames = db.UserBoardgames.Include(u => u.AspNetUser).Include(u => u.BoardGame);
            return View(userBoardgames.ToList());
        }

        // GET: UserBoardgames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgame userBoardgame = db.UserBoardgames.Find(id);
            if (userBoardgame == null)
            {
                return HttpNotFound();
            }
            return View(userBoardgame);
        }

        // GET: UserBoardgames/Create
        public ActionResult Create()
        {
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            return View();
        }

        // POST: UserBoardgames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserBoardgamesID,ASPUsersID,LocalBoardgameID")] UserBoardgame userBoardgame)
        {
            if (ModelState.IsValid)
            {
                db.UserBoardgames.Add(userBoardgame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgame.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgame.LocalBoardgameID);
            return View(userBoardgame);
        }

        // GET: UserBoardgames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgame userBoardgame = db.UserBoardgames.Find(id);
            if (userBoardgame == null)
            {
                return HttpNotFound();
            }
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgame.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgame.LocalBoardgameID);
            return View(userBoardgame);
        }

        // POST: UserBoardgames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserBoardgamesID,ASPUsersID,LocalBoardgameID")] UserBoardgame userBoardgame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userBoardgame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ASPUsersID = new SelectList(db.AspNetUsers, "Id", "Email", userBoardgame.ASPUsersID);
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", userBoardgame.LocalBoardgameID);
            return View(userBoardgame);
        }

        // GET: UserBoardgames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBoardgame userBoardgame = db.UserBoardgames.Find(id);
            if (userBoardgame == null)
            {
                return HttpNotFound();
            }
            return View(userBoardgame);
        }

        // POST: UserBoardgames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserBoardgame userBoardgame = db.UserBoardgames.Find(id);
            db.UserBoardgames.Remove(userBoardgame);
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
