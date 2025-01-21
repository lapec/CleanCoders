using System.Globalization;
using static CleancodersCom.License.LicenseType;

namespace CleancodersCom;
public class PresentCodecastUseCase
{
    private static string DateFormat = "M-d-yyyy";
    public List<PresentableCodecast> PresentCodecasts(User loggedInUser)
    {
        var presentableCodecasts = new List<PresentableCodecast>();
        var allCodecasts = Context.CodecastGateway.FindAllCodecastsSortedChronologically();
        
        foreach (var codecast in allCodecasts)
            presentableCodecasts.Add(FormatCodecasts(loggedInUser, codecast));
        
        return presentableCodecasts;
    }

    private PresentableCodecast FormatCodecasts(User loggedInUser, Codecast codecast)
    {
        var pcc = new PresentableCodecast();
        pcc.Title = codecast.Title;
        pcc.PublicationDate = codecast.PublicationDate.ToString(DateFormat);
        pcc.IsViewable = IsLicensedToViewCodecast(loggedInUser, codecast);
        pcc.IsDownloadable = IsLicensedToDownloadCodecast(loggedInUser, codecast);
        return pcc;
    }

    public bool IsLicensedToViewCodecast(User user, Codecast codecast)
    {
        return IsLicensedFor(Viewing, user, codecast);
    }
    
    public bool IsLicensedToDownloadCodecast(User user, Codecast codecast)
    {
        return IsLicensedFor(Downloading, user, codecast);
    }
    
    public bool IsLicensedFor(License.LicenseType licenseType, User user, Codecast codecast)
    {
        List<License> licenses = Context.LicenseGateway.FindLicensesForUserAndCodecast(user, codecast);
        foreach(var license in licenses)
            if (license.Type == licenseType)
                return true;
        return false;
    }
}