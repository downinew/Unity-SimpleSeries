using UnityEngine;
using System.Collections;

public class Ball_destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 100);
	}

	/*/*void OnCollisionEnter(){
		Destroy (gameObject, 5);
	}*/
}
