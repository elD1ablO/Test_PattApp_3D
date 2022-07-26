using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(SphereCollider))]
public class BallBehavior : MonoBehaviour
{    
    GameManager gameManager;
    int pointsAmount;
        

    private void OnMouseDown()
    {
        gameManager = FindObjectOfType<GameManager>();

        Transform ballScale = GetComponent<Transform>();

        pointsAmount = Mathf.RoundToInt((1 / ballScale.localScale.x) * 10);
        gameManager.AddScore(pointsAmount);
        
        Destroy(gameObject);
    }

}
