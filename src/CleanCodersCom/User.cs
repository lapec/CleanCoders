namespace CleancodersCom;
public class User
{
    private readonly string _userName;
    private string _id;
    public User(string userName)
    {
        this._userName = userName;
    }

    public string GetUserName()
    {
        return _userName;
    }

    public bool IsSame(User user)
    {
        return _id.Equals(user._id);
    }

    public void SetId(string id)
    {
        _id = id;
    }

    public string GetId()
    {
        return _id;
    }
}