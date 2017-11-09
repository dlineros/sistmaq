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
    public class bingoJuegoController : Controller
    {
        private bdloginEntities db = new bdloginEntities();

        //
        // GET: /bingoJuego/

        public ViewResult Index()
        {
            return View(db.bingoJuego.ToList());
        }

        //
        // GET: /bingoJuego/Details/5

        public ViewResult Details(int id)
        {
            bingoJuego bingojuego = db.bingoJuego.Single(b => b.idbingo == id);
            return View(bingojuego);
        }

        //
        // GET: /bingoJuego/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /bingoJuego/Create

        [HttpPost]
        public ActionResult Create(bingoJuego bingojuego)
        {
            if (ModelState.IsValid)
            {
                db.bingoJuego.AddObject(bingojuego);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(bingojuego);
        }
        
        //
        // GET: /bingoJuego/Edit/5
 
        public ActionResult Edit(int id)
        {
            bingoJuego bingojuego = db.bingoJuego.Single(b => b.idbingo == id);
            return View(bingojuego);
        }

        //
        // POST: /bingoJuego/Edit/5

        [HttpPost]
        public ActionResult Edit(bingoJuego bingojuego)
        {
            if (ModelState.IsValid)
            {
                db.bingoJuego.Attach(bingojuego);
                db.ObjectStateManager.ChangeObjectState(bingojuego, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bingojuego);
        }

        //
        // GET: /bingoJuego/Delete/5
 
        public ActionResult Delete(int id)
        {
            bingoJuego bingojuego = db.bingoJuego.Single(b => b.idbingo == id);
            return View(bingojuego);
        }

        //
        // POST: /bingoJuego/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            bingoJuego bingojuego = db.bingoJuego.Single(b => b.idbingo == id);
            db.bingoJuego.DeleteObject(bingojuego);
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