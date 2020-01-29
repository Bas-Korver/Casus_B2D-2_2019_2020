using BoardgameCollectionWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class ExpansionsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: Expansions
        public ActionResult Index()
        {
            return View(db.Expansions.ToList());
        }

        // GET: Expansions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expansion expansion = db.Expansions.Find(id);
            if (expansion == null)
            {
                return HttpNotFound();
            }
            return View(expansion);
        }

        // GET: Expansions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expansions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalExpansionID,ExpansionID,ExpansionName")] Expansion expansion)
        {
            if (ModelState.IsValid)
            {
                db.Expansions.Add(expansion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expansion);
        }

        // GET: Expansions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expansion expansion = db.Expansions.Find(id);
            if (expansion == null)
            {
                return HttpNotFound();
            }
            return View(expansion);
        }

        // POST: Expansions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalExpansionID,ExpansionID,ExpansionName")] Expansion expansion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expansion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expansion);
        }

        // GET: Expansions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expansion expansion = db.Expansions.Find(id);
            if (expansion == null)
            {
                return HttpNotFound();
            }
            return View(expansion);
        }

        // POST: Expansions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expansion expansion = db.Expansions.Find(id);
            db.Expansions.Remove(expansion);
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
