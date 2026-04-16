using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI timerText;
    private float timeRemaining = 5f;
    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Decrement time
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                DisplayTime(timeRemaining);
                timerIsRunning = false;
                Debug.Log("Time is up!");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Ensures time doesn't show negative
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, Mathf.Infinity);
        // Formats to 1 decimal place, e.g., "5.0"
        timerText.text = timeToDisplay.ToString("F0");
    }

}
