using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ok : MonoBehaviour
{
    private Rigidbody okRigidbody;
    public bool isReleased = false;

    private void Awake()
    {
        okRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        if (isReleased)
        {
            transform.forward = Vector3.Slerp(transform.forward, okRigidbody.velocity.normalized,20 * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isReleased = false;
    }
}
