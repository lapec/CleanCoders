namespace Tests.FitNesse;

public class Codecast
{
    public string Title { get; set; }
    public string PublicationDate { get; set; }
    public string Permalink { get; set; }
    public void SetTitle(string title)
    {
        this.Title = title;
    }

    public void SetPublicationDate(string publicationDate)
    {
        this.PublicationDate = publicationDate;
    }
    
    public void SetPermalink(string permalink) {
        this.Permalink = permalink;
    }

}