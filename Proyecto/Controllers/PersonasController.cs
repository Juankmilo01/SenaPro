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
    public class PersonasController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Personas
        public ActionResult Index()
        {
            var personas = db.Personas.Include(p => p.Ciudad).Include(p => p.Estado).Include(p => p.Programa).Include(p => p.Roles).Include(p => p.Sexo).Include(p => p.Tipo_Documento);
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.CuidadID = new SelectList(db.Ciudads, "CuidadID", "NombreCiudad");
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "NombreEstado");
            ViewBag.ProgramaID = new SelectList(db.Programas, "ProgramaID", "NombrePrograma");
            ViewBag.RolesID = new SelectList(db.Roles, "RolesID", "NombreRoles");
            ViewBag.SexoID = new SelectList(db.Sexoes, "SexoID", "NombreSexo");
            ViewBag.TipoDocumentoID = new SelectList(db.Tipo_Documento, "TipoDocumentoID", "NombreDocumento");
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personaID,Nombre,Apellido_Primario,Apellido_Segundo,TipoDocumentoID,NumerNumeroDocumento,SexoID,CuidadID,Direccion,Telefono,Numero_Celular,Email,ProgramaID,Numero_Ficha,EstadoID,RolesID,NovedadesID")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuidadID = new SelectList(db.Ciudads, "CuidadID", "NombreCiudad", persona.CuidadID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "NombreEstado", persona.EstadoID);
            ViewBag.ProgramaID = new SelectList(db.Programas, "ProgramaID", "NombrePrograma", persona.ProgramaID);
            ViewBag.RolesID = new SelectList(db.Roles, "RolesID", "NombreRoles", persona.RolesID);
            ViewBag.SexoID = new SelectList(db.Sexoes, "SexoID", "NombreSexo", persona.SexoID);
            ViewBag.TipoDocumentoID = new SelectList(db.Tipo_Documento, "TipoDocumentoID", "NombreDocumento", persona.TipoDocumentoID);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuidadID = new SelectList(db.Ciudads, "CuidadID", "NombreCiudad", persona.CuidadID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "NombreEstado", persona.EstadoID);
            ViewBag.ProgramaID = new SelectList(db.Programas, "ProgramaID", "NombrePrograma", persona.ProgramaID);
            ViewBag.RolesID = new SelectList(db.Roles, "RolesID", "NombreRoles", persona.RolesID);
            ViewBag.SexoID = new SelectList(db.Sexoes, "SexoID", "NombreSexo", persona.SexoID);
            ViewBag.TipoDocumentoID = new SelectList(db.Tipo_Documento, "TipoDocumentoID", "NombreDocumento", persona.TipoDocumentoID);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personaID,Nombre,Apellido_Primario,Apellido_Segundo,TipoDocumentoID,NumerNumeroDocumento,SexoID,CuidadID,Direccion,Telefono,Numero_Celular,Email,ProgramaID,Numero_Ficha,EstadoID,RolesID,NovedadesID")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuidadID = new SelectList(db.Ciudads, "CuidadID", "NombreCiudad", persona.CuidadID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "NombreEstado", persona.EstadoID);
            ViewBag.ProgramaID = new SelectList(db.Programas, "ProgramaID", "NombrePrograma", persona.ProgramaID);
            ViewBag.RolesID = new SelectList(db.Roles, "RolesID", "NombreRoles", persona.RolesID);
            ViewBag.SexoID = new SelectList(db.Sexoes, "SexoID", "NombreSexo", persona.SexoID);
            ViewBag.TipoDocumentoID = new SelectList(db.Tipo_Documento, "TipoDocumentoID", "NombreDocumento", persona.TipoDocumentoID);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
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
