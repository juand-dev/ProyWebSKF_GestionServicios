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
    public class ServiciosController : Controller
    {
        private BdSKF_GestionServiciosEntities db = new BdSKF_GestionServiciosEntities();

        // GET: Servicios
        public ActionResult Index()
        {
            var sERVICIOS = db.SERVICIOS.Include(s => s.TIPOSERVICIO);
            return View(sERVICIOS.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIOS.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.tipoServicio_id = new SelectList(db.TIPOSERVICIOS, "id", "acronimo");
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,tipoServicio_id,costo")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.SERVICIOS.Add(sERVICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoServicio_id = new SelectList(db.TIPOSERVICIOS, "id", "acronimo", sERVICIO.tipoServicio_id);
            return View(sERVICIO);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIOS.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoServicio_id = new SelectList(db.TIPOSERVICIOS, "id", "acronimo", sERVICIO.tipoServicio_id);
            return View(sERVICIO);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,tipoServicio_id,costo")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoServicio_id = new SelectList(db.TIPOSERVICIOS, "id", "acronimo", sERVICIO.tipoServicio_id);
            return View(sERVICIO);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIOS.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SERVICIO sERVICIO = db.SERVICIOS.Find(id);
            db.SERVICIOS.Remove(sERVICIO);
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
