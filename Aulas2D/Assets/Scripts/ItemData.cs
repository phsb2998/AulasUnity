using UnityEngine;

public enum ItemType
{
    None,
    Holder,
    Material,
    Blade,
    Molde
}


[System.Serializable]
public class ItemData
{
    public Sprite sprite;
    public string name;
    public ItemType itemType;
}
