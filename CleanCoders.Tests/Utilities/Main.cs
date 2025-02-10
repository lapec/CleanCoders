using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CleanCoders.Tests;
using CleancodersCom.SocketServer;

namespace CleancodersCom;

public class Main
{
    private SocketServer.SocketServer _server;
    private ICodecastGateway _codecastGateway;

    [Test]
    public async Task MainMethod()
    {
        TestSetup.SetupSampleData();
        _server = new SocketServer.SocketServer(8090, new MainService());
        await _server.Start();
        Console.ReadLine();
    }

    public SocketServer.SocketServer GetServer()
    {
        return _server;
    }

    public ICodecastGateway GetCodecastGateway()
    {
        return _codecastGateway;
    }
}

public class MainService : SocketService
{
    public void Serve(Socket s)
    {
        try
        {
            var frontPage = GetFrontPage();
            string response = MakeResponse(frontPage);
            NetworkStream ns = new NetworkStream(s);
            StreamWriter sw = new StreamWriter(ns, Encoding.UTF8);
            sw.Write(response);
            sw.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string MakeResponse(string content)
    {
        string response = 
            "HTTP/1.1 200 OK\r\n" +
            "Content-Type: text/html; charset=UTF-8\r\n" +
            $"Content-Length: {content.Length}\r\n" +
            "\r\n" + 
            content;

        return response;
    }

    private string GetFrontPage()
    {
        var useCase = new PresentCodecastUseCase();
        var bob = Context.UserGateway.FindUserByName("Bob");
        
        List<PresentableCodecast> pc = useCase.PresentCodecasts(bob);
        
        
        
        var codecastHTML = new CodecastHTMLSection();
        var codecastItems = "";
        foreach (var presentableCodecast in pc)
        {
            var codecastTemplate = new ViewTemplate(codecastHTML.Print());
            codecastTemplate.Replace("title", presentableCodecast.Title);
            codecastTemplate.Replace("publicationDate", presentableCodecast.PublicationDate);
            codecastItems += codecastTemplate.GetContent();
        }
        
        var frontPageHTML = new FrontPage();
        ViewTemplate frontPageTemplate = new ViewTemplate(frontPageHTML.Print());
        frontPageTemplate.Replace("codecast", codecastItems);
        
        return frontPageTemplate.GetContent();
    }

    private string GetCodecastPage()
    {
        var codecastSetion = new CodecastHTMLSection();
        return codecastSetion.Print();
    }
}