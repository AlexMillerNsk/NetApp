using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Server.AcceptMsg();
            }   
            else
            {
                for (int i = 0; i < 2; i++) 
                {
                    new Thread(() =>
                    {
                        Client.SendMsg($"{args[0]}{i}");
                    }).Start();                   
                }
                
            }
            

        }
    }
}