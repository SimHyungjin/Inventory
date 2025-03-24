using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject playerpref;
    public Character character;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SetData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SetData()
    {
        character = Instantiate(playerpref).GetComponent<Character>();
    }

}
