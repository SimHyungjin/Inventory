using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI critical;

    void Start()
    {
        CharacterStatSet();
    }

    public void CharacterStatSet()
    {
        Character character = GameManager.instance.character;
        attack.text = character.attack.ToString();
        defense.text = character.defense.ToString();
        health.text = character.health.ToString();
        critical.text = character.critical.ToString();
    }

}
