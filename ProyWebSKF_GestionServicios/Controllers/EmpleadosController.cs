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
    public class EmpleadosController : Controller
    {
        private BdSKF_GestionServiciosEntities db = new BdSKF_GestionServiciosEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.EMPLEADOS.Include(e => e.CARGO).Include(e => e.PERSONA);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO empleado = db.EMPLEADOS.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.cargo_id = new SelectList(db.CARGOS, "id", "nombre");
            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "persona_id,cargo_id,fechaIngreso,fechaCese")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADOS.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cargo_id = new SelectList(db.CARGOS, "id", "nombre", eMPLEADO.cargo_id);
            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre", eMPLEADO.persona_id);
            return View(eMPLEADO);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargo_id = new SelectList(db.CARGOS, "id", "nombre", eMPLEADO.cargo_id);
            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre", eMPLEADO.persona_id);
            return View(eMPLEADO);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "persona_id,cargo_id,fechaIngreso,fechaCese")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cargo_id = new SelectList(db.CARGOS, "id", "nombre", eMPLEADO.cargo_id);
            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre", eMPLEADO.persona_id);
            return View(eMPLEADO);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            db.EMPLEADOS.Remove(eMPLEADO);
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
