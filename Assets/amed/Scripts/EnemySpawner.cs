using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool isAvailable=false;
    float delay;
    [SerializeField] float min, max;
    public GameObject[] animals;
    public GameObject selectedAnimal;

    void Start()
    {
        

        
    }

    private IEnumerator GenerateEnemyProccess()
    {
       
            
                delay = UnityEngine.Random.Range(min, max);

                CreateEnemy();
                yield return new WaitForSeconds(delay);
            
        
    }

    private void CreateEnemy()
    {
        int randomSayı = Random.Range(0, animals.Length);
        if(selectedAnimal == null)
        {
            return;
        }
        Instantiate(selectedAnimal,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvailable)
        {
            StartCoroutine(GenerateEnemyProccess());
            isAvailable = false;
        }
        
    }
}
