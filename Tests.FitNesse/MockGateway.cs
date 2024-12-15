namespace Tests.FitNesse;

public class MockGateway : Gateway
{
    public List<Codecast> findAllCodecasts()
    {
        return [];
    }

    public void delete(Codecast codecast)
    {
       
    }
}