using System.Net.Sockets;

namespace CleancodersCom.SocketServer;

public interface SocketService
{
    public void Serve(Socket s);
}