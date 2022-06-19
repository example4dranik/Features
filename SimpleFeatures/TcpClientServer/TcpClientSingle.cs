using System.Net.Sockets;
using System.Text;

namespace TcpClientServer
{
    public class TcpClientSingle
    {
        private readonly string _server;
        private readonly int _port;
        private TcpClient _client;
        private NetworkStream _stream;

        public TcpClientSingle(string server, int port)
        {
            _server = server;
            _port = port;
        }

        public TcpClientSingle OpenConnection()
        {
            _client = new TcpClient();
            _client.Connect(_server, _port);
            _stream = _client.GetStream();

            return this;
        }

        public TcpClientSingle Send(string message)
        {
            byte[] dataOut = Encoding.UTF8.GetBytes(message);
            _stream.Write(dataOut, 0, dataOut.Length);

            return this;
        }

        public string GetResponce()
        {
            var accepter = new StringBuilder();
            do
            {
                byte[] dataIn = new byte[256];
                int bytes = _stream.Read(dataIn, 0, dataIn.Length);
                accepter.Append(Encoding.UTF8.GetString(dataIn, 0, bytes));
            }
            while (_stream.DataAvailable);

            return accepter.ToString();
        }

        public TcpClientSingle Close()
        {
            _stream?.Dispose();
            _client?.Close();

            return this;
        }
    }
}
