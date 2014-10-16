using UnityEngine;
using System.Collections;

public class Pew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Screen.lockCursor && Input.GetButtonDown("Fire1")){
		gameObject.audio.Play();
		}
	}
}
