using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static EnemySpawnManager manager;
    public static LevelManager levelManager;
    public int can = 3;

    private void Awake()
    {
        levelManager = this;
        manager = GameObject.FindObjectOfType<EnemySpawnManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void CheckAnimal(Animals animal)
    {
        if(animal != manager.currentLevelxD.vur)
        {
            levelManager.can -= 1;
        }
        else
        {
            manager.currentLevelxD.vurulan += 1;
        }
    }
}
