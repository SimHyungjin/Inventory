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
    Character character;

    public void Init()
    {
        character = GameManager.instance.character;
        CharacterStatSet();
    }

    public void CharacterStatSet()
    {
        
        attack.text = character.attack.ToString();
        defense.text = character.defense.ToString();
        health.text = character.health.ToString();
        critical.text = character.critical.ToString();
    }

}
