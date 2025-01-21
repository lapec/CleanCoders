namespace CleancodersCom;

public interface IUserGateway
{
    User Save(User user);
    User FindUserByName(string username);
}