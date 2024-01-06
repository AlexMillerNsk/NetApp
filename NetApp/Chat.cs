using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetApp
{
    internal class Chat
    {

        public static void Server()
        {
            IPEndPoint localIP = new IPEndPoint (IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient (12345);

            while (true)
            {
                try
                {
                    byte[] bytes = udpClient.Receive (ref localIP);

                    string msg = Encoding.UTF8.GetString (bytes);

                    Message message = Message.FromJson (msg);

                    if (message != null)
                    {
                        Console.WriteLine (msg);
                    }
                    else
                    {
                        Console.WriteLine("Wrong message");
                    }

                    Console.WriteLine("Server waiting your message");
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
                
            }
            
        }

        public static void Client(string nik)
        {
            IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            UdpClient client = new UdpClient();




            while (true)
            {
                Console.WriteLine("Enter your message, please");
                string text = Console.ReadLine ();
                if (String.IsNullOrEmpty(text))
                {
                    break;
                }
                Message msg = new Message (nik, text);

                string json = msg.ToJson ();

                byte[] bytes = Encoding.UTF8.GetBytes (json);

                client.Send (bytes, localIP);
            }
        }



    }
}
