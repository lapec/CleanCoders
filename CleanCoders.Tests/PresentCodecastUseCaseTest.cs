using System.Globalization;
using CleancodersCom;

namespace CleanCoders.Tests;

public class PresentCodecastUseCaseTest
{
    private User User { get; set; }
    private Codecast Codecast { get; set; }
    private PresentCodecastUseCase UseCase { get; set; }

    [SetUp]
    public void Setup()
    {
        Context.Gateway = new MockGateway();
        User = Context.Gateway.Save(new User("User"));
        Codecast = Context.Gateway.Save(new Codecast());
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
        License viewLicense = new License(User, Codecast);
        Context.Gateway.Save(viewLicense);
        Assert.True(UseCase.IsLicensedToViewCodecast(User, Codecast));
    }

    [Test]
    public void userWithoutViewLicense_cannotViewOtherUsersCodecast()
    {
        User otherUser = Context.Gateway.Save(new User("otherUser"));

        License viewLicense = new License(User, Codecast);
        Context.Gateway.Save(viewLicense);
        Assert.False(UseCase.IsLicensedToViewCodecast(otherUser, Codecast));
    }

    [Test]
    public void PresentNoCodecast()
    {
        Context.Gateway.Delete(Codecast);
        List<PresentableCodecast> PresentableCodecasts = UseCase.PresentCodecasts(User);

        Assert.AreEqual(0, PresentableCodecasts.Count());
    }
    
    [Test]
    public void PresentOneCodecast()
    {
        Codecast.Title = "SomeTitle";
        Codecast.PublicationDate = "Tomorrow";
        
        List<PresentableCodecast> presentableCodecasts = UseCase.PresentCodecasts(User);
        Assert.AreEqual(1, presentableCodecasts.Count());
        var presentableCodecast = presentableCodecasts[0];
        Assert.AreEqual("SomeTitle", presentableCodecast.Title);
        Assert.AreEqual("Tomorrow", presentableCodecast.PublicationDate);
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
        Context.Gateway.Save(new License(User, Codecast));
        List<PresentableCodecast> presentableCodecasts = UseCase.PresentCodecasts(User);
        PresentableCodecast presentableCodecast = presentableCodecasts[0];
        Assert.True(presentableCodecast.IsViewable);
    }
}