using CleanCoders.Tests;
using CleancodersCom;
using static CleancodersCom.License.LicenseType;

namespace CleanCoders.Tests.Fixtures;

public class CodecastPresentation
{
    private readonly PresentCodecastUseCase _useCase = new PresentCodecastUseCase();
    public static readonly GateKeeper GateKeeper = new GateKeeper();

    public CodecastPresentation()
    {
        TestSetup.SetupContext();
    }
    
    public bool AddUser(string username)
    {
        Context.UserGateway.Save(new User(username));
        return true;
    }
    
    public bool LoginUser(string username)
    {
        var user = Context.UserGateway.FindUserByName(username);
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
        var user = Context.UserGateway.FindUserByName(username);
        Codecast codecast = Context.CodecastGateway.FindCodecastByTitle(codecastTitle);
        License license = new License(Viewing, user, codecast);
        Context.LicenseGateway.Save(license);
        return _useCase.IsLicensedToViewCodecast(user, codecast);
    }

    public bool CreateLicenseForDownloading(string username, string codecastTitle)
    {
        var user = Context.UserGateway.FindUserByName(username);
        Codecast codecast = Context.CodecastGateway.FindCodecastByTitle(codecastTitle);
        License license = new License(Downloading, user, codecast);
        Context.LicenseGateway.Save(license);
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
        List<Codecast> codecasts = Context.CodecastGateway.FindAllCodecastsSortedChronologically();
        foreach(var codecast in new List<Codecast> (codecasts))
        {
            Context.CodecastGateway.Delete(codecast);
        }
        return Context.CodecastGateway.FindAllCodecastsSortedChronologically().Count() == 0;
    }
}