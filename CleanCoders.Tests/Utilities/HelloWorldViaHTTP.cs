using System.Net.Sockets;
using System.Text;
using CleancodersCom.SocketServer;

namespace CleanCoders.Tests.Utilities;

[TestFixture]
public class HelloWorldViaHTTP : SocketService
{
    [Test]
    public static async Task Start()
    {
        SocketServer server = new SocketServer(8090, new HelloWorldViaHTTP());
        await server.Start();
        Console.ReadLine();
    }

    public void Serve(Socket s)
    {
        try
        {
            using NetworkStream ns = new NetworkStream(s);
            string body = "<h1>Hello World</h1><h2>It works!</h2>";
            string response = 
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/html; charset=UTF-8\r\n" +
                $"Content-Length: {body.Length}\r\n" +
                "\r\n" + 
                body;
            
            using StreamWriter writer = new StreamWriter(ns, Encoding.UTF8);
            writer.Write(response+"\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}