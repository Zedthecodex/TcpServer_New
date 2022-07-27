using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Class;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TcpServer_Client
{
    public class Connection
    {
        private Form1 _form;
        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private BinaryWriter _writer;
        private BinaryReader _reader;
        private Thread _thread;

        public bool Connect(Form1 form, string hostname, int port, string nickname)
        {
            try
            {
                _form = form;
                _tcpClient = new TcpClient();
                _tcpClient.Connect(hostname, port);
                _stream = _tcpClient.GetStream();
                _writer = new BinaryWriter(_stream, Encoding.UTF8);
                _reader = new BinaryReader(_stream,Encoding.UTF8);

                setNickName(nickname);
                _thread = new Thread(new ThreadStart(ProcessServerResponse));
                _thread.Start();
            }
            catch (TimeoutException Timeout)
            {

            }
            catch (Exception e)
            {
                OutputText("Exception: " + e.Message);
                return false;
            }
            

            return true;
        }

        public void Disconnect()
        {
            try
            {
                _reader.Close();
                _writer.Close();
                _tcpClient.Close();
                _thread.Abort();
            }
            catch { }
            OutputText("Disconnected");
        }

        public void SendText(string text)
        {
            if (!_tcpClient.Connected)
            {
                return;
            }
            ChatMessagePacket chatMessagePacket = new ChatMessagePacket(text);
            Send(chatMessagePacket);
        }
       

        private void ProcessServerResponse()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                int noOfIncomingBytes;
                while ((noOfIncomingBytes = _reader.ReadInt32()) != 0)
                {
                    byte[] bytes = _reader.ReadBytes(noOfIncomingBytes);

                    MemoryStream memoryStream = new MemoryStream(bytes);

                    Packet packet = formatter.Deserialize(memoryStream) as Packet;

                    switch (packet.type)
                    {
                        case PacketType.CHATMESSAGE:
                            string message = ((ChatMessagePacket)packet).message;
                            OutputText(message);
                            break;
                    }
                }
            }
            catch { }
        }

        private void setNickName(string nickname)
        {
            NickNamePacket chatMessagePacket = new NickNamePacket(nickname);
            Send(chatMessagePacket);
        }

        private void Send(Packet data)
        {
            MemoryStream mem = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(mem, data);
            byte[] buffer = mem.GetBuffer();

            _writer.Write(buffer.Length);
            _writer.Write(buffer);
            _writer.Flush();
        }

        private delegate void AppendTextDelegate(string str);
        private void OutputText(string text)
        {
            _form.Invoke(new AppendTextDelegate(_form.AppendText), new object[] { text });
        }
    }
}
