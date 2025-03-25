using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemInfo itemInfo;

    public string itemName;
    public ItemType type;
    public int value;
    public string descrription;
    public Sprite icon;
    public bool equip;

    public Item(ItemInfo itemInfo)
    {
        this.itemInfo = itemInfo;
        Init();
    }

    void Init()
    {
        itemName = itemInfo.Name;
        type = itemInfo.Type;
        value = itemInfo.Value;
        descrription = itemInfo.Description;
        icon = itemInfo.Icon;
        equip = false;
    }
}
