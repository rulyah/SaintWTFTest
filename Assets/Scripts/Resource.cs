using System;

[Serializable]
public class Resource
{
    public int type;
    public int count;

    public Resource(int type, int count)
    {
        this.type = type;
        this.count = count;
    }
}