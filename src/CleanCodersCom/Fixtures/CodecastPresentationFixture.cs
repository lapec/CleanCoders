namespace CleancodersCom.Fixtures;

public class CodecastPresentation
{
    private readonly PresentCodecastUseCase _useCase = new PresentCodecastUseCase();
    private readonly GateKeeper _gateKeeper = new GateKeeper();

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
            _gateKeeper.SetLoggedInUser(user);
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool CreateLicenseForViewing(string user, string codecast) { return false; }
    
    public string PresentationUser()
    {
        return _gateKeeper.GetLoggedInUser().GetUserName();
    }

    public int CountOfCodecastsPresented()
    {
        List<PresentableCodecast> presentations = _useCase.PresentCodecasts(_gateKeeper.GetLoggedInUser());
        return presentations.Count;
    }
    
    public bool ClearCodecasts()
    {
        List<Codecast> codecasts = Context.Gateway.FindAllCodecasts();
        foreach(var codecast in new List<Codecast> (codecasts))
        {
            Context.Gateway.Delete(codecast);
        }
        return Context.Gateway.FindAllCodecasts().Count() == 0;
    }
}