namespace CleancodersCom;
public class GateKeeper
{
    private User loggedInUser;
    public void SetLoggedInUser(User user)
    {
        this.loggedInUser = user;
    }

    public User GetLoggedInUser()
    {
        return loggedInUser;
    }
}