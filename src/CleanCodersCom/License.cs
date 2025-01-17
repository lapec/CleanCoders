namespace CleancodersCom;

public class License : Entity
{
    public enum LicenseType {Viewing, Downloading}

    public LicenseType Type { get; }
    private User _user;
    private Codecast _codecast;

    public License(LicenseType type, User user, Codecast codecast)
    {
        Type = type;
        _user = user;
        _codecast = codecast;
    }

    public User GetUser()
    {
        return _user;
    }

    public Codecast GetCodecast()
    {
        return _codecast;
    }
}