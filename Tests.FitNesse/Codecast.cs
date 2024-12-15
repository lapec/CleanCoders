namespace Tests.FitNesse;

public class Codecast
{
    public string Title { get; set; }
    public string PublicationDate { get; set; }
    public void setTitle(string title)
    {
        this.Title = title;
    }

    public void setPublicationDate(string publicationDate)
    {
        this.PublicationDate = publicationDate;
    }

}