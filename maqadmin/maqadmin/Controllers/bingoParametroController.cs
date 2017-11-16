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
    [Authorize]
    public class bingoParametroController : Controller
    {
        private bdloginEntities db = new bdloginEntities();

        //
        // GET: /bingoParametro/

        public ViewResult Index()
        {
            var bingoparametro = db.bingoParametro.Include("estadoJuego");
            return View(bingoparametro.ToList());
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
            ViewBag.idEstadoJuego = new SelectList(db.estadoJuego, "idestado", "nombre");
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

            ViewBag.idEstadoJuego = new SelectList(db.estadoJuego, "idestado", "nombre", bingoparametro.idEstadoJuego);
            return View(bingoparametro);
        }
        
        //
        // GET: /bingoParametro/Edit/5
 
        public ActionResult Edit(int id)
        {
            bingoParametro bingoparametro = db.bingoParametro.Single(b => b.idParametro == id);
            ViewBag.idEstadoJuego = new SelectList(db.estadoJuego, "idestado", "nombre", bingoparametro.idEstadoJuego);
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
            ViewBag.idEstadoJuego = new SelectList(db.estadoJuego, "idestado", "nombre", bingoparametro.idEstadoJuego);
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

        public ActionResult Limpiar(int id)
        {
            bingoJuego bingojuego = db.bingoJuego.Single(b => b.idbingo == id);
            bingojuego.B1 = false;
            bingojuego.B2 = false;
            bingojuego.B3 = false;
            bingojuego.B4 = false;
            bingojuego.B5 = false;
            bingojuego.B6 = false;
            bingojuego.B7 = false;
            bingojuego.B8 = false;
            bingojuego.B9 = false;
            bingojuego.B10 = false;
            bingojuego.B11 = false;
            bingojuego.B12 = false;
            bingojuego.B13 = false;
            bingojuego.B14 = false;
            bingojuego.B15 = false;
            bingojuego.I16 = false;
            bingojuego.I17 = false;
            bingojuego.I18 = false;
            bingojuego.I19 = false;
            bingojuego.I20 = false;
            bingojuego.I21 = false;
            bingojuego.I22 = false;
            bingojuego.I23 = false;
            bingojuego.I24 = false;
            bingojuego.I25 = false;
            bingojuego.I26 = false;
            bingojuego.I27 = false;
            bingojuego.I28 = false;
            bingojuego.I29 = false;
            bingojuego.I30 = false;
            bingojuego.N31 = false;
            bingojuego.N32 = false;
            bingojuego.N33 = false;
            bingojuego.N34 = false;
            bingojuego.N35 = false;
            bingojuego.N36 = false;
            bingojuego.N37 = false;
            bingojuego.N38 = false;
            bingojuego.N39 = false;
            bingojuego.N40 = false;
            bingojuego.N41 = false;
            bingojuego.N42 = false;
            bingojuego.N43 = false;
            bingojuego.N44 = false;
            bingojuego.N45 = false;
            bingojuego.G46 = false;
            bingojuego.G47 = false;
            bingojuego.G48 = false;
            bingojuego.G49 = false;
            bingojuego.G50 = false;
            bingojuego.G51 = false;
            bingojuego.G52 = false;
            bingojuego.G53 = false;
            bingojuego.G54 = false;
            bingojuego.G55 = false;
            bingojuego.G56 = false;
            bingojuego.G57 = false;
            bingojuego.G58 = false;
            bingojuego.G59 = false;
            bingojuego.G60 = false;
            bingojuego.O61 = false;
            bingojuego.O62 = false;
            bingojuego.O63 = false;
            bingojuego.O64 = false;
            bingojuego.O65 = false;
            bingojuego.O66 = false;
            bingojuego.O67 = false;
            bingojuego.O68 = false;
            bingojuego.O69 = false;
            bingojuego.O70 = false;
            bingojuego.O71 = false;
            bingojuego.O72 = false;
            bingojuego.O73 = false;
            bingojuego.O74 = false;
            bingojuego.O75 = false;
            bingojuego.inicioJuego = DateTime.UtcNow;
            bingojuego.finjuego = null;
            bingojuego.ultimonumero = null;

            var bingoparametro = db.bingoParametro.Where(p => p.idLocal == bingojuego.idlocal).Single();
            bingoparametro.idEstadoJuego = 4; //pausado
            bingoparametro.videoActivo = false;

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        
        public ActionResult Pausar(int id)
        {
            var objbingoparametro = db.bingoParametro.Where(p => p.idParametro == id).Single();
            objbingoparametro.idEstadoJuego = 4;
            db.SaveChanges();
            return RedirectToAction("Index");

       
        }

        
        public ActionResult Video(int id)
        {
            var objbingoparametro = db.bingoParametro.Where(p => p.idParametro == id).Single();
            objbingoparametro.idEstadoJuego = 2;
            objbingoparametro.videoActivo = false;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        
        public ActionResult ActivarJuego(int id)
        {
            var objbingoparametro = db.bingoParametro.Where(p => p.idParametro == id).Single();
            objbingoparametro.idEstadoJuego = 3;
            objbingoparametro.videoActivo = false;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

       
         public ActionResult FinalizarJuego(int id)
        {
            var objbingoparametro = db.bingoParametro.Where(p => p.idParametro == id).Single();
            objbingoparametro.idEstadoJuego = 1;
            objbingoparametro.videoActivo = false;
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