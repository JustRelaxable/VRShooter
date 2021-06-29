using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yay : MonoBehaviour,IHoldable
{
    public GameObject leftHand;
    public GameObject rightHand;
    private OVRControllerHelper leftControllerHelper;
    private OVRControllerHelper rightControllerHelper;
    public GameObject gerilmemişNokta;
    public GameObject gerilmişNokta;
    public float rightHandDistanceForGerme = 0.1f;
    public float eskiHalineDönmeHızı = 0.1f;
    public GameObject tutamaç;
    private GameObject spawnedOk;
    private bool isHoldingLeft = false;
    private float currentGerme = 0f;
    private bool isHoldingRight = false;
    public GameObject ok;
    float minMag;
    float maxMag;
    public Animator animator;

    public GameObject lineRenderer;

    private void Awake()
    {
        minMag = (tutamaç.transform.position - gerilmemişNokta.transform.position).magnitude;
        maxMag = (tutamaç.transform.position - gerilmişNokta.transform.position).magnitude;
        leftControllerHelper = leftHand.GetComponentInChildren<OVRControllerHelper>();
        rightControllerHelper = rightHand.GetComponentInChildren<OVRControllerHelper>();
    }

    private void Update()
    {
        currentGerme = animator.GetFloat("Blend");

        if (isHoldingLeft)
        {
            CheckRightHandGerme();
            Vector3 difference = leftHand.transform.position - rightHand.transform.position;
            transform.position = leftHand.transform.position;
            Quaternion leftHandRot = leftHand.transform.rotation;
            Quaternion rot = Quaternion.identity;
            lineRenderer.GetComponent<LineRenderer>().enabled=false; // AMEDDD
            if (isHoldingRight)
            {
                animator.SetFloat("Blend", DistanceNormalized(difference));
                spawnedOk.transform.localPosition = Vector3.Lerp(gerilmemişNokta.transform.localPosition, gerilmişNokta.transform.localPosition, currentGerme);
                Quaternion lookRot = Quaternion.LookRotation(difference);
                rot = Quaternion.Euler(lookRot.eulerAngles.x, lookRot.eulerAngles.y, leftHandRot.eulerAngles.z);
            }
            else
            {
                currentGerme -= (Time.deltaTime * eskiHalineDönmeHızı);
                currentGerme = Mathf.Clamp(currentGerme, 0f, 1f);
                animator.SetFloat("Blend", currentGerme);
                rot = leftHandRot;
            }      
            transform.rotation = rot;
            
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, leftHand.transform.rotation.z);
        }
    }

    public float DistanceNormalized(Vector3 difference)
    {
        float normalized = ((difference.magnitude - minMag) / (maxMag - minMag));
        return Mathf.Clamp(normalized, 0f, 1f);
    }

    public void Hold()
    {
        isHoldingLeft = true;
    }

    public void CheckRightHandGerme()
    {
        float distance = (rightHand.transform.position - gerilmemişNokta.transform.position).magnitude;


        if (distance < rightHandDistanceForGerme)
        {
            if (Input.GetMouseButtonDown(0))
            {
                spawnedOk = Instantiate(ok, transform);
                spawnedOk.GetComponent<Rigidbody>().useGravity = false;
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, rightControllerHelper.m_controller) || Input.GetMouseButton(0))
            {
                isHoldingRight = true;
            }
            else
            {
                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isHoldingRight = false;
            if (spawnedOk != null)
            {
                //spawnedOk.transform.parent = null;
                Vector3 force = new Vector3(0, 0, 200) * currentGerme;
                force = transform.TransformVector(force);
                
                spawnedOk.GetComponent<Rigidbody>().AddForce(force);
                spawnedOk.transform.localRotation = Quaternion.LookRotation(force);
                spawnedOk.GetComponent<Ok>().isReleased = true;
                spawnedOk.transform.parent = null;
                spawnedOk.GetComponent<Rigidbody>().useGravity = true;
                spawnedOk = null;
            }
        }
    }
}
