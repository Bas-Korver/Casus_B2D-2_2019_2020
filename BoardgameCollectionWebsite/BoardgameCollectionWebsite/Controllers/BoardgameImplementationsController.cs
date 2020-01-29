using BoardgameCollectionWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class BoardgameImplementationsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameImplementations
        public ActionResult Index()
        {
            var boardgameImplementations = db.BoardgameImplementations.Include(b => b.BoardGame).Include(b => b.Implementation);
            return View(boardgameImplementations.ToList());
        }

        // GET: BoardgameImplementations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameImplementation boardgameImplementation = db.BoardgameImplementations.Find(id);
            if (boardgameImplementation == null)
            {
                return HttpNotFound();
            }
            return View(boardgameImplementation);
        }

        // GET: BoardgameImplementations/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalImplementationID = new SelectList(db.Implementations, "LocalImplementationID", "ImplementedBy");
            return View();
        }

        // POST: BoardgameImplementations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameImplementationID,LocalBoardgameID,LocalImplementationID")] BoardgameImplementation boardgameImplementation)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameImplementations.Add(boardgameImplementation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameImplementation.LocalBoardgameID);
            ViewBag.LocalImplementationID = new SelectList(db.Implementations, "LocalImplementationID", "ImplementedBy", boardgameImplementation.LocalImplementationID);
            return View(boardgameImplementation);
        }

        // GET: BoardgameImplementations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameImplementation boardgameImplementation = db.BoardgameImplementations.Find(id);
            if (boardgameImplementation == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameImplementation.LocalBoardgameID);
            ViewBag.LocalImplementationID = new SelectList(db.Implementations, "LocalImplementationID", "ImplementedBy", boardgameImplementation.LocalImplementationID);
            return View(boardgameImplementation);
        }

        // POST: BoardgameImplementations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameImplementationID,LocalBoardgameID,LocalImplementationID")] BoardgameImplementation boardgameImplementation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameImplementation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameImplementation.LocalBoardgameID);
            ViewBag.LocalImplementationID = new SelectList(db.Implementations, "LocalImplementationID", "ImplementedBy", boardgameImplementation.LocalImplementationID);
            return View(boardgameImplementation);
        }

        // GET: BoardgameImplementations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameImplementation boardgameImplementation = db.BoardgameImplementations.Find(id);
            if (boardgameImplementation == null)
            {
                return HttpNotFound();
            }
            return View(boardgameImplementation);
        }

        // POST: BoardgameImplementations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameImplementation boardgameImplementation = db.BoardgameImplementations.Find(id);
            db.BoardgameImplementations.Remove(boardgameImplementation);
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
