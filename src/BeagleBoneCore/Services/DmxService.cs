using BeagleBoneCore.Models;
//using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

//using System.Reflection;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

namespace BeagleBoneCore.Services
{

    public class DmxService
    {
        internal static Queue<string> DmxValuesQueue = new Queue<string>();
        public static DmxSocketModel Skt { get; set; }
        internal static StreamWriter Log = new StreamWriter(@"c:\Temp\DmxLog.txt");

        private const string TestIpAddress = "192.168.1.73";
        private static readonly IPAddress DefaultiIpAddress = IPAddress.Parse(TestIpAddress);
        private const int TestPort = 9930;

        public DmxService()
        {
            Log.AutoFlush = true;

            Skt = new DmxSocketModel
            {
                Client = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Dgram,
                                    ProtocolType.IP),
                IpAddress = DefaultiIpAddress,
                DmxPort = TestPort
            };

            // TODO: Used by database
            //string ipAddress = null;
            //var port = 0;

            // Create socket from database
            // TODO: Get data from database
            //GetSocketData(1, ref ipAddress, ref port);
            //Skt.IpAddress = IPAddress.Parse(ipAddress);
            //Skt.DmxPort = port;

            Skt.Client.Connect(Skt.IpAddress, Skt.DmxPort);
        }

        #region Helpers

        public string GetDefaultIpAddress()
        {
            return TestIpAddress;
        }

        public int GetDefaultPort()
        {
            return TestPort;
        }

        public bool SocketConnected()
        {
            return Skt.Client.Connected;
        }

        public void AddToQueue(string data)
        {
            DmxValuesQueue.Enqueue(data);
        }

//        public string GetFromQueue()
//        {
//            return DmxValuesQueue.Dequeue();
//        }

        public int GetQueueCount()
        {
            return DmxValuesQueue.Count;
        }

        public void PostDmxData()
        {
            Skt.Client.Send(Encoding.ASCII.GetBytes(DmxValuesQueue.Dequeue()));
        } 

        public void LogWriteLine(string data)
        {
            Log.WriteLine(data);
        }

        #endregion


        //#region Helpers
        //// Get socket information from the datbase
        //private static void GetSocketData(int index, ref string ipAddress, ref int port)
        //{
        //    var dbContext = new ApplicationDbContext();

        //    var dmxData = dbContext.DmxDatas.Find(index); // Was 1

        //    if (dmxData == null)
        //    {
        //        //return HttpNotFound();
        //    }

        //    if (dmxData != null)
        //    {
        //        ipAddress = dmxData.DmxSocket.IpAddress;
        //        port = dmxData.DmxSocket.Port;
        //    }
        //}

        //#endregion
    }
}
