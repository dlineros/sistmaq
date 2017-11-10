using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Linq;
using maqadmin.Models;
using System.Web;


namespace maqadmin.Models
{
    public class acceso
    {
        public bool validaAcceso(string token)
        {
            var acceso=false;          
            using (var db = new bdloginEntities())
            {
                var resultado = (from p in db.tbltoken
                                 where p.token == token                               
                                 select p).SingleOrDefault();

                if (resultado != null)
                {
                    acceso = true;
                    SeteaInicio(resultado);
                }
            }
            return acceso;

        }

        public void SeteaInicio(tbltoken objtbltoken) 
        {

            using (var db = new bdloginEntities()) {

                HttpContext.Current.Session["idlocal"] = objtbltoken.idLocal;
                var parametro = db.bingoParametro.Where(p => p.idLocal == objtbltoken.idLocal).Single();
                parametro.videoActivo = false;                
                db.SaveChanges();
            
            }
        
        
        
        }


    }
}
