using UnityEngine;
using System.Collections;

public class VerticalLookScript : MonoBehaviour {


    float mouseSensitivity = 3.0f;
    float neckRange = 60.0f;
    float verticalRotation = 0.0f;
	
	// Update is called once per frame
	void Update () {

        float lookY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= lookY;
        verticalRotation = Mathf.Clamp(verticalRotation, -neckRange, neckRange);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

	}
}
