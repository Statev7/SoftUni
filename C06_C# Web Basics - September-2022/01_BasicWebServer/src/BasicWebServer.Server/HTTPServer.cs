namespace BasicWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Sessions;
    using BasicWebServer.Routing.Implementation;

    public class HTTPServer
    {
        private const string DefualtIP = "127.0.0.1";
        private const int DefualtPort = 8080;
        private const int BufferLength = 1024;
        private const int MaxReqquestSize = 10 * 1024;

        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener tcpListener;
        private readonly RoutingTable routingTable;

        public HTTPServer(string ipAddress, int port, Action<RoutingTable> routingTable)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.tcpListener = new TcpListener(this.ipAddress, this.port);

            routingTable(this.routingTable = new RoutingTable());
        }

        public HTTPServer(int port, Action<RoutingTable> routingTable)
            :this(DefualtIP, port, routingTable)
        {

        }

        public HTTPServer(Action<RoutingTable> routingTable)
            :this(DefualtPort, routingTable)
        {

        }

        public async Task Start()
        {
            this.tcpListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine("Listening for request...");

            while (true)
            {
                TcpClient networkConnection = await tcpListener.AcceptTcpClientAsync();

                NetworkStream networkStream = networkConnection.GetStream();

                string requestAsString = await this.ReadRequestAsync(networkStream);
                Request request = Request.Parse(requestAsString);

                Response response = this.routingTable.MatchRequest(request);

                AddSession(request, response);

                await this.WriteResponseAsync(networkStream, response);

                networkConnection.Close();
            }
        }

        public async Task<string> ReadRequestAsync(NetworkStream networkStream)
        {
            byte[] buffer = new byte[BufferLength];
            StringBuilder stringBuilder = new StringBuilder();

            int totalBytes = 0;

            do
            {
                int bytesRead = await networkStream.ReadAsync(buffer, 0, BufferLength);
                totalBytes += bytesRead;

                if (totalBytes > MaxReqquestSize)
                {
                    throw new InvalidOperationException("Request is too large");
                }

                string bytesAsString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                stringBuilder.Append(bytesAsString);


            } while (networkStream.DataAvailable);

            return stringBuilder.ToString();
        }

        private void AddSession(Request request, Response response)
        {
            bool sessionExists = request.Session
                .Contains(Session.SessionCurrentDateKey);

            if (!sessionExists)
            {
                request.Session[Session.SessionCurrentDateKey]
                    = DateTime.UtcNow.ToString();

                response.Cookies
                    .Add(Session.SessionCookieName, request.Session.Id);
            }
        }

        public async Task WriteResponseAsync(NetworkStream networkStream, Response response)
        {
            string responseAsString = response.ToString();
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseAsString);

            await networkStream.WriteAsync(responseBytes);
        }
    }
}
