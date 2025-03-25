using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private Character character;
    [SerializeField] private TextMeshProUGUI inventoryNum;
    [SerializeField] private Transform slotTransform;
    [SerializeField] private RectTransform slotPanel;
    [SerializeField] private int maxSlotNum;
    [SerializeField] private UISlot uislot;
    public UISlot curSlot;
    public List<UISlot> slots = new List<UISlot>();

    private Vector3 basicPos;
    private bool isScroll = false;
    private Vector2 scrollPos;

    public Action<Item> Add;
    public Action Equip;
    public Action UnEquip;

    private void Awake()
    {
        basicPos = slotPanel.anchoredPosition;
    }

    void Start()
    {
        InventoryNumSet();
        InitInventoryUI();
    }

    private void Update()
    {
        Scroll();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].RefreshUI();
            }
        }
        InventoryNumSet();
    }
    void InventoryNumSet()
    {
        int num = 0;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item != null)
                num++;
        }
         
        inventoryNum.text = $"Inventory <color=orange>{num}</color> / {maxSlotNum}";
    }
    void InitInventoryUI()
    {
        for (int i = 0; i < maxSlotNum; i++)
        {
            slots.Add(Instantiate(uislot, slotTransform));
        }
    }
    void Scroll()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isScroll = true;
            scrollPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isScroll = false;
        }
        if (isScroll)
        {
            Vector2 delta = (Vector2)Input.mousePosition - scrollPos;
            Vector3 newPos = slotPanel.anchoredPosition += new Vector2(0, delta.y);
            int value = maxSlotNum / 3 * 80 - 240;
            newPos.y = Mathf.Clamp(newPos.y, basicPos.y, value);
            slotPanel.anchoredPosition = newPos;
            scrollPos = Input.mousePosition;
        }
    }

    public void GetItem()
    {
        int num = UnityEngine.Random.Range(0, UIManager.Instance.ItemDatas.itemInfos.Count);
        Item item = new Item(UIManager.Instance.ItemDatas.itemInfos[num]);
        AddItem(item);
    }

    void AddItem(Item item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].SetItem(item);
                break; 
            }
        }
        UpdateUI();
        Add?.Invoke(item);
    }

    public void EquipItem()
    {
        if (curSlot.item != null && !curSlot.item.equip)
        {
            curSlot.item.equip = true;
            Equip?.Invoke();
        }
        UpdateUI();
    }

    public void UnEquipItem()
    {
        if (curSlot.item != null && curSlot.item.equip)
        {
            curSlot.item.equip = false;
            UnEquip?.Invoke();
        }
        UpdateUI();
    }
}
