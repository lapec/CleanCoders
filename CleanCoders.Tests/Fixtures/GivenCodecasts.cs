using System.Globalization;
using CleancodersCom;

namespace CleanCoders.Tests.Fixtures;

public class GivenCodecasts
{
    private string _title;
    private string _publicationDate;

    public void SetTitle(string title) {
        this._title = title;
    }

    public void SetPublished(string publicationDate) {
        this._publicationDate = publicationDate;
    }

    public void Execute()
    {
        Codecast codecast = new Codecast
        {
            Title = _title,
            PublicationDate = DateTime.ParseExact(_publicationDate, "M/d/yyyy", CultureInfo.InvariantCulture) 
        };
        Console.WriteLine(_publicationDate);
        Context.CodecastGateway.Save(codecast);
    }
}