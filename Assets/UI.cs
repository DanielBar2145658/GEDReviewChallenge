using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TMP_Text score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score.text = GameManager.Instance.playerData.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
