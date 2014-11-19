using UnityEngine;
using System.Collections;

public class Shoot_Target : MonoBehaviour {

    public float range = 15.0f;
    public float kickStrength = 25.0f;
    Camera playerCamera;

	// Use this for initialization
	void Start () {
        playerCamera = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0)) { 
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo, range))
        {
            Vector3 hitPoint = hitInfo.point;
            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForceAtPosition(playerCamera.transform.forward * kickStrength, hitPoint, ForceMode.Impulse);
            }
        }
        }

	}
}
