namespace CleancodersCom;

public class CodecastHTMLSection
{
    public string Print()
    {
        return @"
        <div class=""box"">
            <h3>${title}</h5><h1></h5>${publicationDate}
            <p>Price: ${price}</p>
            <a class=""button"" href=""/cart/add/1"">Add to Cart</a>
        </div>
";
    }
}