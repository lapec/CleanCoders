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

    public static void SetupSampleData()
    {
        SetupContext();
        
        User bob = new User("Bob");
        User micah = new User("Micah");

        Context.UserGateway.Save(bob);
        Context.UserGateway.Save(micah);
        
        var e1 = new Codecast
        {
            Title = "Clean Code",
            PublicationDate = DateTime.Now.AddDays(-3)
        };

        var e2 = new Codecast
        {
            Title = "Names++",
            PublicationDate = DateTime.Now.AddDays(-1)
        };

        var e3 = new Codecast
        {
            Title = "Functions",
            PublicationDate = DateTime.Now
        };
        
        Context.CodecastGateway.Save(e1);
        Context.CodecastGateway.Save(e2);
        Context.CodecastGateway.Save(e3);

        License bobE1 = new License(License.LicenseType.Viewing, bob, e1);
        License bobE2 = new License(License.LicenseType.Viewing, bob, e2);
        License bobE3 = new License(License.LicenseType.Viewing, bob, e2);
    }
}