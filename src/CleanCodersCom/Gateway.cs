namespace CleancodersCom;
public interface Gateway
{
    List<Codecast> FindAllCodecasts();
    void Delete(Codecast codecast);
    Codecast Save(Codecast codecast);
    User Save(User user);
    void Save(License license);
    User? FindUser(string username);
    Codecast? FindCodecastByTitle(string codecastTitle);
    List<License> FindLicensesForUserAndCodecast(User user, Codecast codecast);
}
