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
    public class NovedadesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Novedades
        public ActionResult Index()
        {
            return View(db.Novedades.ToList());
        }

        // GET: Novedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedades novedades = db.Novedades.Find(id);
            if (novedades == null)
            {
                return HttpNotFound();
            }
            return View(novedades);
        }

        // GET: Novedades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Novedades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NovedadesID,Codigo_Novedad,Descripcion,Fecha_Realizacion")] Novedades novedades)
        {
            
            if (ModelState.IsValid)
            {
                db.Novedades.Add(novedades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(novedades);
        }

        // GET: Novedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedades novedades = db.Novedades.Find(id);
            if (novedades == null)
            {
                return HttpNotFound();
            }
            return View(novedades);
        }

        // POST: Novedades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NovedadesID,Codigo_Novedad,Descripcion,Fecha_Realizacion")] Novedades novedades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(novedades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(novedades);
        }

        // GET: Novedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedades novedades = db.Novedades.Find(id);
            if (novedades == null)
            {
                return HttpNotFound();
            }
            return View(novedades);
        }

        // POST: Novedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Novedades novedades = db.Novedades.Find(id);
            db.Novedades.Remove(novedades);
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
