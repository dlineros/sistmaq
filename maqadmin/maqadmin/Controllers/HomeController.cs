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
using Microsoft.AspNet.SignalR;


namespace maqadmin.Controllers
{

    public class HomeController : Controller
    {
        [System.Web.Mvc.Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Prueba";
            var x=User.Identity.Name;
            var sesion = Session["idlocal"];
            ViewData["hora"] = DateTime.Now.ToLongTimeString();
            return View();
        }


        [HttpGet]
        //http://localhost:2859/Home/AccesoUrlGet?token=fdsfds4543&pass=xxx&idlocal=1
        //http://localhost:2859/Home/AccesoUrlGet?token=xxxxxx
        public ActionResult AccesoUrlGet(string token)
        {
        
            using (var db = new bdloginEntities())
                {

                    var tbltoken = (from p in db.tbltoken
                                     where p.token == token
                                     select p).SingleOrDefault();

                    if (tbltoken != null)
                    {

                        //FormsAuthentication.SetAuthCookie(token, true);
                        FormsAuthentication.SetAuthCookie(tbltoken.idLocal.ToString(), true);
                        Session["idlocal"] = tbltoken.idLocal;
                        var parametro = db.bingoParametro.Where(p => p.idLocal == tbltoken.idLocal).Single();
                        parametro.videoActivo = false;
                        db.SaveChanges();
                        return RedirectToAction("Index", "bingoJuego");
                    }

                    return PartialView("_AccesoDenegado");
                }
           
        }


        public string ClientDownload(int idLocal)
        {
            //var sesion = Session["idlocal"];
            //var x = User.Identity.Name;
            var client = new WebClient();
            string salida;
            var url = string.Format("http://localhost:51690/home/BingoCiclico?varidlocal={0}", idLocal);
            try
            {
                  salida = client.DownloadString(url);
            }
            catch (Exception)
            {

                return "";
            }
           
            return salida;
        }

        public ActionResult BingoCiclico(string varidlocal)
        {

            ViewData["hora"] = DateTime.Now.ToLongTimeString();
            int idlocal = Convert.ToInt32(varidlocal);
            

            using (var db = new bdloginEntities())
            {
                
                //video activo(Ya se esta ejecutando, no debe refrezcar) y estado2: Muestra el video
                var videoActivo = db.bingoParametro.Where(p => p.idLocal == idlocal && p.idEstadoJuego == 2).SingleOrDefault();
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


        void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var objbingo = new HomeController();
 
            int idLocal = Convert.ToInt32(User.Identity.Name);

            var videoActivo = objbingo.ObtieneEstadoVideo();
            var context = GlobalHost.ConnectionManager.GetHubContext<signal>();
            if (videoActivo == false)
            {
                var salida = objbingo.ClientDownload(1);
                context.Clients.All.broadcastMessage(salida + DateTime.Now);
                //var objacceso = new HomeController();
                //objacceso.SeteaEstadoVideo(true);
            }




        }

        public ActionResult Bingo()
        {


            var aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += aTimer_Elapsed;
            aTimer.Interval = 20000;
            aTimer.Enabled = true;


            var x = User.Identity.Name;
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
                if (Session != null)
                {
                    var videoActivo = db.bingoParametro.Where(p => p.idLocal == Convert.ToInt32(Session["idlocal"]) && p.idEstadoJuego == 2 && p.videoActivo == true).SingleOrDefault();
                    if (videoActivo != null)
                    {
                        salida = true;
                    }
                }
            }
            return salida;
        }





        public int ObtieneEsperaNumeroSeq()
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


        public void SeteaEstadoVideo(bool estado)
        {
            
            var objacceso = new acceso();
            
            if (objacceso.ValidaSession())
            {
                var idlocal = Convert.ToInt32(Session["idlocal"]);
                using (var db = new bdloginEntities())
                {
                    var videoActivo = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();
                    if (videoActivo != null) videoActivo.videoActivo = estado;
                    db.SaveChanges();
                }
            }

            else
            {
                return;
            }

            
        }
    }
}
