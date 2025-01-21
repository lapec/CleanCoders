namespace CleancodersCom;
public class User : Entity
{
    private readonly string _userName;

    public User(string userName)
    {
        this._userName = userName;
    }

    public string GetUserName()
    {
        return _userName;
    }
}