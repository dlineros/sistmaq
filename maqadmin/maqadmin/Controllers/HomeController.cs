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
        //http://localhost:2859/Home/AccesoUrlGet?usuario=dlineros&pass=xxx&idlocal=1
        public ActionResult AccesoUrlGet(string usuario, string pass,int idlocal)
        {
            //ViewBag.Message = "Welcome to ASP.NET MVC!";
            //var id = ControllerContext.RouteData.GetRequiredString("id");
            var obj = new acceso();
            var resultado = obj.validaAcceso(usuario,pass,idlocal);

            if (resultado == true)
            {
                return View("Index");
            }

            else {

                return PartialView("_AccesoDenegado");
            }       
            
          
            
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult BingoCiclico()
        {
            ViewData["hora"] = DateTime.Now.ToLongTimeString();

            //Obtiene siguiente numero
             var objBingo = new bingo();
             var numeroActual = objBingo.letraNumeroAleatorio();


            var objBingoFullViewModels=new BingoFullViewModels();
            using (var db = new bdloginEntities()) {


               

                var bingoJuego = db.bingoJuego.First();
                var tblusuario = db.tblusuario.First();
                var bingoParametro = db.bingoParametro.First();

                //OBTIENE DATOS A MOSTRAR, 1 OBJETO POR MODELO
                objBingoFullViewModels.tblusuario = tblusuario;
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
