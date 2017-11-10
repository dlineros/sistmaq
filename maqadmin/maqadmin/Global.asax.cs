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
                //new { controller = "Home", action = "AccesoUrlGet", id = UrlParameter.Optional } // Parameter defaults
                 new { controller = "bingoParametro", action = "Index", id = UrlParameter.Optional } // Parameter defaults

                

                //http://localhost:2859/Home/AccesoUrlGet?usuario=dlineros&pass=xxx&idlocal=1
            );

        }

        protected void Application_Start()
        {
            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var objbingo = new HomeController();
            var aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += aTimer_Elapsed;
            aTimer.Interval = objbingo.obtieneEsperaNumeroSeq();
            aTimer.Enabled = true;           
            objbingo.SeteaEstadoVideo(false);
            

                       
        }

        void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var objbingo = new HomeController();
            var salida = objbingo.client();
            var videoActivo = objbingo.ObtieneEstadoVideo();
            var context = GlobalHost.ConnectionManager.GetHubContext<signal>();
            if (videoActivo == false) 
            {
                context.Clients.All.broadcastMessage(salida + DateTime.Now);
                
            }
            objbingo.SeteaEstadoVideo(true);
            

        }





    }
}