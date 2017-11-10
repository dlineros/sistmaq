using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;




namespace maqadmin.Hubs
{
 
    public class signal: Hub    {

            //public void Send(string name, string message)
            //{
            //    // Call the broadcastMessage method to update clients.
            //    Clients.All.broadcastMessage(name, message);
            //}


            public void Send(string vistahtml)
            {
                vistahtml = DateTime.Now.ToLongTimeString();
                // Call the broadcastMessage method to update clients.
                Clients.All.broadcastMessage(vistahtml);
            }
    }
}