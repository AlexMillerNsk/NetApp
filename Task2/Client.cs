using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Task2
{
    internal class Client
    {
        internal static bool client = true;

        public static void SendMsg(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            UdpClient udpClient = new UdpClient();

            while (client)
            {
                string? text = Console.ReadLine().ToLower();
                if (text == "exit")
                {
                    Process.GetCurrentProcess().Kill();
                }
                Message msg = new Message(name, text);
                string responseMsgJs = msg.ToJson();
                byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                udpClient.Send(responseData, ep);
                byte[] answerData = udpClient.Receive(ref ep);
                string answerMsgJs = Encoding.UTF8.GetString(answerData);
                Message answerMsg = Message.FromJson(answerMsgJs);
                Console.WriteLine(answerMsg.Text.ToString());

            }

        }



    }
}
