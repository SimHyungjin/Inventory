using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Attack,
    Defense,
}
[System.Serializable]
public class Item
{
    [SerializeField] private string name;
    public string Name { get { return name; } }
    [SerializeField] private ItemType type;
    public ItemType Type {  get { return type; } }
    [SerializeField] private int value;
    public int Value { get { return value; } }
    [SerializeField] private string description;
    public string Description { get { return description; } }
    [SerializeField] private Sprite icon;
    public Sprite Icon { get { return icon; } }
    public bool equip = false;

    public Item(Item other)
    {
        this.name = other.name;
        this.type = other.type;
        this.value = other.value;
        this.description = other.description;
        this.icon = other.icon;
        this.equip = other.equip;
    }

}
