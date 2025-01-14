namespace CleancodersCom;
public class PresentCodecastUseCase
{
    public List<PresentableCodecast> PresentCodecasts(User loggedInUser)
    {
        return new List<PresentableCodecast>();
    }

    public bool IsLicensedToViewCodecast(User user, Codecast codecast)
    {
        List<License> licenses = Context.Gateway.FindLicensesForUserAndCodecast(user, codecast);
        return licenses.Count() != 0;
    }
}