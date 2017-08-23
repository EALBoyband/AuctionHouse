using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class Program
    {
        Socket s;
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.RunServer();
        }

        void RunServer()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(ip, 11000);
            server.Start();

            while (true)
            {
                s = server.AcceptSocket();
                ClientHandler ch = new ClientHandler(s);
                //Thread
            }
        }
    }
}
