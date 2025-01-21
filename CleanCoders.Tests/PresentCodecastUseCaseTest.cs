using System.Globalization;
using CleancodersCom;
using static CleancodersCom.License.LicenseType;

namespace CleanCoders.Tests;

public class PresentCodecastUseCaseTest
{
    private User User { get; set; }
    private Codecast Codecast { get; set; }
    private PresentCodecastUseCase UseCase { get; set; }

    [SetUp]
    public void Setup()
    {
        TestSetup.SetupContext();
        User = Context.UserGateway.Save(new User("User"));
        Codecast = Context.CodecastGateway.Save(new Codecast());
        UseCase = new PresentCodecastUseCase();
    }

    [Test]
    public void userWithoutViewLicense_cannotViewCodecast()
    {
        Assert.False(UseCase.IsLicensedToViewCodecast(User, Codecast));
    }

    [Test]
    public void userWithViewLicense_canViewCodecast()
    {
        License viewLicense;
        viewLicense = new License(Viewing, User, Codecast);
        Context.LicenseGateway.Save(viewLicense);
        Assert.True(UseCase.IsLicensedFor(Viewing, User, Codecast));
    }

    [Test]
    public void userWithoutViewLicense_cannotViewOtherUsersCodecast()
    {
        User otherUser = Context.UserGateway.Save(new User("otherUser"));

        License viewLicense = new License(Viewing, User, Codecast);
        Context.LicenseGateway.Save(viewLicense);
        Assert.False(UseCase.IsLicensedToViewCodecast(otherUser, Codecast));
    }

    [Test]
    public void PresentNoCodecast()
    {
        Context.CodecastGateway.Delete(Codecast);
        List<PresentableCodecast> PresentableCodecasts = UseCase.PresentCodecasts(User);

        Assert.AreEqual(0, PresentableCodecasts.Count());
    }
    
    [Test]
    public void OneIsPresented()
    {
        Codecast.Title = "SomeTitle";
        var now = new DateTime(2014,5,19);
        Codecast.PublicationDate = now;
        Context.CodecastGateway.Save(Codecast);
        
        List<PresentableCodecast> presentableCodecasts = UseCase.PresentCodecasts(User);
        
        Assert.AreEqual(1, presentableCodecasts.Count);
        var presentableCodecast = presentableCodecasts[0];
        Assert.That(presentableCodecast.Title, Is.EqualTo("SomeTitle"));
        Assert.That(presentableCodecast.PublicationDate, Is.EqualTo("5-19-2014"));
    }

    [Test]
    public void PresentedCodeCastsNotViewableIfNoLicense()
    {
        List<PresentableCodecast> presentableCodecasts = UseCase.PresentCodecasts(User);
        PresentableCodecast presentableCodecast = presentableCodecasts[0];
        Assert.False(presentableCodecast.IsViewable);
    }
    
    [Test]
    public void PresentedCodeCastsIsViewableIfLicenseExists()
    {
        Context.LicenseGateway.Save(new License(Viewing, User, Codecast));
        List<PresentableCodecast> presentableCodecasts = UseCase.PresentCodecasts(User);
        PresentableCodecast presentableCodecast = presentableCodecasts[0];
        Assert.True(presentableCodecast.IsViewable);
    }

    [Test]
    public void PresentedCodecastIsDownloadableIfDownloadLicenseExists()
    {
        License downloadLicense = new License(Downloading, User, Codecast);
        Context.LicenseGateway.Save(downloadLicense);
        List<PresentableCodecast> presentableCodecasts = UseCase.PresentCodecasts(User);
        PresentableCodecast presentableCodecast = presentableCodecasts[0];
        Assert.True(presentableCodecast.IsDownloadable);
        Assert.False(presentableCodecast.IsViewable);
    }
}