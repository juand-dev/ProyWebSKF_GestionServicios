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
    public class TipoServiciosController : Controller
    {
        private BdSKF_GestionServiciosEntities db = new BdSKF_GestionServiciosEntities();

        // GET: TipoServicios
        public ActionResult Index()
        {
            return View(db.TIPOSERVICIOS.ToList());
        }

        // GET: TipoServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOSERVICIO tIPOSERVICIO = db.TIPOSERVICIOS.Find(id);
            if (tIPOSERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOSERVICIO);
        }

        // GET: TipoServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,acronimo,descripcion")] TIPOSERVICIO tIPOSERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.TIPOSERVICIOS.Add(tIPOSERVICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOSERVICIO);
        }

        // GET: TipoServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOSERVICIO tIPOSERVICIO = db.TIPOSERVICIOS.Find(id);
            if (tIPOSERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOSERVICIO);
        }

        // POST: TipoServicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,acronimo,descripcion")] TIPOSERVICIO tIPOSERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOSERVICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOSERVICIO);
        }

        // GET: TipoServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOSERVICIO tIPOSERVICIO = db.TIPOSERVICIOS.Find(id);
            if (tIPOSERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOSERVICIO);
        }

        // POST: TipoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOSERVICIO tIPOSERVICIO = db.TIPOSERVICIOS.Find(id);
            db.TIPOSERVICIOS.Remove(tIPOSERVICIO);
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
