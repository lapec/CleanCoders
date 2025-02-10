using System.Net;
using System.Net.Sockets;

namespace CleancodersCom.SocketServer;

public class SocketServer
{
    private int _port;
    private SocketService _service;
    private IPEndPoint _endpoint;
    private Socket _serverSocket;
    private Action _connectionHandler;
    private Task _executor;
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public bool Running { get; set; }

    public SocketServer(int port, SocketService service)
    {
        this._port = port;
        this._service = service;
        _serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        _endpoint = new IPEndPoint(IPAddress.Any, _port);
        _serverSocket.Bind(_endpoint);
    }

    public int GetPort()
    {
        return _port;
    }

    public SocketService GetService()
    {
        return _service;
    }

    public async Task Start()
    {
        _serverSocket.Listen(10);
        _connectionHandler = new Action(async () =>
        {
            while (Running && !_cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    Socket serviceSocket = await _serverSocket.AcceptAsync();
                    _service.Serve(serviceSocket);
                }
                catch (SocketException ex)
                {
                    if (Running)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        });
        
        _executor = new Task(() => _connectionHandler());
        _executor.Start();
        Running = true;
    }
    
    public bool IsRunning()
    {
        return Running;
    }
    
    public async Task Stop()
    {
        if (!Running)
            return;
       
        Running = false;
        _cancellationTokenSource.Cancel();

        try
        {
            _serverSocket.Shutdown(SocketShutdown.Both);
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"Socket exception: {ex.Message}");
        }

        _serverSocket.Close();
        _serverSocket.Dispose();

        if (_executor != null)
            await _executor;
    }
    
}