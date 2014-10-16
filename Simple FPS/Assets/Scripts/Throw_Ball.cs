using UnityEngine;
using System.Collections;

public class Throw_Ball : MonoBehaviour {


	public GameObject ball;
	public float ballImpulse = 20.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	// For Cloud surfing just get button && remember to destroy object afterwords
	void Update () {
		if(Input.GetButton("Fire1")){
			Camera cam = Camera.main;
			GameObject ballToThrow = (GameObject)Instantiate(ball, cam.transform.position + cam.transform.forward, cam.transform.rotation);
			ballToThrow.rigidbody.AddForce(cam.transform.forward * ballImpulse, ForceMode.Impulse);
		}


	}
}
