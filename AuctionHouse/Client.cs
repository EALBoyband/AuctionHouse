using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace AuctionHouse
{
    class Client
    {
        private Socket s;
        NetworkStream stream;
        StreamReader sr;
        StreamReader sw;
        

        public Client(Socket s)
        {
            this.s = s;
            stream = new NetworkStream(s);
            sr = new StreamReader(stream);
            sw = new StreamReader(stream);
            
        }
    }
}
