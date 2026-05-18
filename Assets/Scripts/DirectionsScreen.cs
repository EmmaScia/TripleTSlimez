using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectionsScreen : MonoBehaviour
{
    public void startLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
