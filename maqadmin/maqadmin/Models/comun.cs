using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace maqadmin.Models
{
    public class comun
    {
        /// <summary>
        /// Obtiene estado del video cuando esta activado
        /// 2: Muestra video
        /// </summary>
        /// <returns></returns>
        public int ObtieneEsperaNumeroSeq(int idlocal)
        {
            var salida = 0;
            using (var db = new bdloginEntities())
            {

                var objParametro = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();
                if (objParametro != null)
                {
                    salida = objParametro.esperaNumeroSeg;
                }
            }
            return salida;
        }


        public bool ActualizaCliente(int idlocal)
        {
            var salida = false;
            using (var db = new bdloginEntities())
            {

                var objParametro = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();
                if (objParametro != null)
                {
                    if (objParametro.ultimaActualizacion == null)
                    {
                        objParametro.ultimaActualizacion = DateTime.Now;
                        db.SaveChanges();
                    }

                    if (objParametro.ultimaActualizacion != null)
                    {
                        DateTime oldDate = objParametro.ultimaActualizacion.Value;
                        DateTime newDate = DateTime.Now;

                        TimeSpan ts = newDate - oldDate;

                        // Difference in days.
                        double differenceInSeconds = ts.TotalSeconds;

                        if (ObtieneEsperaNumeroSeq(idlocal)<=differenceInSeconds)
                        {
                            salida = true;
                            objParametro.ultimaActualizacion = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                }
            }
            return salida;
        }


        public void SeteaEstadoVideo(bool estado, int idlocal)
        {

            using (var db = new bdloginEntities())
            {
                var videoActivo = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();
                if (videoActivo != null) videoActivo.videoActivo = estado;
                db.SaveChanges();
            }

        }

        public void ApagaCliente(bool estado, int idlocal)
        {

            using (var db = new bdloginEntities())
            {
                var objpar = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();
                if (objpar != null) objpar.apagarCliente = estado;
                db.SaveChanges();
            }

        }


        public string ClientDownload(int idLocal,string urlDownload)
        {
            //var sesion = Session["idlocal"];
            //var x = User.Identity.Name;
            var client = new WebClient();
            string salida;
            //string url;

           
            //using (var db = new bdloginEntities())
            //{
            //    url = db.bingoParametro.Where(p => p.idLocal == idLocal).Single().urlDownload;

            //}

            try
            {
                salida = client.DownloadString(urlDownload);
            }
            catch (Exception)
            {

                return "Problemas con urlDownload";
            }

            return salida;
        }

        internal void SeteaUltimaActualizacion(int idlocal)
        {
            using (var db = new bdloginEntities())
            {
                var bingoParametro = db.bingoParametro.Where(p => p.idLocal == idlocal).SingleOrDefault();
                if (bingoParametro != null) bingoParametro.ultimaActualizacion = DateTime.Now;
                db.SaveChanges();
            }
        }



    }
}