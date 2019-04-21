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
    public class ElementosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Elementos
        public ActionResult Index()
        {
            var elementos = db.Elementos.Include(e => e.Ambientes).Include(e => e.Estado_Elementos).Include(e => e.Tipo_Elementos);
            return View(elementos.ToList());
        }

        // GET: Elementos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elementos elementos = db.Elementos.Find(id);
            if (elementos == null)
            {
                return HttpNotFound();
            }
            return View(elementos);
        }

        // GET: Elementos/Create
        public ActionResult Create()
        {
            ViewBag.AmbientesID = new SelectList(db.Ambientes, "AmbientesID", "Numero_Ambiente");
            ViewBag.Estado_ElementosID = new SelectList(db.Estado_Elementos, "Estado_ElementosID", "Nombre_Estado");
            ViewBag.Tipo_ElementosID = new SelectList(db.Tipo_Elementos, "Tipo_ElementosID", "Nombre_TipoElemento");
            return View();
        }

        // POST: Elementos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ElementosID,Numero_Serial,Placa_Equipo,Ubicacion,Detalle,Marca,Tipo_ElementosID,Estado_ElementosID,AmbientesID")] Elementos elementos)
        {
            // variable tipo booleana para consultar en la base datos para consultar que existe o no existe en la base de datos
            bool existNumSerial = db.Elementos.Any(e => e.Numero_Serial == elementos.Numero_Serial);
            bool existPlaca = db.Elementos.Any(p => p.Placa_Equipo == elementos.Placa_Equipo);
            if (existNumSerial)
            {
                ModelState.AddModelError("Numero_Serial", "El número de serial ya existe!");
            }else if (existPlaca)
            {
                ModelState.AddModelError("Placa_Equipo", "El número de la placa ya existe!");
            }
            if (ModelState.IsValid)
            {
                
                db.Elementos.Add(elementos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AmbientesID = new SelectList(db.Ambientes, "AmbientesID", "Numero_Ambiente", elementos.AmbientesID);
            ViewBag.Estado_ElementosID = new SelectList(db.Estado_Elementos, "Estado_ElementosID", "Nombre_Estado", elementos.Estado_ElementosID);
            ViewBag.Tipo_ElementosID = new SelectList(db.Tipo_Elementos, "Tipo_ElementosID", "Nombre_TipoElemento", elementos.Tipo_ElementosID);
            return View(elementos);
        }

        // GET: Elementos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elementos elementos = db.Elementos.Find(id);
            if (elementos == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmbientesID = new SelectList(db.Ambientes, "AmbientesID", "Numero_Ambiente", elementos.AmbientesID);
            ViewBag.Estado_ElementosID = new SelectList(db.Estado_Elementos, "Estado_ElementosID", "Nombre_Estado", elementos.Estado_ElementosID);
            ViewBag.Tipo_ElementosID = new SelectList(db.Tipo_Elementos, "Tipo_ElementosID", "Nombre_TipoElemento", elementos.Tipo_ElementosID);
            return View(elementos);
        }

        // POST: Elementos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ElementosID,Numero_Serial,Placa_Equipo,Ubicacion,Detalle,Marca,Tipo_ElementosID,Estado_ElementosID,AmbientesID")] Elementos elementos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elementos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AmbientesID = new SelectList(db.Ambientes, "AmbientesID", "Numero_Ambiente", elementos.AmbientesID);
            ViewBag.Estado_ElementosID = new SelectList(db.Estado_Elementos, "Estado_ElementosID", "Nombre_Estado", elementos.Estado_ElementosID);
            ViewBag.Tipo_ElementosID = new SelectList(db.Tipo_Elementos, "Tipo_ElementosID", "Nombre_TipoElemento", elementos.Tipo_ElementosID);
            return View(elementos);
        }

        // GET: Elementos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elementos elementos = db.Elementos.Find(id);
            if (elementos == null)
            {
                return HttpNotFound();
            }
            return View(elementos);
        }

        // POST: Elementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elementos elementos = db.Elementos.Find(id);
            db.Elementos.Remove(elementos);
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
