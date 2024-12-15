namespace Tests.FitNesse;

public class GivenCodecasts
{
    private string title;
    private string publicationDate;
    private static string dateFormat = DateTime.Now.ToString("yyyy-mm-dd");
    private string permalink;

    public void setTitle(String title) {
        this.title = title;
    }

    public void setPublished(string publicationDate) {
        this.publicationDate = publicationDate;
    }

    public void setPermalink(string permalink) {this.permalink = permalink;}

    public void execute()
    {
        Codecast codecast = new Codecast();
        codecast.setTitle(title);
        codecast.setPublicationDate(publicationDate);
        Context.gateway.save(codecast);
    }
    
}