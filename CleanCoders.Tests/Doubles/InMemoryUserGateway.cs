using CleancodersCom;

namespace CleanCoders.Tests;
public class InMemoryUserGateway: GatewayUtilities<User>, IUserGateway
{
    public User FindUserByName(string username)
    {
        foreach (var user in GetEntities())
        {
            if (user.GetUserName().Equals(username))
                return user;
        }

        return null;
    }
}