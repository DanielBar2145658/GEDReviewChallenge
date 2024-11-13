using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    public GameData playerData;

    UI Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);

        Score = FindFirstObjectByType<UI>();
    }

/*    public void UpdateText() 
    {
        
    
    }*/

    
}
