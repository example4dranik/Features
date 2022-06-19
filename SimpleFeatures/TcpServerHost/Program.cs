using TcpClientServer;

Console.WriteLine($"Starting {nameof(TcpClientServer)}");

var server = new TcpServer("127.0.0.1", 5151);
server.SetHandler(MakerAnswer).Open();

Console.ReadLine();

static string MakerAnswer(string serverMessage)
{
    return $"::{serverMessage}::";
}