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
    public class tblusuarioController : Controller
    {
        private bdloginEntities db = new bdloginEntities();

        //
        // GET: /tblusuario/

        public ViewResult Index()
        {
            return View(db.tblusuario.ToList());
        }

        //
        // GET: /tblusuario/Details/5

        public ViewResult Details(int id)
        {
            tblusuario tblusuario = db.tblusuario.Single(t => t.idusuario == id);
            return View(tblusuario);
        }

        //
        // GET: /tblusuario/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /tblusuario/Create

        [HttpPost]
        public ActionResult Create(tblusuario tblusuario)
        {
            if (ModelState.IsValid)
            {
                db.tblusuario.AddObject(tblusuario);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tblusuario);
        }
        
        //
        // GET: /tblusuario/Edit/5
 
        public ActionResult Edit(int id)
        {
            tblusuario tblusuario = db.tblusuario.Single(t => t.idusuario == id);
            return View(tblusuario);
        }

        //
        // POST: /tblusuario/Edit/5

        [HttpPost]
        public ActionResult Edit(tblusuario tblusuario)
        {
            if (ModelState.IsValid)
            {
                db.tblusuario.Attach(tblusuario);
                db.ObjectStateManager.ChangeObjectState(tblusuario, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblusuario);
        }

        //
        // GET: /tblusuario/Delete/5
 
        public ActionResult Delete(int id)
        {
            tblusuario tblusuario = db.tblusuario.Single(t => t.idusuario == id);
            return View(tblusuario);
        }

        //
        // POST: /tblusuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            tblusuario tblusuario = db.tblusuario.Single(t => t.idusuario == id);
            db.tblusuario.DeleteObject(tblusuario);
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