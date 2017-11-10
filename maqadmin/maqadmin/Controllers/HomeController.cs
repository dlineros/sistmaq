using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using maqadmin.Models;
using System.Data.Entity;
using System.Data.Linq;
using maqadmin.Hubs;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.Security;


namespace maqadmin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Prueba";
            ViewData["hora"] = DateTime.Now.ToLongTimeString();
            return View();
        }

       
        [HttpGet]
        //http://localhost:2859/Home/AccesoUrlGet?token=fdsfds4543&pass=xxx&idlocal=1
        //http://localhost:2859/Home/AccesoUrlGet?token=xxxxxx
        public ActionResult AccesoUrlGet(string token)
        {
            var obj = new acceso();

            var resultado = obj.validaAcceso(token);
            Session["acceso"] = resultado;

            if (resultado)
            {                
                FormsAuthentication.SetAuthCookie(token, true);
                return RedirectToAction("Index", "bingoJuego");

            }
            else
            {
                return PartialView("_AccesoDenegado");
            }
        }        

        
        public string client()
        {
            var client = new WebClient();
            var salida = client.DownloadString("http://localhost:51690/home/BingoCiclico");
            return salida;
        }



        public ActionResult BingoCiclico()
        {
            ViewData["hora"] = DateTime.Now.ToLongTimeString();

            using (var db = new bdloginEntities())
            {

                //video activo(Ya se esta ejecutando, no debe refrezcar) y estado2: Muestra el video
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

        /// <summary>
        /// Obtiene estado del video cuando esta activado
        /// 2: Muestra video
        /// </summary>
        /// <returns></returns>
        public bool ObtieneEstadoVideo()
        {
            var salida = false;
            using (var db = new bdloginEntities())
            {

                var videoActivo = db.bingoParametro.Where(p => p.idLocal == Convert.ToInt32(Session["idlocal"]) && p.idEstadoJuego == 2 && p.videoActivo == true).SingleOrDefault();
                if (videoActivo != null)
                {
                    salida = true;
                }
            }
            return salida;
        }

        public void SeteaEstadoVideo(bool estado)
        {
            using (var db = new bdloginEntities())
            {
                var videoActivo = db.bingoParametro.Where(p => p.idLocal == Convert.ToInt32(Session["idlocal"])).SingleOrDefault();
                videoActivo.videoActivo = estado;
                db.SaveChanges();
            }
        }



        public int obtieneEsperaNumeroSeq()
        {
            var salida = 0;
            using (var db = new bdloginEntities())
            {

                var objParametro = db.bingoParametro.Where(p => p.idLocal == Convert.ToInt32(Session["idlocal"])).SingleOrDefault();
                if (objParametro != null)
                {
                    salida = objParametro.esperaNumeroSeg;
                }
            }
            return salida;
        }
    }
}
