namespace CleancodersCom;
public class MockGateway : Gateway
{
    private List<Codecast> Codecasts { get; set; } = [];
    private List<User> Users { get; set; } = [];

    public List<Codecast> FindAllCodecasts()
    {
        return Codecasts;
    }

    public void Delete(Codecast codecast)
    {
        Codecasts.Remove(codecast);
    }

    public void Save(Codecast codecast)
    {
        Codecasts.Add(codecast);
    }
    
    public void Save(User user)
    {
        Users.Add(user);
    }

    public User? FindUser(string username)
    {
        foreach (User user in Users)
        {
            if (user.GetUserName() == username)
                return user;
        }
        return null;
    }
}