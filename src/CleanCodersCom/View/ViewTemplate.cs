namespace CleancodersCom;

public class ViewTemplate
{
    private string _template;

    public ViewTemplate(string template)
    {
        _template = template;
    }

    public void Replace(string tagName, string content)
    {
        _template = _template.Replace("${"+tagName+"}", content);
    }

    public string GetContent()
    {
        return _template;
    }
}