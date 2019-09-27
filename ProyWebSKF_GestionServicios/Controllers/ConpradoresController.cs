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
    public class ConpradoresController : Controller
    {
        private BdSKF_GestionServiciosEntities db = new BdSKF_GestionServiciosEntities();

        // GET: Conpradores
        public ActionResult Index()
        {
            var cOMPRADORES = db.COMPRADORES.Include(c => c.PERSONA);
            return View(cOMPRADORES.ToList());
        }

        // GET: Conpradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRADORE cOMPRADORE = db.COMPRADORES.Find(id);
            if (cOMPRADORE == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRADORE);
        }

        // GET: Conpradores/Create
        public ActionResult Create()
        {
            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre");
            return View();
        }

        // POST: Conpradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "persona_id,enmail,sexo")] COMPRADORE cOMPRADORE)
        {
            if (ModelState.IsValid)
            {
                db.COMPRADORES.Add(cOMPRADORE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre", cOMPRADORE.persona_id);
            return View(cOMPRADORE);
        }

        // GET: Conpradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRADORE cOMPRADORE = db.COMPRADORES.Find(id);
            if (cOMPRADORE == null)
            {
                return HttpNotFound();
            }
            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre", cOMPRADORE.persona_id);
            return View(cOMPRADORE);
        }

        // POST: Conpradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "persona_id,enmail,sexo")] COMPRADORE cOMPRADORE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPRADORE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.persona_id = new SelectList(db.PERSONAS, "id", "nombre", cOMPRADORE.persona_id);
            return View(cOMPRADORE);
        }

        // GET: Conpradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRADORE cOMPRADORE = db.COMPRADORES.Find(id);
            if (cOMPRADORE == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRADORE);
        }

        // POST: Conpradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMPRADORE cOMPRADORE = db.COMPRADORES.Find(id);
            db.COMPRADORES.Remove(cOMPRADORE);
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
