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
        private string message;
        ComService cm;
        Client c;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string ClientEndPoint
        {
            get { return c.EndPoint; }
        }

        public ClientHandler(Socket s, ComService cm)
        {
            c = new Client(s);
            this.cm = cm;
            cm.TimeToBroadcast += WriteToClient;

        }



        public void Run()
        {
           
            bool canRead = true;
            while (canRead)
            {
                try
                {
                    if (message == null)
                    {
                        message = c.ReadFrom();
                        cm.ParseInput(message, this);
                        message = null;

                    }

                }
                catch (Exception)
                {
                    canRead = false;
                    Console.WriteLine($"{c.EndPoint} is gone");
                    cm.TimeToBroadcast -= WriteToClient;
                    cm.RemoveClientHandler(this);
                }
               

           }
        }

        public void WriteToClient(string s)
        {
            try
            {
                c.WriteTo(s);
            }
            catch (Exception)
            {

            }

        }
    }
}
