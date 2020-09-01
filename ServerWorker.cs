using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class ServerWorker
    {
        public void Start()
        {
            // Creating the server
            // Because it is a echo server we make it port 7 
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            // We make the server accept the call from client
            TcpClient socket = server.AcceptTcpClient();

            DoClient(socket);

            socket.Close();
        }

        private static void DoClient(TcpClient socket)
        {
            // Net stream
            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            // Read text from client
            String str = sr.ReadLine();
            Console.WriteLine($"Her er server input: {str}");

            // Respond to the client
            sw.WriteLine(str);
            sw.Flush(); // Emptying the buffer
        }
    }
}
