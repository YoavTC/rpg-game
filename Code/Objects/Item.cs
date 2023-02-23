using UnityEngine;

public class Item
{
    public string newName;
    public Sprite icon;

    //--------------------//
    public Item(string name, Sprite icon)
    {
        newName = name;
        this.icon = icon;
    }
}
