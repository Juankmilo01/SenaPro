using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Senalai.Models;

namespace Proyecto.Controllers
{
    public class Estado_AmbientesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Estado_Ambientes
        public ActionResult Index()
        {
            return View(db.Estado_Ambientes.ToList());
        }

        // GET: Estado_Ambientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Ambientes estado_Ambientes = db.Estado_Ambientes.Find(id);
            if (estado_Ambientes == null)
            {
                return HttpNotFound();
            }
            return View(estado_Ambientes);
        }

        // GET: Estado_Ambientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado_Ambientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Estado_AmbientesID,Nombre_Estado")] Estado_Ambientes estado_Ambientes)
        {
            bool existEst = db.Estado_Ambientes.Any(e => e.Nombre_Estado == estado_Ambientes.Nombre_Estado);
            if (existEst)
            {
                ModelState.AddModelError("Nombre_Estado", "El Estado ya existe!");
            }
            if (ModelState.IsValid)
            {
                db.Estado_Ambientes.Add(estado_Ambientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Ambientes);
        }

        // GET: Estado_Ambientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Ambientes estado_Ambientes = db.Estado_Ambientes.Find(id);
            if (estado_Ambientes == null)
            {
                return HttpNotFound();
            }
            return View(estado_Ambientes);
        }

        // POST: Estado_Ambientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Estado_AmbientesID,Nombre_Estado")] Estado_Ambientes estado_Ambientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Ambientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Ambientes);
        }

        // GET: Estado_Ambientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Ambientes estado_Ambientes = db.Estado_Ambientes.Find(id);
            if (estado_Ambientes == null)
            {
                return HttpNotFound();
            }
            return View(estado_Ambientes);
        }

        // POST: Estado_Ambientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Ambientes estado_Ambientes = db.Estado_Ambientes.Find(id);
            db.Estado_Ambientes.Remove(estado_Ambientes);
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
