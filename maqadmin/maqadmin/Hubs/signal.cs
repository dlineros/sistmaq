using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;




namespace maqadmin.Hubs
{

    public class signal : Hub
    {

        //public void Send(string name, string message)
        //{
        //    // Call the broadcastMessage method to update clients.
        //    Clients.All.broadcastMessage(name, message);
        //}
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();

        public void Send(string vistahtml)
        {
            //string name = Context.User.Identity.Name;
            //foreach (var connectionId in _connections.GetConnections("hhfhf"))
            //{
            //    Clients.Client(connectionId).addChatMessage(name + ": " + name);
            //}

            vistahtml = DateTime.Now.ToLongTimeString();
            Clients.All.broadcastMessage(vistahtml);


        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            _connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

      




    }
}