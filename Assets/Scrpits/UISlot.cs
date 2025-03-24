using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Item item;

    [SerializeField] private Transform icon;
    [SerializeField] private Transform equip;
    [SerializeField] private Image _image;
    [SerializeField] private string _name;

    private void Start()
    {
        _image = icon.GetComponentInChildren<Image>();
    }

    public void SetItem(Item item)
    {
        this.item = new Item(item);
    }

    public void RefreshUI()
    {
        if(item.equip)
            equip.gameObject.SetActive(true);
        else
            equip.gameObject.SetActive(false);
        _name = item.Name;
        _image.sprite = item.Icon;
    }

    public void OnClick()
    {
        UIManager.Instance.UIInventory.curSlot = this;
    }
}
