using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace _2048
{
    class Client
    {
        private TcpClient Client1;
        private StreamReader Reader;
        public StreamWriter Writer;
        public string Recive="";
        private String IP;
        private int Port;
        private Thread ResiveData, SendData;
        private long BigestScore = 0;

        public Client(string ip, int port)
        {
            this.IP = ip;
            this.Port = port;
        }

        private void GetData()
        {
            this.Recive = "";
            try
            {
                while (this.Client1.Connected)
                {
                    do
                    {
                        this.Recive = this.Reader.ReadLine();
                    } while (this.Recive == "");
                    this.BigestScore = long.Parse(this.Recive);

                }
            }
            catch
            {

            }
        }

        private void sendData()
        {
        }

        public void ConnectToServer()
        {
            this.Client1 = new TcpClient();
            IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
            try
            {
                this.Client1.Connect(EndPoint);
                this.Reader = new StreamReader(this.Client1.GetStream());
                this.Writer = new StreamWriter(this.Client1.GetStream());
                this.Writer.AutoFlush = true;
                this.ResiveData = new Thread(GetData);
                this.SendData = new Thread(sendData);
                this.ResiveData.Start();
                this.SendData.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public long Get_BigestScore()
        {
            return this.BigestScore;
        }


        public bool Connected()
        {
            return Client1.Connected;
        }

        public void Stop()
        {
            this.ResiveData.Abort();
            this.SendData.Abort();
            this.Client1.Close();
        }
    }
}
