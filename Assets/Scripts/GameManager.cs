using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public GameData playerData;

    public TMP_Text Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateText() 
    {
        Score.text = playerData.GetScore();
    
    }

    
}
