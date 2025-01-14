using CleancodersCom;

namespace CleanCoders.Tests;

public class UserTest
{
    [Test]
    public void TwoDifferentUsersAreNotTheSame()
    {
        User u1 = new User("u1");
        User u2 = new User("u2");

        u1.SetId("u1Id");
        u2.SetId("u2Id");
        
        Assert.False(u1.IsSame(u2));
    }

    [Test]
    public void OneUserIsTheSameAsItself()
    {
        User u1 = new User("u1");
        u1.SetId("u1Id");
        Assert.True(u1.IsSame(u1));
    }

    [Test]
    public void usersWithSameIdAreTheSame()
    {
        User u1 = new User("u1");
        User u2 = new User("u2");
        u1.SetId("u1ID");
        u2.SetId("u1ID");

        Assert.True(u1.IsSame(u2));
    }
    
    
}