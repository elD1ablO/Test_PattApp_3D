using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    int scoreToAdd;
    int totalScore = 0;

    private void Update()
    {
        UpdateScore();
        scoreToAdd = 0;
    }
    void UpdateScore()
    {       
        totalScore += scoreToAdd;

        scoreText.text = $"Score: {totalScore}";
    }

    public void AddScore(int amount)
    {
        scoreToAdd = amount;        
    }
     

    
}
