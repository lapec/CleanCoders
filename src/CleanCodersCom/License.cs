namespace CleancodersCom;

public class License : Entity
{
    private User _user;
    private Codecast _codecast;

    public License(User user, Codecast codecast)
    {
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