using System.Net;
using System.Net.Sockets;
//using Microsoft.EntityFrameworkCore;

namespace BeagleBoneCore.Models
{
    // TODO: Derive model ??
    //public class DmxSocketModel : DbContext
    public class DmxSocketModel
    {
        // Database elements
        public IPAddress IpAddress { get; set; }
        public int DmxPort { get; set; }

        // Not in database
        public Socket Client { get; set; }
    }
}
