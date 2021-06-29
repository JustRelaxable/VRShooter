using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VRButton : MonoBehaviour
{
    Button attachedButton;

    void Start()
    {
        attachedButton = GetComponent<Button>();
    }
    
    public void OnHighlighted()
    {
        attachedButton.image.color = attachedButton.colors.highlightedColor;
    }

    public void OnDehighlighted()
    {
        attachedButton.image.color = attachedButton.colors.normalColor;
    }

    public void OnClicked()
    {
        attachedButton.image.color = attachedButton.colors.pressedColor;
        attachedButton.onClick.Invoke();
    }

    public void ButtonClicked()
    {
        Debug.Log("ButtonClicked");
    }
}
