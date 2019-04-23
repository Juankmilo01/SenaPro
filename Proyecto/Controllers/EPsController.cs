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
    public class EPsController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: EPs
        public ActionResult Index()
        {
            var ePs = db.EPs.Include(e => e.Elementos).Include(e => e.Prestamos);
            return View(ePs.ToList());
        }

        // GET: EPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EP eP = db.EPs.Find(id);
            if (eP == null)
            {
                return HttpNotFound();
            }
            return View(eP);
        }

        // GET: EPs/Create
        public ActionResult Create()
        {
            ViewBag.ElementosID = new SelectList(db.Elementos.Where(e => e.Estado_Elementos.Nombre_Estado == "Activo"), "ElementosID", "Numero_Serial");
            ViewBag.PrestamosID = new SelectList(db.Prestamos, "PrestamosID", "Fecha_Inicial");
            return View();
        }

        // POST: EPs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EPID,Estado_Entrega,Fecha_Inicial,Fecha_Final,Descripcion,ElementosID,PrestamosID")] EP eP)
        {
            if (ModelState.IsValid)
            {
                db.EPs.Add(eP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ElementosID = new SelectList(db.Elementos, "ElementosID", "Numero_Serial", eP.ElementosID);
            ViewBag.PrestamosID = new SelectList(db.Prestamos, "PrestamosID", "Estado_Disposicion", eP.PrestamosID);
            return View(eP);
        }

        // GET: EPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EP eP = db.EPs.Find(id);
            if (eP == null)
            {
                return HttpNotFound();
            }
            ViewBag.ElementosID = new SelectList(db.Elementos, "ElementosID", "Numero_Serial", eP.ElementosID);
            ViewBag.PrestamosID = new SelectList(db.Prestamos, "PrestamosID", "Estado_Disposicion", eP.PrestamosID);
            return View(eP);
        }

        // POST: EPs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EPID,Estado_Entrega,Fecha_Inicial,Fecha_Final,Descripcion,ElementosID,PrestamosID")] EP eP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ElementosID = new SelectList(db.Elementos, "ElementosID", "Numero_Serial", eP.ElementosID);
            ViewBag.PrestamosID = new SelectList(db.Prestamos, "PrestamosID", "Estado_Disposicion", eP.PrestamosID);
            return View(eP);
        }

        // GET: EPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EP eP = db.EPs.Find(id);
            if (eP == null)
            {
                return HttpNotFound();
            }
            return View(eP);
        }

        // POST: EPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EP eP = db.EPs.Find(id);
            db.EPs.Remove(eP);
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
