using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
