using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
        Application.Quit();
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }
    public void train()
    {
        SceneManager.LoadScene(2);
    }



}
