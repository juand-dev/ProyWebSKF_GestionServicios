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
    public class DetallePaquetesController : Controller
    {
        private BdSKF_GestionServiciosEntities db = new BdSKF_GestionServiciosEntities();

        // GET: DetallePaquetes
        public ActionResult Index()
        {
            var dETALLEPAQUETES = db.DETALLEPAQUETES.Include(d => d.SERVICIO).Include(d => d.PAQUETE);
            return View(dETALLEPAQUETES.ToList());
        }

        // GET: DetallePaquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPAQUETE dETALLEPAQUETE = db.DETALLEPAQUETES.Find(id);
            if (dETALLEPAQUETE == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPAQUETE);
        }

        // GET: DetallePaquetes/Create
        public ActionResult Create()
        {
            ViewBag.servicio_id = new SelectList(db.SERVICIOS, "id", "nombre");
            ViewBag.paquete_id = new SelectList(db.PAQUETES, "id", "nombre");
            return View();
        }

        // POST: DetallePaquetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,paquete_id,servicio_id")] DETALLEPAQUETE dETALLEPAQUETE)
        {
            if (ModelState.IsValid)
            {
                db.DETALLEPAQUETES.Add(dETALLEPAQUETE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.servicio_id = new SelectList(db.SERVICIOS, "id", "nombre", dETALLEPAQUETE.servicio_id);
            ViewBag.paquete_id = new SelectList(db.PAQUETES, "id", "nombre", dETALLEPAQUETE.paquete_id);
            return View(dETALLEPAQUETE);
        }

        // GET: DetallePaquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPAQUETE dETALLEPAQUETE = db.DETALLEPAQUETES.Find(id);
            if (dETALLEPAQUETE == null)
            {
                return HttpNotFound();
            }
            ViewBag.servicio_id = new SelectList(db.SERVICIOS, "id", "nombre", dETALLEPAQUETE.servicio_id);
            ViewBag.paquete_id = new SelectList(db.PAQUETES, "id", "nombre", dETALLEPAQUETE.paquete_id);
            return View(dETALLEPAQUETE);
        }

        // POST: DetallePaquetes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,paquete_id,servicio_id")] DETALLEPAQUETE dETALLEPAQUETE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLEPAQUETE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.servicio_id = new SelectList(db.SERVICIOS, "id", "nombre", dETALLEPAQUETE.servicio_id);
            ViewBag.paquete_id = new SelectList(db.PAQUETES, "id", "nombre", dETALLEPAQUETE.paquete_id);
            return View(dETALLEPAQUETE);
        }

        // GET: DetallePaquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPAQUETE dETALLEPAQUETE = db.DETALLEPAQUETES.Find(id);
            if (dETALLEPAQUETE == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPAQUETE);
        }

        // POST: DetallePaquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLEPAQUETE dETALLEPAQUETE = db.DETALLEPAQUETES.Find(id);
            db.DETALLEPAQUETES.Remove(dETALLEPAQUETE);
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
