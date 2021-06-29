using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class targetAnimmalText : MonoBehaviour
{
    public GameObject spawnManager;
   

    // Update is called once per frame
    void Update()
    {
        int xD = spawnManager.GetComponent<EnemySpawnManager>().UIvurulmasıgereken;
        gameObject.GetComponent<TextMeshProUGUI>().text = xD < 0 ? "0" : xD.ToString();
    }
}
