using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterId { get; private set; } = "Slayer";
    public string characterName { get; private set; } = "Chad";
    public int characterLv { get; private set; } = 1;
    public int exp { get; private set; } = 0;
    public int maxExp { get; private set; } = 10;
    public string description { get; private set; } = "Boy";

    public int gold { get; private set; } = 0;

    public int attack { get; private set; } = 40;
    public int defense { get; private set; } = 25;
    public int health { get; private set; } = 100;
    public int critical { get; private set; } = 25;

    public List<Item> inventory = new();
    private UIInventory uiInventory;

    private void Start()
    {
        uiInventory = UIManager.Instance.UIInventory;
        uiInventory.Add += AddItem;
        uiInventory.Equip += EquipItem;
        uiInventory.UnEquip += UnEquipItem;
    }

    public void AddItem(Item itemHub)
    {
        inventory.Add(itemHub);
    }

    public void EquipItem()
    {
        switch (uiInventory.curSlot.item.type)
        {
            case ItemType.Attack:
                attack += uiInventory.curSlot.item.value;
                
                break;
            case ItemType.Defense:
                defense += uiInventory.curSlot.item.value;
                break;
        }
    }
    public void UnEquipItem()
    {
        switch (uiInventory.curSlot.item.type)
        {
            case ItemType.Attack:
                attack -= uiInventory.curSlot.item.value;
                break;
            case ItemType.Defense:
                defense -= uiInventory.curSlot.item.value;
                break;
        }

    }
}
