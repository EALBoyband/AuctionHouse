using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace AuctionHouse
{
    class Client
    {
        private Socket s;
        NetworkStream stream;

        public Client(Socket s)
        {
            this.s = s;
            
        }
    }
}
