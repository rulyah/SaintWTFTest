using System.Collections.Generic;
using UnityEngine;
using Views;

public class Storage
{
    private GameObject _parent;
    private List<ResourceView> _resources;

    public Storage(GameObject parent)
    {
        _resources = new List<ResourceView>();
        _parent = parent;
    }
    
    public void TakeResource(ResourceView resource)
    {
        _resources.Add(resource);
        resource.transform.SetParent(_parent.transform);
        resource.MoveToParent(GetItemPosY(_parent));
    }
        
    public ResourceView GiveResource(int type)
    {
        var resource = _resources.FindLast(n => n.type == type);
        _resources.Remove(resource);
        return resource;
    }

    public float GetItemPosY(GameObject parent)
    {
        return parent.transform.position.y + 0.12f * (_resources.Count - 1);
    }
}