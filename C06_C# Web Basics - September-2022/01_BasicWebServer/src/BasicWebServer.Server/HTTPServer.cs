namespace BasicWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    using BasicWebServer.HTTP;

    public class HTTPServer
    {
        private const int BufferLength = 1024;
        private const int MaxReqquestSize = 10 * 1024;

        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener tcpListener;

        public HTTPServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.tcpListener = new TcpListener(this.ipAddress, this.port);
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
                Console.WriteLine(requestAsString);

                string content = "Hello from my cat web server!";
                await this.WriteResponseAsync(networkStream, content);

                networkConnection.Close();
            }
        }

        public async Task WriteResponseAsync(NetworkStream networkStream, string content)
        {
            int contentLength = Encoding.UTF8.GetByteCount(content);

            string responseAsString = @$"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

            byte[] responseBytes = Encoding.UTF8.GetBytes(responseAsString);
            await networkStream.WriteAsync(responseBytes);
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

            //Request request = Request.Parse(stringBuilder.ToString());

            return stringBuilder.ToString();
        }
    }
}
