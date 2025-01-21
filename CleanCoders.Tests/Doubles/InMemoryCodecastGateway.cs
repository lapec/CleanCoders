using CleancodersCom;

namespace CleanCoders.Tests;

public class InMemoryCodecastGateway : GatewayUtilities<Codecast>, ICodecastGateway
{
    public List<Codecast> FindAllCodecastsSortedChronologically()
    {
        var sortedCodecasts = GetEntities()
            .OrderBy(codecast => codecast.PublicationDate)
            .ToList();
        return sortedCodecasts;
    }

    public Codecast FindCodecastByTitle(string codecastTitle)
    {
        return GetEntities()
            .FirstOrDefault(codecast => codecast.Title.Equals(codecastTitle, StringComparison.Ordinal));
    }
}