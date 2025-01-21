using CleancodersCom;

namespace CleanCoders.Tests;

using System;
using System.Collections.Generic;

public class GatewayUtilities<T> where T : Entity
{
    private Dictionary<string, T> entities;

    public GatewayUtilities()
    {
        this.entities = new Dictionary<string, T>();
    }

    public List<T> GetEntities()
    {
        var clonedEntities = new List<T>();
        foreach (var entity in entities.Values)
            AddCloneToList(entity, clonedEntities);
        
        return clonedEntities;
    }

    private void AddCloneToList(T entity, List<T> newEntities)
    {
        try
        {
            newEntities.Add((T)entity.Clone());
        }
        catch (Exception)
        {
            throw new UnCloneableEntityException();
        }
    }

    public T Save(T entity)
    {
        if (string.IsNullOrEmpty(entity.GetId()))
            entity.SetId(Guid.NewGuid().ToString());
        
        string id = entity.GetId();
        SaveCloneInMap(id, entity);
        return entity;
    }

    private void SaveCloneInMap(string id, T entity)
    {
        try
        {
            entities[id] = (T)entity.Clone();
        }
        catch (Exception)
        {
            throw new UnCloneableEntityException();
        }
    }

    public void Delete(T entity)
    {
        entities.Remove(entity.GetId());
    }

    public class UnCloneableEntityException : Exception
    {
        public UnCloneableEntityException() : base("Entity cannot be cloned.")
        {
        }
    }
}
