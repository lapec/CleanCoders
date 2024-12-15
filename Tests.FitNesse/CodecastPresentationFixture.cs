using System.Diagnostics;

namespace Tests.FitNesse;

public class CodecastPresentation
{
    public CodecastPresentation()
    {
        Context.gateway = new MockGateway();
    }

    public bool ClearCodecasts()
    {
        List<Codecast> codecasts = Context.gateway.findAllCodecasts();
        foreach(var codecast in codecasts)
        {
            Context.gateway.delete(codecast);
        }
        return Context.gateway.findAllCodecasts().Count() == 0;
    }
    public bool LoginUser(string username) { return false; }
    public bool CreateLicenseForViewing(string user, string codecast) { return false; }
    public string PresentationUser(){ return "TILT :D"; }
    public int CountOfCodecastsPresented() { return -1; }
}