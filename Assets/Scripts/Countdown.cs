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
    public GameObject zombieOne;
    public GameObject zombieTwo;
    public GameObject zombieThree;


    private void Start()
    {
        timerIsRunning = true;

        //zombies dissapear
        if (zombieOne != null)
        {
            zombieOne.SetActive(false);
        }

        if (zombieTwo != null)
        {
            zombieTwo.SetActive(false);
        }


        if (zombieThree != null)
        {
            zombieThree.SetActive(false);
        }

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
                ActivateObject();
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

    void ActivateObject()
    {
        //zombie One appearing
        if (zombieOne != null && !zombieOne.activeSelf)
        {
            zombieOne.SetActive(true); // Make the object visible
            Debug.Log("Zombie One has appeared!");
        }

        //zombie two appearing
        if (zombieTwo != null && !zombieTwo.activeSelf)
        {
            zombieTwo.SetActive(true); // Make the object visible
            Debug.Log("Zombie One has appeared!");
        }

        //zombie three appearing
        if (zombieThree != null && !zombieThree.activeSelf)
        {
            zombieThree.SetActive(true); // Make the object visible
            Debug.Log("Zombie One has appeared!");
        }
    }

}
