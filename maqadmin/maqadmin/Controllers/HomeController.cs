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
        //[System.Web.Mvc.Authorize]
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


       

        [System.Web.Mvc.Authorize]
        public ActionResult Bingo()
        {
            int idlocal = Convert.ToInt32(User.Identity.Name);
            
            var objcomun = new comun();
            objcomun.SeteaEstadoVideo(false, idlocal);

            var aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += aTimer_Elapsed;
            aTimer.Interval = objcomun.ObtieneEsperaNumeroSeq(idlocal);
            aTimer.Enabled = true;

            ViewData["hora"] = DateTime.Now.ToLongTimeString();
            return View("Bingo");
        }



        public ActionResult BingoCiclico(string varidlocal)
        {

            ViewData["hora"] = DateTime.Now.ToLongTimeString();
            int idlocal = Convert.ToInt32(varidlocal);
            ViewData["idlocal"] = idlocal;

            using (var db = new bdloginEntities())
            {

                //video activo(Ya se esta ejecutando, no debe refrezcar) y estado2: Muestra el video
                var videoActivo = db.bingoParametro.Where(p => p.idLocal == idlocal && p.idEstadoJuego == 2).SingleOrDefault();
                if (videoActivo != null)
                {
                    if (!videoActivo.videoActivo)
                    {
                        ViewData["urlVideo"] = videoActivo.urlVideo;
                        ViewData["MensajeVideo"] = videoActivo.MensajeVideo;
                        var objcomun = new comun();
                        objcomun.SeteaEstadoVideo(true, idlocal);
                        return PartialView("_Video");
                    }

                }

            }

            //Obtiene siguiente numero
            var objBingo = new bingo();
            var numeroActual = objBingo.letraNumeroAleatorio(idlocal);

            var objBingoFullViewModels = new BingoFullViewModels();
            using (var db = new bdloginEntities())
            {

                var bingoJuego = db.bingoJuego.First();
                var tbltoken = db.tbltoken.First();
                var bingoParametro = db.bingoParametro.First();

                //OBTIENE DATOS A MOSTRAR, 1 OBJETO POR MODELO
                ViewData["estadoJuego"] = db.estadoJuego.Where(p => p.idestado == bingoParametro.idEstadoJuego).Single().nombre;

                objBingoFullViewModels.tbltoken = tbltoken;
                objBingoFullViewModels.bingoJuego = bingoJuego;
                objBingoFullViewModels.bingoParametro = bingoParametro;

            }
            return PartialView("_Bingo", objBingoFullViewModels);
        }


        void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var objcomun = new comun();
            using (var db = new bdloginEntities())
            {
                int idlocal = Convert.ToInt32(User.Identity.Name);
                var parametro = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();
                if (parametro != null)
                {
                    if ((!parametro.videoActivo) && (parametro.idEstadoJuego == 2))
                    {
                        var salida = objcomun.ClientDownload(1);
                        var context = GlobalHost.ConnectionManager.GetHubContext<signal>();
                        context.Clients.All.broadcastMessage(salida + DateTime.Now);
                    }

                    if ((parametro.idEstadoJuego == 1) || (parametro.idEstadoJuego == 3))
                    {
                        var salida = objcomun.ClientDownload(1);
                        var context = GlobalHost.ConnectionManager.GetHubContext<signal>();
                        context.Clients.All.broadcastMessage(salida + DateTime.Now);
                    }
                }
            }
        }



        
      
    }
}
