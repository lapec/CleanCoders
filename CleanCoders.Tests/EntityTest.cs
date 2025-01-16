using CleancodersCom;

namespace CleanCoders.Tests;

public class EntityTest
{
    [Test]
    public void TwoDifferentEntitiesAreNotTheSame()
    {
        Entity e1 = new Entity();
        Entity e2 = new Entity();

        e1.SetId("e1Id");
        e2.SetId("e2Id");
        
        Assert.False(e1.IsSame(e2));
    }

    [Test]
    public void OneEntityIsTheSameAsItself()
    {
        Entity e1 = new Entity();
        e1.SetId("e1Id");
        Assert.True(e1.IsSame(e1));
    }

    [Test]
    public void UsersWithSameIdAreTheSame()
    {
        Entity e1 = new Entity();
        Entity e2 = new Entity();
        e1.SetId("e1ID");
        e2.SetId("e1ID");

        Assert.True(e1.IsSame(e2));
    }

    [Test]
    public void EntitiesWithNullIdsAreNeverSame()
    {
        Entity e1 = new Entity();
        Entity e2 = new Entity();
        Assert.False(e1.IsSame(e2));
    }
}