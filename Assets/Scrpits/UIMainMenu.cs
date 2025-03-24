using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    UIManager uiManager;
    GameManager gameManager;

    [SerializeField] private Button mainBtn;
    [SerializeField] private Button statusBtn;
    [SerializeField] private Button inventoryBtn;

    [SerializeField] private TextMeshProUGUI characterId;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterLv;
    [SerializeField] private TextMeshProUGUI exp;
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI description;

    [SerializeField] private TextMeshProUGUI gold;

    private void Start()
    {
        uiManager = UIManager.Instance;
        gameManager = GameManager.instance;
        mainBtn.onClick.AddListener(OpenMainMenu);
        statusBtn.onClick.AddListener(OpenStatus);
        inventoryBtn.onClick.AddListener(OpenInventory);
        CharacterSet();
        ExpBar();
    }

    void OpenMainMenu()
    {
        uiManager.UIStatus.gameObject.SetActive(false);
        uiManager.UIInventory.gameObject.SetActive(false);
        mainBtn.gameObject.SetActive(false);
        statusBtn.gameObject.SetActive(true);
        inventoryBtn.gameObject.SetActive(true);
    }
    void OpenStatus()
    {
        uiManager.UIStatus.gameObject.SetActive(true);
        uiManager.UIStatus.CharacterStatSet();
        ActiveBtn(mainBtn);
    }
    void OpenInventory()
    {
        uiManager.UIInventory.gameObject.SetActive(true);
        ActiveBtn(mainBtn);
    }
    void ActiveBtn(Button button)
    {
        mainBtn.gameObject.SetActive(false);
        statusBtn.gameObject.SetActive(false);
        inventoryBtn.gameObject.SetActive(false);

        button.gameObject.SetActive(true);
    }
    public void CharacterSet()
    {
        characterId.text = gameManager.character.characterId;
        characterName.text = gameManager.character.characterName;
        characterLv.text = gameManager.character.characterLv.ToString();
        exp.text = $"{gameManager.character.exp} / {gameManager.character.maxExp}";
        description.text = gameManager.character.description;

        gold.text = gameManager.character.gold.ToString();
    }
    void ExpBar()
    {
        bar.fillAmount = (float)gameManager.character.exp / gameManager.character.maxExp;
    }
}
