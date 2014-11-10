using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    CharacterController cc;
    public Camera playerCamera;
    Transform playerTransform;


    //Simple Movements
    float movementSpeed = 3.0f;
    float mouseSensitivity = 3.0f;
    float verticalRotation = 0.0f;
    float neckRange = 60.0f;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        playerTransform = cc.transform;
        //Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!networkView.isMine)
        {
            return;
        }        


        simpleMovement();

	}
    
    // This method is for simple movement of the player from the main camera view
    void simpleMovement()
    {

        float facingMovement = Input.GetAxis("Vertical") * movementSpeed;
        float sideMovement = Input.GetAxis("Horizontal") * movementSpeed;   

        Vector3 speed = new Vector3(sideMovement, 0, facingMovement);

        float lookX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float lookY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= lookY;
        verticalRotation = Mathf.Clamp(verticalRotation, -neckRange, neckRange);

        // Camera and player rotation
        playerTransform.Rotate(0, lookX, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // This is needed in order to keep the character moving in the desired direction
        speed = playerTransform.rotation * speed;

        cc.Move(speed * Time.deltaTime);

    }


}
