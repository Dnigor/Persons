using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading; 

namespace AppServer
{
    class Communicator
    {
        Socket serverSocket;        
        IPAddress addr;
        IPEndPoint localEP;

        public Communicator() 
        {
            addr = IPAddress.Parse("127.0.0.1");
            localEP = new IPEndPoint(addr, 8000);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(localEP);
            serverSocket.Listen(10);

            while (true)
            {

                Socket clientSocket = serverSocket.Accept();
                Thread receivingThread = new Thread(new ParameterizedThreadStart(ReceiveMessage));
                Console.WriteLine("recv thread {0} created", receivingThread.GetHashCode());
                receivingThread.Start((object)clientSocket);

            }
        
        }

        public void ReceiveMessage(object obj)
        {

            while (true)
            {

                byte[] bytes = new byte[1024];
                int count = ((Socket)obj).Receive(bytes);
                string inmessage = new ASCIIEncoding().GetString(bytes, 0, count);
                //Console.WriteLine(message);
                ParseMessage((Socket)obj, inmessage);

            }

        }

        public void ParseMessage(Socket soc, string msg)
        {
            string[] cmd = msg.Split(';');
            string outmessage = "";

            switch (cmd[0])
            {
                case "[connect]":
                    break;
                case "[getrecords]":
                    DAO db = new DAO();
                    JSONconverter conv = new JSONconverter();
                    outmessage = "[records];" + conv.toJSONstring(db.GetRecords());
                    SendMessage(soc, outmessage);
                    break;
            }
        }


        public void SendMessage(Socket soc, string message) 
        {
            soc.Send(new ASCIIEncoding().GetBytes(message));     
        }
    }
}
