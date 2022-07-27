using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpServer;

namespace TCPServerController
{
   
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {

            int port = 9001;
            
            SimpleServer _simpleServer = new SimpleServer("192.168.1.3", port);

            _simpleServer.Start();

            _simpleServer.Stop();


        }


        public void Scan(int port)
        {

        }

        public void StartServer(int port)
        {
           

            SimpleServer _simpleServer = new SimpleServer("192.168.1.132", port);

            _simpleServer.Start();

            _simpleServer.Stop();
        }
        
    }
}
