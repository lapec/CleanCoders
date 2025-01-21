using CleancodersCom;

namespace CleanCoders.Tests;

public class InMemoryLicenseGateway : GatewayUtilities<License>, ILicenseGateway
{
    public List<License> FindLicensesForUserAndCodecast(User user, Codecast codecast)
    {
        var results = new List<License>();
        foreach (var license in GetEntities())
            if (license.GetUser().IsSame(user) && license.GetCodecast().IsSame(codecast))
                results.Add(license);
        return results;
    }
}