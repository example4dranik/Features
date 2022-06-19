using System.Net;
using System.Net.Sockets;

namespace TcpClientServer
{
    public class TcpServer
    {
        private readonly IPAddress _ip;
        private readonly int _port;
        private TcpListener _listener;
        private string _error;
        private Func<string, string> _handler;

        public TcpServer(string ip, int port)
        {
            _ip = IPAddress.Parse(ip);
            _port = port;
            _error = DefaultError();
        }

        public TcpServer SetHandler(Func<string, string> handler)
        {
            _handler = handler;
            return this;
        }

        public string Error()
        {
            var error = _error;
            _error = DefaultError();
            return error;
        }

        public void Open()
        {
            try
            {
                _listener = new TcpListener(_ip, _port);
                _listener.Start();

                while (true)
                {
                    var tcpClient = _listener.AcceptTcpClient();
                    var tcpClientProcessor = new TcpClientProcessor(tcpClient, _handler);

                    Task.Factory.StartNew(() => tcpClientProcessor.Process());
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            finally
            {
                _listener?.Stop();
            }
        }

        private string DefaultError() => string.Empty;
    }
}