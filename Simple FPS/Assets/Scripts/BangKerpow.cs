using UnityEngine;
using System.Collections;

public class BangKerpow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Screen.lockCursor && Input.GetButtonDown("Fire2")){
			gameObject.audio.Play();
		}
	}
}
