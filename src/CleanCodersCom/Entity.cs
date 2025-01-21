namespace CleancodersCom;

public class Entity : ICloneable
{
    private string _id;
    public bool IsSame(Entity entity)
    {
        if (_id == null || entity._id == null)
            return false;
        return _id == entity._id;
    }

    public void SetId(string id)
    {
        _id = id;
    }

    public string GetId()
    {
        return _id;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}