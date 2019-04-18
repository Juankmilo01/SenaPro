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
    public class Tipo_ElementosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Tipo_Elementos
        public ActionResult Index()
        {
            return View(db.Tipo_Elementos.ToList());
        }

        // GET: Tipo_Elementos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Elementos tipo_Elementos = db.Tipo_Elementos.Find(id);
            if (tipo_Elementos == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Elementos);
        }

        // GET: Tipo_Elementos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Elementos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tipo_ElementosID,Nombre_TipoElemento")] Tipo_Elementos tipo_Elementos)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Elementos.Add(tipo_Elementos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Elementos);
        }

        // GET: Tipo_Elementos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Elementos tipo_Elementos = db.Tipo_Elementos.Find(id);
            if (tipo_Elementos == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Elementos);
        }

        // POST: Tipo_Elementos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tipo_ElementosID,Nombre_TipoElemento")] Tipo_Elementos tipo_Elementos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Elementos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Elementos);
        }

        // GET: Tipo_Elementos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Elementos tipo_Elementos = db.Tipo_Elementos.Find(id);
            if (tipo_Elementos == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Elementos);
        }

        // POST: Tipo_Elementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Elementos tipo_Elementos = db.Tipo_Elementos.Find(id);
            db.Tipo_Elementos.Remove(tipo_Elementos);
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
