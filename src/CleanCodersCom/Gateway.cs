namespace CleancodersCom;
public interface Gateway
{
    List<Codecast> FindAllCodecasts();
    void Delete(Codecast codecast);
    void Save(Codecast codecast);
    void Save(User user);
    void Save(License license);
    User? FindUser(string username);
    Codecast? FindCodecastByTitle(string codecastTitle);
    List<License> FindLicensesForUserAndCodecast(User user, Codecast codecast);
}
