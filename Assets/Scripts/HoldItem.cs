using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    public OVRControllerHelper attachedControllerHelper;
    public float holdDistance = 100f;
    public LayerMask holdableItemLayer;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, holdDistance, holdableItemLayer))
        {
            IHoldable item = hit.collider.gameObject.GetComponentInChildren<IHoldable>();
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, attachedControllerHelper.m_controller) || Input.GetMouseButtonDown(0))
            {
                item.Hold();
            }
        }
    }
}
