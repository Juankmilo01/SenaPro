﻿using System;
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
    public class CiudadsController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Ciudads
        public ActionResult Index()
        {
            var ciudads = db.Ciudads.Include(c => c.Departamento);
            return View(ciudads.ToList());
        }

        // GET: Ciudads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudads.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudads/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento");
            return View();
        }

        // POST: Ciudads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CuidadID,NombreCiudad,DepartamentoID")] Ciudad ciudad)
        {
            bool existCiu = db.Ciudads.Any(e => e.NombreCiudad == ciudad.NombreCiudad);
            if (existCiu)
            {
                ModelState.AddModelError("NombreCiudad", "La Ciudad ya existe!");
            }
            if (ModelState.IsValid)
            {
                db.Ciudads.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento", ciudad.DepartamentoID);
            return View(ciudad);
        }

        // GET: Ciudads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudads.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento", ciudad.DepartamentoID);
            return View(ciudad);
        }

        // POST: Ciudads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CuidadID,NombreCiudad,DepartamentoID")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento", ciudad.DepartamentoID);
            return View(ciudad);
        }

        // GET: Ciudads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudads.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudad ciudad = db.Ciudads.Find(id);
            db.Ciudads.Remove(ciudad);
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
