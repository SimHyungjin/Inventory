using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private UIMainMenu uiMainMenu;
    public UIMainMenu UIMainMenu { get => uiMainMenu; set => UIMainMenu = value; }
    [SerializeField] private UIStatus uiStatus;
    public UIStatus UIStatus { get => uiStatus; set => uiStatus = value; }
    [SerializeField] private UIInventory uiInventory;
    public UIInventory UIInventory { get => uiInventory; set => uiInventory = value; }
    [SerializeField] private ItemDatas itemDatas;
    public ItemDatas ItemDatas { get => itemDatas; set => itemDatas = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        uiStatus.Init();
    }
}
