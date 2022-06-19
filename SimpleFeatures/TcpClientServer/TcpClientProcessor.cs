using System.Net.Sockets;
using System.Text;

namespace TcpClientServer
{
    public class TcpClientProcessor
    {
        private readonly int BufferLength = 64;
        private readonly string HelloMessage = "Connected" + Environment.NewLine;
        private readonly string StopCommand = "stop";
        private readonly TcpClient _client;
        private readonly Func<string, string> _handler;

        public TcpClientProcessor(TcpClient client, Func<string, string> handler)
        {
            _client = client;
            _handler = handler;
        }

        public TcpClientProcessor Process()
        {
            var stream = _client.GetStream();
            byte[] data = new byte[BufferLength];

            SendHello(stream);

            while (true)
            {
                var acceptor = new StringBuilder();
                int bytes;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    acceptor.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                var clientMessage = acceptor.ToString();

                if (IsStop(clientMessage))
                {
                    break;
                }

                SendAnswer(stream, data, clientMessage);
            }

            return this;
        }

        private void SendHello(NetworkStream stream)
        {
            byte[] data = Encoding.UTF8.GetBytes(HelloMessage);
            stream.Write(data, 0, data.Length);
        }

        private bool IsStop(string command) => command.ToUpper() == StopCommand.ToUpper();

        private void SendAnswer(NetworkStream stream, byte[] data, string incomeMessage)
        {
            data = Encoding.UTF8.GetBytes(_handler(incomeMessage));
            stream.Write(data, 0, data.Length);
        }
    }
}