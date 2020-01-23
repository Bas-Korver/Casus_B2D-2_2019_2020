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
    public class IntegrationsController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: Integrations
        public ActionResult Index()
        {
            return View(db.Integrations.ToList());
        }

        // GET: Integrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integration integration = db.Integrations.Find(id);
            if (integration == null)
            {
                return HttpNotFound();
            }
            return View(integration);
        }

        // GET: Integrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Integrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalIntegrationID,IntegrationID,IntegratedBy")] Integration integration)
        {
            if (ModelState.IsValid)
            {
                db.Integrations.Add(integration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(integration);
        }

        // GET: Integrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integration integration = db.Integrations.Find(id);
            if (integration == null)
            {
                return HttpNotFound();
            }
            return View(integration);
        }

        // POST: Integrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalIntegrationID,IntegrationID,IntegratedBy")] Integration integration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(integration);
        }

        // GET: Integrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integration integration = db.Integrations.Find(id);
            if (integration == null)
            {
                return HttpNotFound();
            }
            return View(integration);
        }

        // POST: Integrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Integration integration = db.Integrations.Find(id);
            db.Integrations.Remove(integration);
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
