namespace CleancodersCom;
public class PresentCodecastUseCase
{
    public List<PresentableCodecast> PresentCodecasts(User loggedInUser)
    {
        var presentableCodecasts = new List<PresentableCodecast>();
        var allCodecasts = Context.Gateway.FindAllCodecasts();
        
        foreach (var codecast in allCodecasts)
        {
            var cc = new PresentableCodecast();
            cc.Title = codecast.Title;
            cc.PublicationDate = codecast.PublicationDate;
            cc.IsViewable = IsLicensedToViewCodecast(loggedInUser, codecast);
            presentableCodecasts.Add(cc);
        }
        return presentableCodecasts;
    }

    public bool IsLicensedToViewCodecast(User user, Codecast codecast)
    {
        List<License> licenses = Context.Gateway.FindLicensesForUserAndCodecast(user, codecast);
        return licenses.Count() != 0;
    }
}