using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public int sceneIndex;
    public bool isExit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ok"))
        {
            if (isExit)
            {
                Application.Quit();
            }

            StartCoroutine(StartTheGame());
        }
    }

    IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneIndex);
    }
}
