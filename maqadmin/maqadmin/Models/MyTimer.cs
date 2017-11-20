using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maqadmin.Models
{
    public class MyTimer : System.Timers.Timer
    {
        public MyTimer(double interval)
            : base(interval)
        {
        }

        public int idlocal { get; set; }
        public string urlDownload { get; set; }

    }


}