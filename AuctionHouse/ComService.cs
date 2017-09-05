using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AuctionHouse
{
    class ComService
    {
        Socket s;
        IPAddress ip;
        TcpListener listener;
        List<ClientHandler> clientHandlers;
        public delegate void BroadcastHandler(string s);
        public event BroadcastHandler TimeToBroadcast;

        public ComService()
        {
            ip = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(ip, 11000);
            clientHandlers = new List<ClientHandler>();
            RunService();

        }

        private void RunService()
        {

            //Thread cm = new Thread(() => CheckMessages());
            //cm.IsBackground = true;
            //cm.Start();

            listener.Start();

            while (true)
            {

                s = listener.AcceptSocket();
                ClientHandler ch = new ClientHandler(s, this);
                //TimeToBroadcast += ch.WriteToClient;
                clientHandlers.Add(ch);
                Thread ct = new Thread(() => ch.Run());
                ct.IsBackground = true;
                ct.Start();


            }


        }

 
        
        public void RemoveClientHandler(ClientHandler ch)
        {
            clientHandlers.Remove(ch);
        }
        public void BroadCast(string s)
        {
            TimeToBroadcast(s);
        }

        public void ParseInput(string s)
        {
            string[] tokens = s.Split(' ');
            switch (tokens[0].ToLower())
            {
                case "bid":
                    break;
                default:
                    BroadCast(s);
                    break;
            }
        }

        //private void CheckMessages()
        //{
        //    while (true)
        //    {
        //        //if (clientHandlers.Count > 0)
        //        {
        //            for (int i = 0; i < clientHandlers.Count; i++)
        //            {

        //                if (clientHandlers[i].Message != null)
        //                {
        //                    BroadCast(clientHandlers[i].Message);
        //                    clientHandlers[i].Message = null;
        //                }
        //            }
        //        }

        //    }


        //}

        //private void StartListening()
        //{
        //    listener.Start();

        //    while (true)
        //    {
        //        s = listener.AcceptSocket();
        //        ClientHandler ch = new ClientHandler(s, this);
        //        new Thread(() => ch.Run());
        //        clientHandlers.Add(ch);
        //    }
        //}
    }
}
