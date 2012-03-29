using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading; 

namespace Desktop
{
    class Communicator
    {
        //private string name;
        private Socket serverSocket = null;
        private IPAddress addr;
        private IPEndPoint ep;

        public delegate void getRecordsDelegate(string str);
        public event getRecordsDelegate onGetRecords;


        public void Connect()
        {
            addr = IPAddress.Parse("127.0.0.1");
            ep = new IPEndPoint(addr, 8000);
            
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(ep);

            SendMessageToServer("[connect]");
            Thread t = new Thread(new ThreadStart(recv));
            t.Start();

        }

        public void GetRecords() 
        {
            SendMessageToServer("[getrecords]");
        }


        private void SendMessageToServer(string msg)
        {

            byte[] bytesToSend = new byte[50];
            bytesToSend = new ASCIIEncoding().GetBytes(msg + ";");
            serverSocket.Send(bytesToSend, bytesToSend.Length, 0);

        }

        private void recv()
        {
            try
            {
                while (true)
                {

                    byte[] bytesRecv = new byte[1024];
                    int count = serverSocket.Receive(bytesRecv, bytesRecv.Length, 0);
                    string message = new ASCIIEncoding().GetString(bytesRecv);

                    MessageParse(message);


                }
            }
            catch
            {

            }


        }

        private void MessageParse(string msg)
        {
            string[] cmd = msg.Split(';');
            switch (cmd[0])
            {
                case "[records]":
                    onGetRecords(cmd[1]);
                    break;
            }
        }
    }
}
