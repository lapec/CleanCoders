namespace Tests.FitNesse;

public class CodecastPresentationFixture
{
    public bool loginUser(string username) { return false; }
    public bool createLicenseForViewing(string user, string codecast) { return false; }
    public string presentationUser(){ return "TILT :D"; }
    
    public CodecastPresentationFixture()
    {
        Context.gateway = new MockGateway();
    }

    public bool clearCodecasts()
    {
        List<Codecast> codecasts = Context.gateway.findAllCodecasts();
        foreach(var codecast in codecasts) 
        {
            Context.gateway.delete(codecast);
        }
        return true;
    }
    public int countOfCodecastsPresented() { return -1; }
}