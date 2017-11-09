using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Linq;
using maqadmin.Models;


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
                }
            }
            return acceso;

        }

    }
}
