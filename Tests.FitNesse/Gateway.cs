namespace Tests.FitNesse;

public interface Gateway
{
    List<Codecast> findAllCodecasts();
    void delete(Codecast codecast);
}
