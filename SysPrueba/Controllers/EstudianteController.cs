using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysPrueba.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace SysPrueba.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            try
            {
                using (DBEntity db = new DBEntity())
                {
                    var Estudiante = db.Estudiante.Include(y => y.Telefonos).ToList();
                    return View(Estudiante);
                }

                
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiante Est, IEnumerable<string> Telefono)
        {
            try
            {
                using (DBEntity db = new DBEntity())
                {
                    Est.Status = true;
                    db.Estudiante.Add(Est);
                    db.SaveChanges();

                    List<Telefono> Telefonos = new List<Models.Telefono>();

                    foreach(var num in Telefono)
                    {
                        Telefonos.Add(new Telefono { Telf = num, Estudiante_id = Est.idEstudiante});
                    }

                    db.Telefono.AddRange(Telefonos);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            try
            {
                using (DBEntity db = new DBEntity())
                {
                    var Estudiante = db.Estudiante.Include(y => y.Telefonos).FirstOrDefault(y => y.idEstudiante == id);

                    if (Estudiante == null)
                        return HttpNotFound();
                    
                    return View(Estudiante);
                }
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
