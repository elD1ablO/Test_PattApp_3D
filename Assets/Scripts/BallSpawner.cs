using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;    
        
    float spawnPositionX = 8.5f;
    float spawnPositionY = 9f;

    float minSpawnDelay = 0.5f;
    float maxSpawnDelay = 2f;
    float currentDelay = 1f;

    float minBallSize = 0.5f;
    float maxBallSize = 2f;
    public float currentScale;

    float gravityModifier = 1f;

    float lvlIncreaseModifier = 0;
    float lvlIncreaseStep = 0.1f;

    Rigidbody rb;

    GameObject newBall;

    void FixedUpdate()
    {        
        currentDelay -= Time.deltaTime;

        if (currentDelay <= 0)
        {
            newBall = Instantiate(ballPrefab, new Vector3(Random.Range(-spawnPositionX, spawnPositionX), spawnPositionY, 0), Quaternion.identity);

            Material ballColor = newBall.GetComponent<Renderer>().material;
            ballColor.SetColor("_Color", GetRandomColor()); 

            Transform newBallScale = newBall.GetComponent<Transform>();

            currentScale = Random.Range(minBallSize,maxBallSize);
            newBallScale.localScale = new Vector3 (currentScale, currentScale, currentScale);

            rb = newBall.GetComponent<Rigidbody>();
            rb.velocity = Vector3.down * Mathf.Abs(gravityModifier / (currentScale - lvlIncreaseModifier));            

            //������� �� ������ �������� �������  =) ��� ��� ����.
            currentDelay = Random.Range(Mathf.Abs(minSpawnDelay - lvlIncreaseModifier), Mathf.Abs(maxSpawnDelay - lvlIncreaseModifier));
        }
    }
   

    Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void IncreaseModifier()
    {
        lvlIncreaseModifier += lvlIncreaseStep;
    }
}
