using BoardgameCollectionWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class BoardgamePublishersController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgamePublishers
        public ActionResult Index()
        {
            var boardgamePublishers = db.BoardgamePublishers.Include(b => b.BoardGame).Include(b => b.Publisher);
            return View(boardgamePublishers.ToList());
        }

        // GET: BoardgamePublishers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgamePublisher boardgamePublisher = db.BoardgamePublishers.Find(id);
            if (boardgamePublisher == null)
            {
                return HttpNotFound();
            }
            return View(boardgamePublisher);
        }

        // GET: BoardgamePublishers/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalPublisherID = new SelectList(db.Publishers, "LocalPublisherID", "PublisherName");
            return View();
        }

        // POST: BoardgamePublishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgamePublisherID,LocalBoardgameID,LocalPublisherID")] BoardgamePublisher boardgamePublisher)
        {
            if (ModelState.IsValid)
            {
                db.BoardgamePublishers.Add(boardgamePublisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgamePublisher.LocalBoardgameID);
            ViewBag.LocalPublisherID = new SelectList(db.Publishers, "LocalPublisherID", "PublisherName", boardgamePublisher.LocalPublisherID);
            return View(boardgamePublisher);
        }

        // GET: BoardgamePublishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgamePublisher boardgamePublisher = db.BoardgamePublishers.Find(id);
            if (boardgamePublisher == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgamePublisher.LocalBoardgameID);
            ViewBag.LocalPublisherID = new SelectList(db.Publishers, "LocalPublisherID", "PublisherName", boardgamePublisher.LocalPublisherID);
            return View(boardgamePublisher);
        }

        // POST: BoardgamePublishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgamePublisherID,LocalBoardgameID,LocalPublisherID")] BoardgamePublisher boardgamePublisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgamePublisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgamePublisher.LocalBoardgameID);
            ViewBag.LocalPublisherID = new SelectList(db.Publishers, "LocalPublisherID", "PublisherName", boardgamePublisher.LocalPublisherID);
            return View(boardgamePublisher);
        }

        // GET: BoardgamePublishers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgamePublisher boardgamePublisher = db.BoardgamePublishers.Find(id);
            if (boardgamePublisher == null)
            {
                return HttpNotFound();
            }
            return View(boardgamePublisher);
        }

        // POST: BoardgamePublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgamePublisher boardgamePublisher = db.BoardgamePublishers.Find(id);
            db.BoardgamePublishers.Remove(boardgamePublisher);
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
