using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amedDumanOkAtıyor : MonoBehaviour
{
     float range=100;
    [SerializeField] Camera fpsCam;
    [SerializeField] GameObject arrow;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Vector3 enemyPos = hit.transform.position;
            CreateArrow(enemyPos);
        }
    }

    void CreateArrow(Vector3 pos)
    {
         Instantiate(arrow, gameObject.transform.position, transform.rotation);
       
            
        
        
    }
}
