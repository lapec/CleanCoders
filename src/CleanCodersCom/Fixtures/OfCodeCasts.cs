namespace CleancodersCom.Fixtures;
using System.Reflection;

public class OfCodeCasts
{
    private List<object> List(params object[] objects)
    {
        Console.WriteLine("Prc");
        return objects.ToList();
    }

    public List<Object> Query()
    {
        List<PresentableCodecast> presentableCodecasts = new PresentCodecastUseCase().PresentCodecasts(CodecastPresentation.GateKeeper.GetLoggedInUser());
        List<Object> queryResponse = List();
        foreach (var pcc in presentableCodecasts)
        {
            queryResponse.Add
                (
                MakeRow(pcc.Title, 
                    pcc.Title, 
                    pcc.Title, 
                    pcc.IsViewable, 
                    false));
        }

        return queryResponse;
    }

    private List<object> MakeRow(string title, string picture, string description, bool viewable, bool downloadable)
    {
        return List(
            new object[]
            {
                List("title", title),
                List("picture", picture),
                List("description", description),
                List("viewable", viewable ? "+" : "-"),
                List("downloadable", downloadable ? "+" : "-")
            }
        );
    }
}