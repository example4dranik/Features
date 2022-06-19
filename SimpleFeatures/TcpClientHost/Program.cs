using System.Net.Sockets;
using TcpClientServer;

TcpClientSingle? tcpClient = null;
try
{
    tcpClient = new TcpClientSingle("127.0.0.1", 5151).OpenConnection();

    bool exit = false;
    while (!exit)
    {
        var command = Console.ReadLine() ?? string.Empty;
        switch (command)
        {
            case "exit":
                exit = true;
                break;

            default:
                Console.WriteLine(tcpClient.Send(command).GetResponce());
                break;
        }
    }
}
catch (SocketException ex)
{
    Console.WriteLine($"SocketException: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex}");
}
finally
{
    tcpClient?.Close();
}

Console.WriteLine("Stoped");
Console.ReadLine();