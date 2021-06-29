using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VRPointer : MonoBehaviour
{
    public OVRControllerHelper attachedControllerHelper;

    LineRenderer lineRenderer;
    
    public Gradient hitGradient, notHitGradient;

    public LayerMask validHitLayers;
    public float maxDistance = 100;

    VRButton interactingVRButton;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Physics.Raycast(lineRenderer.transform.position, lineRenderer.transform.forward, out RaycastHit hit, maxDistance, validHitLayers))
        {
            lineRenderer.SetPosition(1, transform.InverseTransformPoint(hit.point));
            lineRenderer.colorGradient = hitGradient;

            if (interactingVRButton != null)
            {
                interactingVRButton.OnDehighlighted();
            }

            interactingVRButton = hit.collider.GetComponent<VRButton>();
            interactingVRButton.OnHighlighted();

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, attachedControllerHelper.m_controller) || Input.GetMouseButtonDown(0))
            {
                interactingVRButton.OnClicked();
            }
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, maxDistance));
            lineRenderer.colorGradient = notHitGradient;

            if (interactingVRButton != null)
            {
                interactingVRButton.OnDehighlighted();

                interactingVRButton = null;
            }
        }
    }
}
