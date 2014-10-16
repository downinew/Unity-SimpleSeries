using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float movementSpeed = 10.0f;
	public float mouseSensitivity = 10.0f;
	public float neckRange = 60.0f;
	float verticalRotation = 0.0f;
	float verticalVelocity = 0.0f;
	float jumpVelocity = 6.26f;
	CharacterController cc;
	bool escapekey;
	public GUITexture crosshair;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		// Allows the user to break out of the game by hitting the "Escape" key.
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(Screen.lockCursor){
			escapekey=true;
			Screen.lockCursor = false;
			crosshair.enabled = false;
			} else {
			Screen.lockCursor = true;
			escapekey=false;
			crosshair.enabled = true;;
			}
		}

		if(!escapekey){
		//
		float lookX = Input.GetAxis("Mouse X") * mouseSensitivity;
		float lookY = Input.GetAxis("Mouse Y") * mouseSensitivity;

		verticalRotation -= lookY;
		verticalRotation = Mathf.Clamp(verticalRotation, -neckRange, neckRange);

		// Camera and player rotation
		transform.Rotate(0, lookX, 0);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);

		float facingMovement = Input.GetAxis("Vertical") * movementSpeed;
		float sideMovement = Input.GetAxis("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if(cc.isGrounded && Input.GetButtonDown("Jump")){
			verticalVelocity =jumpVelocity;
		}

		Vector3 speed = new Vector3(sideMovement, verticalVelocity,facingMovement);

		speed = transform.rotation * speed;

		cc.Move(speed * Time.deltaTime);
		}

	}

	void OnGUI() 
	{
		if(escapekey){

		GUI.Box (new Rect (Screen.width/2 - 100, Screen.height/2 - 100, 200 , 200), "Menu");

		if (GUI.Button ( new Rect (Screen.width/2 - 25, Screen.height/2 - 50, 50, 50), "Reload")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
		if(GUI.Button ( new Rect (Screen.width/2 - 25, Screen.height/2 + 25, 50, 50), "Quit")){
				Application.Quit();
			}
		}

	}

}
