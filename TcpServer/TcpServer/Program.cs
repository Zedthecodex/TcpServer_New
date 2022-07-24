using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 9000;

            SimpleServer _simpleServer = new SimpleServer("192.168.1.132", port);

            _simpleServer.Start();

            _simpleServer.Stop();
            
           
        }
    }
}
