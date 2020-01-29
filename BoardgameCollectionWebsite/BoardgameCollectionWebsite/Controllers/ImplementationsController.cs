using BoardgameCollectionWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class ImplementationsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: Implementations
        public ActionResult Index()
        {
            return View(db.Implementations.ToList());
        }

        // GET: Implementations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Implementation implementation = db.Implementations.Find(id);
            if (implementation == null)
            {
                return HttpNotFound();
            }
            return View(implementation);
        }

        // GET: Implementations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Implementations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalImplementationID,ImplementationID,ImplementedBy")] Implementation implementation)
        {
            if (ModelState.IsValid)
            {
                db.Implementations.Add(implementation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(implementation);
        }

        // GET: Implementations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Implementation implementation = db.Implementations.Find(id);
            if (implementation == null)
            {
                return HttpNotFound();
            }
            return View(implementation);
        }

        // POST: Implementations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalImplementationID,ImplementationID,ImplementedBy")] Implementation implementation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(implementation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(implementation);
        }

        // GET: Implementations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Implementation implementation = db.Implementations.Find(id);
            if (implementation == null)
            {
                return HttpNotFound();
            }
            return View(implementation);
        }

        // POST: Implementations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Implementation implementation = db.Implementations.Find(id);
            db.Implementations.Remove(implementation);
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
