using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class ClientHandler
    {
        Client c;

        public ClientHandler(Socket s)
        {
            c = new Client(s);
        }



        void Run()
        {    
            while (true)
            {

            }
        }
    }
}
