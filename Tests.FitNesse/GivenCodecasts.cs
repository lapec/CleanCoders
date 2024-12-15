namespace Tests.FitNesse;

public class GivenCodecasts
{
    private string title;
    private string publicationDate;

    public void SetTitle(string title) {
        this.title = title;
    }

    public void SetPublished(string publicationDate) {
        this.publicationDate = publicationDate;
    }

    public void Execute()
    {
        Codecast codecast = new Codecast();
        codecast.SetTitle(title);
        codecast.SetPublicationDate(publicationDate);
        Context.gateway.save(codecast);
    }
}