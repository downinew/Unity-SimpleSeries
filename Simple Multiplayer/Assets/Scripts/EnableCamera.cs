using UnityEngine;
using System.Collections;

public class EnableCamera : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        if (!networkView.isMine)
        {
            Camera playerCamera = GetComponent<Camera>();
            playerCamera.enabled = false;
        }
	}
	
}
