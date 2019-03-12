using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.MVC.DAL;

namespace Proyecto.MVC.Controllers
{
    public class TipoIncidenciasController : Controller
    {
        private dbGeneralEntities db = new dbGeneralEntities();

        // GET: TipoIncidencias
        public ActionResult Index()
        {
            return View(db.TipoIncidencia.ToList());
        }

        // GET: TipoIncidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIncidencia tipoIncidencia = db.TipoIncidencia.Find(id);
            if (tipoIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tipoIncidencia);
        }

        // GET: TipoIncidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoIncidencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] TipoIncidencia tipoIncidencia)
        {
            if (ModelState.IsValid)
            {
                db.TipoIncidencia.Add(tipoIncidencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoIncidencia);
        }

        // GET: TipoIncidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIncidencia tipoIncidencia = db.TipoIncidencia.Find(id);
            if (tipoIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tipoIncidencia);
        }

        // POST: TipoIncidencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] TipoIncidencia tipoIncidencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoIncidencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoIncidencia);
        }

        // GET: TipoIncidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIncidencia tipoIncidencia = db.TipoIncidencia.Find(id);
            if (tipoIncidencia == null)
            {
                return HttpNotFound();
            }
            return View(tipoIncidencia);
        }

        // POST: TipoIncidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoIncidencia tipoIncidencia = db.TipoIncidencia.Find(id);
            db.TipoIncidencia.Remove(tipoIncidencia);
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
