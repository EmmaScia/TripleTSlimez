using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScreen : MonoBehaviour
{
    // Function to load a specific scene by its name
    public void GoToNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to load the next scene in the Build Settings order
    public void GoToNextIndex()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }
}
