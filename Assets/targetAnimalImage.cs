using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetAnimalImage : MonoBehaviour
{

    public GameObject spawnManager;


    void Update()
    {
        gameObject.GetComponent<Image>().sprite = spawnManager.GetComponent<EnemySpawnManager>().currentTargetIcon;
    }
}
