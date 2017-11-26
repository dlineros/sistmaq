using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using maqadmin.Hubs;
using maqadmin.Models;
using maqadmin.Controllers;


namespace maqadmin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                //new { controller = "Home", action = "AccesoUrlGet", id = UrlParameter.Optional } // Parameter defaults
                //new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults

                //new { controller = "Home", action = "AccesoUrlGet", token = "xxxxxx" } // Parameter defaults
                 new { controller = "bingoParametro", action = "Index", id = UrlParameter.Optional } // Parameter defaults



                //http://localhost:51690/Home/AccesoUrlGet?token=xxxxxx
            );

        }

        protected void Application_Start()
        {

            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            //var context = GlobalHost.ConnectionManager.GetHubContext<signal>();

            var obj = new bingoParametroController();
            using (var db = new bdloginEntities())

                foreach (var bingop in db.bingoParametro)
                {
                    obj.ActivarTimer(bingop.idLocal);
                }
            




        }

        //void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    var objbingo = new HomeController();
            
        //    var videoActivo = objbingo.ObtieneEstadoVideo();
        //    var context = GlobalHost.ConnectionManager.GetHubContext<signal>();
        //    if (videoActivo == false) 
     
        //    {
                
        //        var salida = objbingo.ClientDownload();
        //        context.Clients.All.broadcastMessage(salida + DateTime.Now);
        //        //var objacceso = new HomeController();
        //        //objacceso.SeteaEstadoVideo(true);
        //    }

           


        //}





    }
}