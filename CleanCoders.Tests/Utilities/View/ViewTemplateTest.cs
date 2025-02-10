using CleancodersCom;

namespace CleanCoders.Tests.Utilities.View;

[TestFixture]
public class ViewTemplateTest
{
    [Test]
    public void NoReplacement()
    {
        ViewTemplate template = new ViewTemplate("some static content");
        Assert.That(template.GetContent(), Is.EqualTo("some static content"));
    }

    [Test]
    public void SimpleReplacement()
    {
        ViewTemplate template = new ViewTemplate("replace ${this}");
        template.Replace("this", "replacement");
        Assert.That(template.GetContent(), Is.EqualTo("replace replacement"));
    }
}