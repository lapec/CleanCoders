namespace CleancodersCom;
public interface Gateway
{
    List<Codecast> FindAllCodecasts();
    void Delete(Codecast codecast);
    void Save(Codecast codecast);
    void Save(User user);
    User? FindUser(string username);
}
