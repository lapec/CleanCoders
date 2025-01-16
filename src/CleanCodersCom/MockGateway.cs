namespace CleancodersCom;
public class MockGateway : Gateway
{
    private List<Codecast> Codecasts { get; set; } = [];
    private List<User> Users { get; set; } = [];
    private List<License> Licenses { get; set; } = [];

    public List<Codecast> FindAllCodecasts()
    {
        return Codecasts;
    }

    public void Delete(Codecast codecast)
    {
        Codecasts.Remove(codecast);
    }

    public Codecast Save(Codecast codecast)
    {
        Codecasts.Add((Codecast)EstablishId(codecast));
        return codecast;
    }
    
    public User Save(User user)
    {
        Users.Add((User)EstablishId(user));
        return user;
    }

    private Entity EstablishId(Entity entity)
    {
        if (entity.GetId() == null)
            entity.SetId(Guid.NewGuid().ToString());
        return entity;
    }

    public void Save(License license)
    {
        Licenses.Add(license);
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

    public Codecast? FindCodecastByTitle(string codecastTitle)
    {
        foreach (var codecast in Codecasts)
        {
            return codecast.Title == codecastTitle ? codecast : null;
        }

        return null;
    }

    public List<License> FindLicensesForUserAndCodecast(User user, Codecast codecast)
    {
        List<License> results = new List<License>();
        foreach (var license in Licenses)
        {
            if (license.GetUser().IsSame(user) && license.GetCodecast().IsSame(codecast))
                results.Add(license);
        }
        
        return results;
    }
}