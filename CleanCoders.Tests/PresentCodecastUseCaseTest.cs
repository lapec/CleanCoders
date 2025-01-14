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
        User = new User("User");
        Codecast = new Codecast();
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
        License viewLicense = new License(User,Codecast);
        Context.Gateway.Save(viewLicense);
        Assert.True(UseCase.IsLicensedToViewCodecast(User, Codecast));
    }

    [Test]
    public void userWithoutViewLicense_cannotViewOtherUsersCodecast()
    {
        User otherUser = new User("otherUser");
        Context.Gateway.Save(otherUser);
        
        License viewLicense = new License(User, Codecast);
        Context.Gateway.Save(viewLicense);
        Assert.False(UseCase.IsLicensedToViewCodecast(otherUser, Codecast));
    }
}