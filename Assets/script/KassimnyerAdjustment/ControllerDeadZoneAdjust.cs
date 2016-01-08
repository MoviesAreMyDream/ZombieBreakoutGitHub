using UnityEngine;
using System.Collections;

public class ControllerDeadZoneAdjust : MonoBehaviour {

	void Update () {
        float deadzone = 0.25f;
        Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 stickInput2 = new Vector2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"));

        if (stickInput.magnitude < deadzone)
            stickInput = Vector2.zero;
        else
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));

        if (stickInput2.magnitude < deadzone)
            stickInput2 = Vector2.zero;
        else
            stickInput2 = stickInput2.normalized * ((stickInput2.magnitude - deadzone) / (1 - deadzone));

        //print(Input.GetAxis("RHorizontal"));
    }
}
