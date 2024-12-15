namespace Tests.FitNesse;

public class MockGateway : Gateway
{
    public List<Codecast> Codecasts { get; set; }
    public MockGateway()
    {
        Codecasts = new List<Codecast>();
    }

    public List<Codecast> findAllCodecasts()
    {
        return Codecasts;
    }

    public void delete(Codecast codecast)
    {
        Codecasts.Remove(codecast);
    }

    public void save(Codecast codecast)
    {
        Codecasts.Add(codecast);
    }
}