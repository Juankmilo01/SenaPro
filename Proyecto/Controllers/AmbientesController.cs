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
    public class AmbientesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Ambientes
        public ActionResult Index()
        {
            var ambientes = db.Ambientes.Include(a => a.Estado_Ambientes).Include(a => a.Persona);
            return View(ambientes.ToList());
        }

        // GET: Ambientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambientes ambientes = db.Ambientes.Find(id);
            if (ambientes == null)
            {
                return HttpNotFound();
            }
            return View(ambientes);
        }

        // GET: Ambientes/Create
        public ActionResult Create()
        {
            ViewBag.Estado_AmbientesID = new SelectList(db.Estado_Ambientes, "Estado_AmbientesID", "Nombre_Estado");
            ViewBag.personaID = new SelectList(db.Personas.Where(r => r.Roles.NombreRoles == "Instructor"), "personaID", "Nombre");
            return View();
        }

        // POST: Ambientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmbientesID,Numero_Ambiente,Ubicacion,Estado_AmbientesID,personaID")] Ambientes ambientes)
        {
            if (ModelState.IsValid)
            {
                
                db.Ambientes.Add(ambientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado_AmbientesID = new SelectList(db.Estado_Ambientes, "Estado_AmbientesID", "Nombre_Estado", ambientes.Estado_AmbientesID);
            ViewBag.personaID = new SelectList(db.Personas, "personaID", "Nombre", ambientes.personaID);
            return View(ambientes);
        }

        // GET: Ambientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambientes ambientes = db.Ambientes.Find(id);
            if (ambientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_AmbientesID = new SelectList(db.Estado_Ambientes, "Estado_AmbientesID", "Nombre_Estado", ambientes.Estado_AmbientesID);
            ViewBag.personaID = new SelectList(db.Personas.Where(r => r.Roles.NombreRoles == "Instructor"), "personaID", "Nombre", ambientes.personaID);
            return View(ambientes);
        }

        // POST: Ambientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmbientesID,Numero_Ambiente,Ubicacion,Estado_AmbientesID,personaID")] Ambientes ambientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_AmbientesID = new SelectList(db.Estado_Ambientes, "Estado_AmbientesID", "Nombre_Estado", ambientes.Estado_AmbientesID);
            ViewBag.personaID = new SelectList(db.Personas, "personaID", "Nombre", ambientes.personaID);
            return View(ambientes);
        }

        // GET: Ambientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambientes ambientes = db.Ambientes.Find(id);
            if (ambientes == null)
            {
                return HttpNotFound();
            }
            return View(ambientes);
        }

        // POST: Ambientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ambientes ambientes = db.Ambientes.Find(id);
            db.Ambientes.Remove(ambientes);
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
