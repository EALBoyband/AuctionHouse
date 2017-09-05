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
        StreamWriter sw;

        public string EndPoint
        {
            get { return s.RemoteEndPoint.ToString(); }
        }

        public bool CanRead
        {
            get { return stream.CanRead; }
            
        }

       public bool CanWrite
        {
            get { return stream.CanWrite; }
        }



        

        public Client(Socket s)
        {
            this.s = s;
            stream = new NetworkStream(s);
            sr = new StreamReader(stream);
            sw = new StreamWriter(stream);
            
        }

        public void WriteTo(string s)
        {
           
                sw.WriteLine(s);
                sw.Flush();

            
            
                   
        }

        public string ReadFrom()
        {
           
                return sr.ReadLine();
            
                       
        }

        
    }
}
