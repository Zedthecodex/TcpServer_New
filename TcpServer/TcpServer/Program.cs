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

            if (args.Length == 0)
            {
                int port = 9000;

                SimpleServer _simpleServer = new SimpleServer("192.168.1.132", port);

                _simpleServer.Start();

                _simpleServer.Stop();
            }

            else
            {


                int port = Int32.Parse(args[0].ToString());

                Console.Title = args[0].ToString();

                SimpleServer _simpleServer = new SimpleServer("192.168.1.132", port);

                _simpleServer.Start();

                _simpleServer.Stop();
            }
           
            
           
        }
    }
}
