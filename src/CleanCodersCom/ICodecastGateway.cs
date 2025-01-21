namespace CleancodersCom;

public interface ICodecastGateway
{
    List<Codecast> FindAllCodecastsSortedChronologically();

    void Delete(Codecast codecast);

    Codecast Save(Codecast codecast);

    Codecast FindCodecastByTitle(String codecastTitle);
}