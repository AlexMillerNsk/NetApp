using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Server
    {
        static bool cycle = true;
        public static void AcceptMsg()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            UdpClient udpClient = new UdpClient(8080);
            Console.WriteLine("Server waiting for message, press any key");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                cycle = false;
                //Или Environment.Exit(0);
            }

            while (cycle)
            {

                try
                {
                    byte[] buffer = udpClient.Receive(ref ep);
                    string data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                    Thread tr = new Thread(() =>
                    {
                        Message? msg = Message.FromJson(data);
                        if (msg != null)
                        {
                            Console.WriteLine(msg.ToString());
                            Message responseMsg = new Message("Server", "Message was sent to server");
                            string responseMsgJs = responseMsg.ToJson();
                            byte[] responceData = Encoding.UTF8.GetBytes(responseMsgJs);
                            udpClient.Send(responceData, ep);
                        }
                        else
                        {
                            Console.WriteLine("Wrong message");
                        }
                    });
                    tr.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            Environment.Exit(0);
        }
    }
}
