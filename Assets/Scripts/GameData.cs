using UnityEngine;

[System.Serializable]
public class GameData
{
    int Score { get; set; }

    public void AddScore(int amount) 
    {
        Score += amount;
    
    }

    public string GetScore() 
    {
        return Score.ToString();
    }


}
