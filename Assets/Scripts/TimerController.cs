using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float timeSinceStart;


    void Update()
    {
        timeSinceStart += Time.deltaTime;
        timerText.text = timeSinceStart.ToString("0.0");
    }
}
