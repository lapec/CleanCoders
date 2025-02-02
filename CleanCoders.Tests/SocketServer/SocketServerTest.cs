using System.Net;
using System.Net.Sockets;
using System.Text;
using CleancodersCom.SocketServer;

namespace CleanCoders.Tests;

[TestFixture]
public class SocketServerTests
{
    private SocketServer server;
    private int port;
    
    [SetUp]
    public void Setup()
    {
        port = new Random().Next(5000, 6000);
    }
    
    public abstract class TestSocketService : SocketService
    {
        public void Serve(Socket ss)
        {
            try
            {
                DoService(ss);
                ss.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected abstract void DoService(Socket ss);
    }
    
    private class ClosingSocketService : SocketServerTests.TestSocketService
    {
        public int Connections;
        protected override void DoService(Socket ss)
        {
            Connections++;
        }
    }
    
    public class WithClosingSocketService : SocketServerTests
    {
        private ClosingSocketService _readingService;
        
        [SetUp]
        public void TestSetup()
        {
            _readingService = new ClosingSocketService();
            server = new SocketServer(port, _readingService);
        }
        
        [Test]
        public void Instantiate()
        {
            server = new SocketServer(port, _readingService);
            Assert.That(server.GetPort(), Is.EqualTo(port));
            Assert.That(server.GetService(), Is.EqualTo(_readingService));
        }

        [Test]
        public async Task CanStartAndStopServer()
        {
            server = new SocketServer(8090, _readingService);

            await server.Start();
            Assert.True(server.IsRunning());
            await server.Stop();
            Assert.False(server.IsRunning());
        }

        [Test]
        public async Task AcceptsAnIncommingConnection()
        {
            await server.Start();
            using (Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp))
            {
                await client.ConnectAsync(IPAddress.Loopback, port);
            }
            
            Assert.That(_readingService.Connections, Is.EqualTo(1));
            await server.Stop();
        }

        [Test]
        public async Task AcceptsMultipleIncommingConnections()
        { 
            await server.Start();

            using (Socket client1 = new Socket(SocketType.Stream, ProtocolType.Tcp))
            using (Socket client2 = new Socket(SocketType.Stream, ProtocolType.Tcp))
            {
                await client1.ConnectAsync(IPAddress.Loopback, port);
                await client2.ConnectAsync(IPAddress.Loopback, port);
            }

            await Task.Delay(500);

            Assert.That(_readingService.Connections, Is.EqualTo(2));
    
            await server.Stop();
        }


        [Test]
        public async Task CanStopServerConnection()
        {
            await server.Start();
            await server.Stop();
            Assert.That(_readingService.Connections, Is.EqualTo(0));
        }
    }
    
    private class EchoSocketService : SocketServerTests.TestSocketService 
    {
        private Socket _ss;
        protected override void DoService(Socket ss)
        {
            // ...
        }
    }

    // public class WithEchoSocketService : SocketServerTests
    // {
    //     private EchoSocketService _echoService;
    //
    //     [SetUp]
    //     public void TestSetup()
    //     {
    //         _echoService = new EchoSocketService();
    //         server = new SocketServer(port, _echoService);
    //     }
    //
    //     [Test]
    //     public void CanEcho()
    //     {
    //         server.Start();
    //     }
    // }
    
    private class ReadingSocketService : SocketServerTests.TestSocketService 
    {
        public int Connections;
        private Socket _ss;
        public string? Message { get; set; }

        protected override void DoService(Socket ss)
        {
            Connections++;
            using NetworkStream ns = new NetworkStream(ss);
            using StreamReader reader = new StreamReader(ns, Encoding.UTF8);
            Message = reader.ReadLine();
        }
    }

    public class WithReadingSocketService : SocketServerTests
    {
        private ReadingSocketService _readingService;

        [SetUp]
        public void TestSetup()
        {
            _readingService = new ReadingSocketService();
            server = new SocketServer(port, _readingService);
        }

        [Test]
        public async Task CanSendAndReceiveData()
        {
            await server.Start();

            using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                await client.ConnectAsync(IPAddress.Loopback, port);

                using NetworkStream ns = new NetworkStream(client);
                using StreamWriter writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };

                await writer.WriteLineAsync("Hello from client!");
            }
            
            Assert.That(_readingService.Message, Is.EqualTo("Hello from client!"));
        }
    }
}