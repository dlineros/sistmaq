using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using maqadmin.Models;

namespace maqadmin.Controllers
{ 
    public class CartonController : Controller
    {
        private bdloginEntities db = new bdloginEntities();

        //
        // GET: /Carton/

        public ViewResult Index()
        {
            return View(db.carton.ToList());
        }

        //
        // GET: /Carton/Details/5

        public ViewResult Details(int id)
        {
            carton carton = db.carton.Single(c => c.id == id);
            return View(carton);
        }

        //
        // GET: /Carton/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Carton/Create

        [HttpPost]
        public ActionResult Create(carton carton)
        {
            if (ModelState.IsValid)
            {
                db.carton.AddObject(carton);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(carton);
        }
        
        //
        // GET: /Carton/Edit/5
 
        public ActionResult Edit(int id)
        {
            carton carton = db.carton.Single(c => c.id == id);
            return View(carton);
        }

        //
        // POST: /Carton/Edit/5

        [HttpPost]
        public ActionResult Edit(carton carton)
        {
            if (ModelState.IsValid)
            {
                db.carton.Attach(carton);
                db.ObjectStateManager.ChangeObjectState(carton, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carton);
        }

        //
        // GET: /Carton/Delete/5
 
        public ActionResult Delete(int id)
        {
            carton carton = db.carton.Single(c => c.id == id);
            return View(carton);
        }

        //
        // POST: /Carton/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            carton carton = db.carton.Single(c => c.id == id);
            db.carton.DeleteObject(carton);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}