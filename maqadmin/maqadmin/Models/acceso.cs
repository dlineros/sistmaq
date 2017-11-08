using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Linq;
using maqadmin.Models;
using maqadmin.Datos;

namespace maqadmin.Models
{
    public class acceso
    {
        public bool validaAcceso(string usuario, string pass, int idlocal)
        {
            var acceso=false;
            //Session["acceso"] = "false";
            using (var db = new bdloginEntities())
            {
                var resultado = (from p in db.tblusuario
                                 where p.usuario == usuario
                                 && p.pass == pass
                                 && p.idlocal == idlocal
                                 select p).SingleOrDefault();

                if (resultado != null)
                {
                    acceso = true;
                    //Session["acceso"] = true;
                }
            }
            return acceso;

        }

    }
}
