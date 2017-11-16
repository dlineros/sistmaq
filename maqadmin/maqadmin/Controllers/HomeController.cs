﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                    return RedirectToAction("Index", "bingoParametro");
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
            objcomun.SeteaUltimaActualizacion(idlocal);

           
            //var aTimer = new MyTimer(1000);
            //if (aTimer.Enabled == false)
            //{
            //    aTimer.Elapsed += ActualizaClienteSignal;
            //    aTimer.Interval = objcomun.ObtieneEsperaNumeroSeq(idlocal) * 1000;
            //    aTimer.Enabled = true;
            //    aTimer.idlocal = idlocal;
            //}

            ViewData["hora"] = DateTime.Now.ToLongTimeString();
            return View("Bingo");
        }





        public void ActualizaClienteSignal(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Si la base de datos dice actualiza
            //TODO: SI LA BASE DE DATOS MARCA COMO QUE HAY QUE DETENER LA TAREA APLICAR UN STOP

            var objcomun = new comun();
            using (var db = new bdloginEntities())
            {
                MyTimer timer = (MyTimer)sender;
                int idlocal = timer.idlocal;
                //int idlocal = Convert.ToInt32(User.Identity.Name);

                var parametro = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();


                if (parametro != null)
                {
                    if (objcomun.ActualizaCliente(idlocal))
                    {

                        if ((!parametro.videoActivo)
                            && (parametro.idEstadoJuego == 2))
                        {
                            var salida = objcomun.ClientDownload(1);
                            var context = GlobalHost.ConnectionManager.GetHubContext<signal>();
                            context.Clients.All.broadcastMessage(salida + DateTime.Now);
                        }

                        if ((parametro.idEstadoJuego == 1) || (parametro.idEstadoJuego == 3) ||
                            (parametro.idEstadoJuego == 4))
                        {
                            var salida = objcomun.ClientDownload(1);
                            var context = GlobalHost.ConnectionManager.GetHubContext<signal>();
                            context.Clients.All.broadcastMessage(salida + DateTime.Now);
                        }
                    }
                }
            }
        }



        public ActionResult BingoCiclico(string varidlocal)
        {
            //int milliseconds = 20000;
            //Thread.Sleep(milliseconds);

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

            var objBingoFullViewModels = new BingoFullViewModels();
            using (var db = new bdloginEntities())
            {

                var objBingo = new bingo();

                var bingoJuego = db.bingoJuego.Where(p => p.idlocal == idlocal).Single();
                var tbltoken = db.tbltoken.Where(p => p.idLocal == idlocal).Single();
                var bingoParametro = db.bingoParametro.Where(p => p.idLocal == idlocal).Single();

                if (bingoParametro.idEstadoJuego == 3)  //En juego
                {
                    objBingo.letraNumeroAleatorio(idlocal);
                    bingoParametro = db.bingoParametro.Where(p => p.idLocal == idlocal).Single();
                }

                //OBTIENE DATOS A MOSTRAR, 1 OBJETO POR MODELO
                ViewData["estadoJuego"] = db.estadoJuego.Where(p => p.idestado == bingoParametro.idEstadoJuego).Single().nombre;

                objBingoFullViewModels.tbltoken = tbltoken;
                objBingoFullViewModels.bingoJuego = bingoJuego;
                objBingoFullViewModels.bingoParametro = bingoParametro;

            }
            return PartialView("_Bingo", objBingoFullViewModels);
        }








    }
}
