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


    private void Start()
    {
        _image = icon.GetComponentInChildren<Image>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public void RefreshUI()
    {
        if(item.equip)
            equip.gameObject.SetActive(true);
        else
            equip.gameObject.SetActive(false);
        _image.sprite = item.icon;
    }

    public void OnClick()
    {
        UIManager.Instance.UIInventory.curSlot = this;
    }
}
