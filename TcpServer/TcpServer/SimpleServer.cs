using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Shared_Class;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Management;

namespace TcpServer
{
    class SimpleServer
    {
        int pport;
        TcpListener _tcpListener;
        static List<Client> clients = new List<Client>();

        public SimpleServer(string ipAddress, int port)
        {
            pport = port;
            IPAddress ip = IPAddress.Parse(ipAddress);
            _tcpListener = new TcpListener(ip, port);
        }

        public static bool ScanNetwork(int port)
        {
            IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = iPGlobalProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray )
            {
                if(tcpi.RemoteEndPoint.Port == port)
                {
                    return false;
                }
            }
            return true;
        }

        public void Start()
        {
           
            _tcpListener.Start();
            Console.WriteLine("Ther server is listening on port : " + Convert.ToString(pport));

            while(true)
            {
                Socket socket = _tcpListener.AcceptSocket();
                Client client = new Client(socket);
                clients.Add(client);
                client.Start();
            }
        }

        public void Stop()
        {
            foreach(Client c in clients)
            {
                c.Stop();
            }

            _tcpListener.Stop();

        }

        public static void SocketMethod(Client fromClient)
        { 
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Socket socket = fromClient.Socket;
                NetworkStream stream = fromClient.Stream;
                BinaryReader reader = fromClient.Reader;

                fromClient.SendText(fromClient, "Successfully Connected");

                int noOfIncomingBytes;
                while ((noOfIncomingBytes = reader.ReadInt32()) != 0)
                {
                    byte[] bytes = reader.ReadBytes(noOfIncomingBytes);

                    MemoryStream memoryStream = new MemoryStream(bytes);

                    Packet packet = formatter.Deserialize(memoryStream) as Packet;
                    int tempServer = 0;


                    switch (packet.type)
                    {
                        case PacketType.NICKNAME:
                            string nickName = ((NickNamePacket)packet).nickName;

                            fromClient.SetNickName(nickName);

                            break;

                        case PacketType.CHATMESSAGE:
                            string message = ((ChatMessagePacket)packet).message;
                            bool isAvailable = ScanNetwork(9500);


                            if (message == "room_test1")
                            {
                                if (isAvailable == false)
                                {
                                    Console.WriteLine("Accessing Chat 9750");
                                    if (tempServer != 0)
                                    {
                                        Process tempProc = Process.GetProcessById(tempServer);
                                        Console.WriteLine(tempServer);
                                        tempProc.Kill();
                                        tempProc.WaitForExit();
                                        tempProc.Dispose();
                                        
                                    }
                                    Process process = new Process();

                                    process.StartInfo.FileName = "TcpServer.exe";
                                    process.StartInfo.Arguments = "9750";
                                    process.Start();
                                }
                            }

                            if (message == "room_test") 
                            {
                                if (isAvailable == true)
                                {
                                    Console.WriteLine("Accessing New Chat_Room");

                                    Process process = new Process();


                                    process.StartInfo.FileName = "TcpServer.exe";
                                    process.StartInfo.Arguments = "9500";
                                    process.Start();

                                    tempServer =  System.Convert.ToInt32(process.Id.ToString());

                                    //Task.Delay(5000);

                                   // IDprocess = System.Convert.ToInt32(process.Id.ToString());
                                   //// Console.WriteLine(IDprocess);
                                   // Process tempProc = Process.GetProcessById(IDprocess);
                                   // tempProc.Kill();
                                   // tempProc.Close();
                                   // tempProc.WaitForExit();

                                }else
                                {
                                    break;
                                }
                            }
                            else
                            { Console.WriteLine("[" + fromClient.NickName + "]" + message); }

                            


                            foreach (Client c in clients)
                            {
                                c.SendText(fromClient, message);
                            }
                           

                            break;
                    }
                    
                }
            }catch (Exception e)
            {
                Console.WriteLine("Error Occured: " + e.Message);
            }
            finally
            {
                fromClient.Stop();
            }
        }
    }
}
