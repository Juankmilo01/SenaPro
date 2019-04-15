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
    public class Estado_ElementosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Estado_Elementos
        public ActionResult Index()
        {
            return View(db.Estado_Elementos.ToList());
        }

        // GET: Estado_Elementos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Elementos estado_Elementos = db.Estado_Elementos.Find(id);
            if (estado_Elementos == null)
            {
                return HttpNotFound();
            }
            return View(estado_Elementos);
        }

        // GET: Estado_Elementos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado_Elementos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Estado_ElementosID,Nombre_Estado")] Estado_Elementos estado_Elementos)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Elementos.Add(estado_Elementos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Elementos);
        }

        // GET: Estado_Elementos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Elementos estado_Elementos = db.Estado_Elementos.Find(id);
            if (estado_Elementos == null)
            {
                return HttpNotFound();
            }
            return View(estado_Elementos);
        }

        // POST: Estado_Elementos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Estado_ElementosID,Nombre_Estado")] Estado_Elementos estado_Elementos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Elementos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Elementos);
        }

        // GET: Estado_Elementos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Elementos estado_Elementos = db.Estado_Elementos.Find(id);
            if (estado_Elementos == null)
            {
                return HttpNotFound();
            }
            return View(estado_Elementos);
        }

        // POST: Estado_Elementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Elementos estado_Elementos = db.Estado_Elementos.Find(id);
            db.Estado_Elementos.Remove(estado_Elementos);
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
