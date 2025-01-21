namespace CleancodersCom;

public interface ILicenseGateway
{
    License Save(License license);
    List<License> FindLicensesForUserAndCodecast(User user, Codecast codecast);
}