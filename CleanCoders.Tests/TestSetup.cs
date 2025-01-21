using CleancodersCom;

namespace CleanCoders.Tests;

public class TestSetup
{
    public static void SetupContext()
    {
        Context.UserGateway = new InMemoryUserGateway();
        Context.LicenseGateway = new InMemoryLicenseGateway();
        Context.CodecastGateway = new InMemoryCodecastGateway();
        Context.GateKeeper = new GateKeeper();
    }
}