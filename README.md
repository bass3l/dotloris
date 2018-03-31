# Dotloris
Lightweight Slowloris attack implemented in .Net core

### About Slowloris
Slowloris tries to keep many connections to the target web server open and hold them open as long as possible. It accomplishes this by opening connections to the target web server and sending a partial request. Periodically, it will send subsequent HTTP headers, adding to—but never completing—the request. Affected servers will keep these connections open, filling their maximum concurrent connection pool, eventually denying additional connection attempts from clients.

### Getting Started
To run the project execute

`dotnet run --project src/dotloris.csproj --host HOST --port PORT --connections CONNECTIONS`

where `Host` is the ip of the web server, `PORT` is the port on which the server is listening and `CONNECTIONS` is the number of socket connections to launch against the web server.

Built using `.Net Core 2.1.300-preview1-008174` and tested against an ` Apache/2.4.18` with the default configuration except `Timeout 30`.

Web server was running on a dedicated server with  `Intel(R) Xeon(R) CPU E5-2676 v3 @ 2.40GHz` with 1 Core, it needed **~300** connections.

Dotloris was running on a Windows 10 machine.

### Notes on legality
DDoS / DoS attacks are generally unlawful against others' systems. You are solely responsible for consequences arising in connection with your use of this software.

I (the author) do not endorse unlawful and/or non-white-hat use of this software. This tool is designed for research and personal server testing purposes.
 
