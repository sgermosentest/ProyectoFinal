using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using Productos.Models;

namespace Productos.Controllers
{
    public class ImagenesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Imagenes
        public async Task<ActionResult> Index()
        {
            var imagens = db.Imagenes.Include(i => i.Producto);
            return View(await imagens.ToListAsync());
        }

        // GET: Imagenes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = await db.Imagenes.FindAsync(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // GET: Imagenes/Create
        public ActionResult Create()
        {
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion");
            return View();
        }

        // POST: Imagenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ImagenId,ProductoId,Descripcion,Ruta")] Imagen imagen)
        {
            if (ModelState.IsValid)
            {
                db.Imagenes.Add(imagen);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", imagen.ProductoId);
            return View(imagen);
        }

        // GET: Imagenes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = await db.Imagenes.FindAsync(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", imagen.ProductoId);
            return View(imagen);
        }

        // POST: Imagenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ImagenId,ProductoId,Descripcion,Ruta")] Imagen imagen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagen).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", imagen.ProductoId);
            return View(imagen);
        }

        // GET: Imagenes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = await db.Imagenes.FindAsync(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // POST: Imagenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Imagen imagen = await db.Imagenes.FindAsync(id);
            db.Imagenes.Remove(imagen);
            await db.SaveChangesAsync();
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
