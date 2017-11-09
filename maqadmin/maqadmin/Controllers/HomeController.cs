using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using maqadmin.Models;
using System.Data.Entity;
using System.Data.Linq;


namespace maqadmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Prueba";

            return View();
        }

        [HttpGet]
        //http://localhost:2859/Home/AccesoUrlGet?token=fdsfds4543&pass=xxx&idlocal=1
        //http://localhost:2859/Home/AccesoUrlGet?token=xxxxxx
        public ActionResult AccesoUrlGet(string token)
        {
            var obj = new acceso();
            var resultado = obj.validaAcceso(token);

            if (resultado == true)
            {
               

                return RedirectToAction("Index", "bingoJuego");
            }

            else
            {
                return PartialView("_AccesoDenegado");
            }
        }


        public ActionResult BingoCiclico()
        {
            ViewData["hora"] = DateTime.Now.ToLongTimeString();


            using (var db = new bdloginEntities())
            {
                //video activo
                var videoActivo = db.bingoParametro.Where(p => p.idLocal == 1 && p.idEstadoJuego == 2).SingleOrDefault();
                if (videoActivo != null)
                {
                    ViewData["videoActivo"] = true;
                    ViewData["urlVideo"] = videoActivo.urlVideo;

                    return PartialView("_Video");
                }
            }



            //Obtiene siguiente numero
            var objBingo = new bingo();
            var numeroActual = objBingo.letraNumeroAleatorio();


            var objBingoFullViewModels = new BingoFullViewModels();
            using (var db = new bdloginEntities())
            {

                var bingoJuego = db.bingoJuego.First();
                var tbltoken = db.tbltoken.First();
                var bingoParametro = db.bingoParametro.First();

                //OBTIENE DATOS A MOSTRAR, 1 OBJETO POR MODELO
                objBingoFullViewModels.tbltoken = tbltoken;
                objBingoFullViewModels.bingoJuego = bingoJuego;
                objBingoFullViewModels.bingoParametro = bingoParametro;

            }
            return PartialView("_Bingo", objBingoFullViewModels);
        }


        public ActionResult Bingo()
        {
            ViewData["hora"] = DateTime.Now.ToLongTimeString();
            return View("Bingo");
        }




    }
}
