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
    public class bingoParametroController : Controller
    {
        private bdloginEntities db = new bdloginEntities();

        //
        // GET: /bingoParametro/

        public ViewResult Index()
        {
            return View(db.bingoParametro.ToList());
        }

        //
        // GET: /bingoParametro/Details/5

        public ViewResult Details(int id)
        {
            bingoParametro bingoparametro = db.bingoParametro.Single(b => b.idParametro == id);
            return View(bingoparametro);
        }

        //
        // GET: /bingoParametro/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /bingoParametro/Create

        [HttpPost]
        public ActionResult Create(bingoParametro bingoparametro)
        {
            if (ModelState.IsValid)
            {
                db.bingoParametro.AddObject(bingoparametro);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(bingoparametro);
        }
        
        //
        // GET: /bingoParametro/Edit/5
 
        public ActionResult Edit(int id)
        {
            bingoParametro bingoparametro = db.bingoParametro.Single(b => b.idParametro == id);
            return View(bingoparametro);
        }

        //
        // POST: /bingoParametro/Edit/5

        [HttpPost]
        public ActionResult Edit(bingoParametro bingoparametro)
        {
            if (ModelState.IsValid)
            {
                db.bingoParametro.Attach(bingoparametro);
                db.ObjectStateManager.ChangeObjectState(bingoparametro, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bingoparametro);
        }

        //
        // GET: /bingoParametro/Delete/5
 
        public ActionResult Delete(int id)
        {
            bingoParametro bingoparametro = db.bingoParametro.Single(b => b.idParametro == id);
            return View(bingoparametro);
        }

        //
        // POST: /bingoParametro/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            bingoParametro bingoparametro = db.bingoParametro.Single(b => b.idParametro == id);
            db.bingoParametro.DeleteObject(bingoparametro);
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