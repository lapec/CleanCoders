namespace Tests.FitNesse;

public class MockGateway : Gateway
{
    public List<Codecast> Codecasts { get; set; }
    public MockGateway(List<Codecast> codecasts)
    {
        Codecasts = codecasts;
    }

    public List<Codecast> findAllCodecasts()
    {
        return Codecasts;
    }

    public void delete(Codecast codecast)
    {
       
    }

    public void save(Codecast codecast)
    {
        Codecasts.Add(codecast);
    }
}