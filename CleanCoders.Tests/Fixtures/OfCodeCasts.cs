using CleancodersCom;

namespace CleanCoders.Tests.Fixtures;

public class OfCodeCasts
{
    private List<object> List(params object[] objects)
    {
        return objects.ToList();
    }

    public List<Object> Query()
    {
        List<PresentableCodecast> presentableCodecasts = new PresentCodecastUseCase().PresentCodecasts(CodecastPresentation.GateKeeper.GetLoggedInUser());
        List<Object> queryResponse = List();
        foreach (var pcc in presentableCodecasts)
        {
            queryResponse.Add(MakeRow(pcc));
        }

        return queryResponse;
    }

    private List<object> MakeRow(PresentableCodecast pcc)
    {
        return List(
            new object[]
            {
                List("title", pcc.Title),
                List("publication date", pcc.PublicationDate),
                List("picture", pcc.Title),
                List("description", pcc.Title),
                List("viewable", pcc.IsViewable ? "+" : "-"),
                List("downloadable", pcc.IsDownloadable ? "+" : "-")
            }
        );
    }
}