using static CleancodersCom.License.LicenseType;

namespace CleancodersCom.Fixtures;

public class CodecastPresentation
{
    private readonly PresentCodecastUseCase _useCase = new PresentCodecastUseCase();
    public static readonly GateKeeper GateKeeper = new GateKeeper();

    public CodecastPresentation()
    {
        Context.Gateway = new MockGateway();
    }
    
    public bool AddUser(string username)
    {
        Context.Gateway.Save(new User(username));
        return true;
    }
    
    public bool LoginUser(string username)
    {
        var user = Context.Gateway.FindUser(username);
        if (user != null)
        {
            GateKeeper.SetLoggedInUser(user);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CreateLicenseForViewing(string username, string codecastTitle)
    {
        var user = Context.Gateway.FindUser(username);
        Codecast codecast = Context.Gateway.FindCodecastByTitle(codecastTitle);
        License license = new License(Viewing, user, codecast);
        Context.Gateway.Save(license);
        return _useCase.IsLicensedToViewCodecast(user, codecast);
    }

    public bool CreateLicenseForDownloading(string username, string codecastTitle)
    {
        var user = Context.Gateway.FindUser(username);
        Codecast codecast = Context.Gateway.FindCodecastByTitle(codecastTitle);
        License license = new License(Downloading, user, codecast);
        Context.Gateway.Save(license);
        return _useCase.IsLicensedToDownloadCodecast(user, codecast);
    }
    public string PresentationUser()
    {
        return GateKeeper.GetLoggedInUser().GetUserName();
    }

    public int CountOfCodecastsPresented()
    {
        List<PresentableCodecast> presentations = _useCase.PresentCodecasts(GateKeeper.GetLoggedInUser());
        return presentations.Count;
    }
    
    public bool ClearCodecasts()
    {
        List<Codecast> codecasts = Context.Gateway.FindAllCodecastsSortedChronologically();
        foreach(var codecast in new List<Codecast> (codecasts))
        {
            Context.Gateway.Delete(codecast);
        }
        return Context.Gateway.FindAllCodecastsSortedChronologically().Count() == 0;
    }
}