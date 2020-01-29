using BoardgameCollectionWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class BoardgameIntegrationsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameIntegrations
        public ActionResult Index()
        {
            var boardgameIntegrations = db.BoardgameIntegrations.Include(b => b.BoardGame).Include(b => b.Integration);
            return View(boardgameIntegrations.ToList());
        }

        // GET: BoardgameIntegrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameIntegration boardgameIntegration = db.BoardgameIntegrations.Find(id);
            if (boardgameIntegration == null)
            {
                return HttpNotFound();
            }
            return View(boardgameIntegration);
        }

        // GET: BoardgameIntegrations/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalIntegrationID = new SelectList(db.Integrations, "LocalIntegrationID", "IntegratedBy");
            return View();
        }

        // POST: BoardgameIntegrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameIntegrationID,LocalBoardgameID,LocalIntegrationID")] BoardgameIntegration boardgameIntegration)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameIntegrations.Add(boardgameIntegration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameIntegration.LocalBoardgameID);
            ViewBag.LocalIntegrationID = new SelectList(db.Integrations, "LocalIntegrationID", "IntegratedBy", boardgameIntegration.LocalIntegrationID);
            return View(boardgameIntegration);
        }

        // GET: BoardgameIntegrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameIntegration boardgameIntegration = db.BoardgameIntegrations.Find(id);
            if (boardgameIntegration == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameIntegration.LocalBoardgameID);
            ViewBag.LocalIntegrationID = new SelectList(db.Integrations, "LocalIntegrationID", "IntegratedBy", boardgameIntegration.LocalIntegrationID);
            return View(boardgameIntegration);
        }

        // POST: BoardgameIntegrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameIntegrationID,LocalBoardgameID,LocalIntegrationID")] BoardgameIntegration boardgameIntegration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameIntegration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameIntegration.LocalBoardgameID);
            ViewBag.LocalIntegrationID = new SelectList(db.Integrations, "LocalIntegrationID", "IntegratedBy", boardgameIntegration.LocalIntegrationID);
            return View(boardgameIntegration);
        }

        // GET: BoardgameIntegrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameIntegration boardgameIntegration = db.BoardgameIntegrations.Find(id);
            if (boardgameIntegration == null)
            {
                return HttpNotFound();
            }
            return View(boardgameIntegration);
        }

        // POST: BoardgameIntegrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameIntegration boardgameIntegration = db.BoardgameIntegrations.Find(id);
            db.BoardgameIntegrations.Remove(boardgameIntegration);
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
