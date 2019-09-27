using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyWebSKF_GestionServicios.Context;

namespace ProyWebSKF_GestionServicios.Controllers
{
    public class PaquetesController : Controller
    {
        private BdSKF_GestionServiciosEntities db = new BdSKF_GestionServiciosEntities();

        // GET: Paquetes
        public ActionResult Index()
        {
            return View(db.PAQUETES.ToList());
        }

        // GET: Paquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAQUETE pAQUETE = db.PAQUETES.Find(id);
            if (pAQUETE == null)
            {
                return HttpNotFound();
            }
            return View(pAQUETE);
        }

        // GET: Paquetes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,estado")] PAQUETE pAQUETE)
        {
            if (ModelState.IsValid)
            {
                db.PAQUETES.Add(pAQUETE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAQUETE);
        }

        // GET: Paquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAQUETE pAQUETE = db.PAQUETES.Find(id);
            if (pAQUETE == null)
            {
                return HttpNotFound();
            }
            return View(pAQUETE);
        }

        // POST: Paquetes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,estado")] PAQUETE pAQUETE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAQUETE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAQUETE);
        }

        // GET: Paquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAQUETE pAQUETE = db.PAQUETES.Find(id);
            if (pAQUETE == null)
            {
                return HttpNotFound();
            }
            return View(pAQUETE);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAQUETE pAQUETE = db.PAQUETES.Find(id);
            db.PAQUETES.Remove(pAQUETE);
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
