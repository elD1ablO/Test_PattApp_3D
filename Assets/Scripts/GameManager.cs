using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] BallSpawner ballSpawner;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelNumberText;

    [SerializeField] GameObject abLoader;

    BundleLoadAsync bundleLoader;

    int scoreToAdd;
    int totalScore = 0;

    int scoreToNextLevel = 0;
    int scoreIncrease = 100;
    int currentLevel = 1;

    bool isLevelTextShown = false;



    private void Update()
    {
        UpdateScore();
        scoreToAdd = 0;
    }
    void UpdateScore()
    {       
        totalScore += scoreToAdd;

        scoreText.text = $"Score: {totalScore}";

        if (!isLevelTextShown && totalScore >= scoreToNextLevel)
        {
            isLevelTextShown = true;
            StartCoroutine(ShowLevelChangeMessage($"Level {currentLevel}", 3));

        }
    }

    public void AddScore(int amount)
    {
        scoreToAdd = amount;        
    }
     
    IEnumerator ShowLevelChangeMessage(string levelText, float delay)
    {
        ballSpawner.IncreaseModifier();
        //LoadNewBundle();
        levelNumberText.enabled = true;
        levelNumberText.text = levelText;
        scoreToNextLevel += scoreIncrease;        
        yield return new WaitForSeconds(delay);
        levelNumberText.enabled = false;
        currentLevel++;

        isLevelTextShown = false;
    }
    
    public int GetCurrentLvl()
    {
        return currentLevel;
    }

    /*void LoadNewBundle()
    {
        abLoader.SetActive(false);
        abLoader.SetActive(true);
        bundleLoader = abLoader.GetComponent<BundleLoadAsync>();
        bundleLoader.LoadNewBG(currentLevel - 1);
    }*/
}
