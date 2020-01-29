using BoardgameCollectionWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class BoardgameDesignersController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardgameDesigners
        public ActionResult Index()
        {
            var boardgameDesigners = db.BoardgameDesigners.Include(b => b.BoardGame).Include(b => b.Designer);
            return View(boardgameDesigners.ToList());
        }

        // GET: BoardgameDesigners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameDesigner boardgameDesigner = db.BoardgameDesigners.Find(id);
            if (boardgameDesigner == null)
            {
                return HttpNotFound();
            }
            return View(boardgameDesigner);
        }

        // GET: BoardgameDesigners/Create
        public ActionResult Create()
        {
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail");
            ViewBag.LocalDesignerID = new SelectList(db.Designers, "LocalDesignerID", "DesignerName");
            return View();
        }

        // POST: BoardgameDesigners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardgameDesignerID,LocalBoardgameID,LocalDesignerID")] BoardgameDesigner boardgameDesigner)
        {
            if (ModelState.IsValid)
            {
                db.BoardgameDesigners.Add(boardgameDesigner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameDesigner.LocalBoardgameID);
            ViewBag.LocalDesignerID = new SelectList(db.Designers, "LocalDesignerID", "DesignerName", boardgameDesigner.LocalDesignerID);
            return View(boardgameDesigner);
        }

        // GET: BoardgameDesigners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameDesigner boardgameDesigner = db.BoardgameDesigners.Find(id);
            if (boardgameDesigner == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameDesigner.LocalBoardgameID);
            ViewBag.LocalDesignerID = new SelectList(db.Designers, "LocalDesignerID", "DesignerName", boardgameDesigner.LocalDesignerID);
            return View(boardgameDesigner);
        }

        // POST: BoardgameDesigners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardgameDesignerID,LocalBoardgameID,LocalDesignerID")] BoardgameDesigner boardgameDesigner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardgameDesigner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalBoardgameID = new SelectList(db.BoardGames, "LocalBoardgameID", "Thumbnail", boardgameDesigner.LocalBoardgameID);
            ViewBag.LocalDesignerID = new SelectList(db.Designers, "LocalDesignerID", "DesignerName", boardgameDesigner.LocalDesignerID);
            return View(boardgameDesigner);
        }

        // GET: BoardgameDesigners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardgameDesigner boardgameDesigner = db.BoardgameDesigners.Find(id);
            if (boardgameDesigner == null)
            {
                return HttpNotFound();
            }
            return View(boardgameDesigner);
        }

        // POST: BoardgameDesigners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardgameDesigner boardgameDesigner = db.BoardgameDesigners.Find(id);
            db.BoardgameDesigners.Remove(boardgameDesigner);
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
