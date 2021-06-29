using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ameddumaninTestOku : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(selfDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
    }
    IEnumerator selfDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
