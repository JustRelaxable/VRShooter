using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEmulator : MonoBehaviour
{
    const float MOUSE_SCALE_X = -2.0f;
    const float MOUSE_SCALE_Y = 2.0f;
    const float MOUSE_POS_SCALE_X = 0.01f;
    const float MOUSE_POS_SCALE_Y = 0.01f;
    const float MOUSE_SCALE_HEIGHT = 1.0f;

    public KeyCode requiredButton = KeyCode.LeftShift;
    public KeyCode positionButton = KeyCode.S;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(requiredButton) && !Input.GetKey(positionButton))
        {
            Vector3 emulatedTranslation = transform.localPosition;
            float deltaMouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
            float emulatedHeight = deltaMouseScrollWheel * MOUSE_SCALE_HEIGHT;
            emulatedTranslation.y += emulatedHeight;
            transform.localPosition = emulatedTranslation;

            float deltaX = -Input.GetAxis("Mouse X");
            float deltaY = -Input.GetAxis("Mouse Y");

            Vector3 emulatedAngles = transform.localEulerAngles;
            float emulatedRoll = emulatedAngles.x;
            float emulatedYaw = emulatedAngles.y;

            emulatedRoll += deltaY * MOUSE_SCALE_Y;
            emulatedYaw += deltaX * MOUSE_SCALE_X;

            transform.localEulerAngles = new Vector3(emulatedRoll, emulatedYaw, transform.localEulerAngles.z);
        }
        if(Input.GetKey(requiredButton) && Input.GetKey(positionButton))
        {
            Vector3 localPosition = transform.localPosition;
            float deltaX = -Input.GetAxis("Mouse X");
            float deltaY = -Input.GetAxis("Mouse Y");
            localPosition.z += -deltaY * MOUSE_POS_SCALE_Y;
            localPosition.x += -deltaX * MOUSE_POS_SCALE_X;

            float deltaMouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
            float emulatedHeight = deltaMouseScrollWheel * MOUSE_SCALE_HEIGHT;
            localPosition.y += emulatedHeight;
            transform.localPosition = localPosition;
        }
    }
}
