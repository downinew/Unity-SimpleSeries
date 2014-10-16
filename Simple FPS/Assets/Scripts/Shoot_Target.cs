using UnityEngine;
using System.Collections;

public class Shoot_Target : MonoBehaviour {

	public float cooldown = 0.1f;
	public float cooldownRemaining = 0;
	public float range = 100.0f;
	public GameObject debrisPrefab;
	public float kickStrength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		cooldownRemaining -= Time.deltaTime;

		if((Input.GetMouseButton(0) || Input.GetMouseButton(1)) && cooldownRemaining <= 0){
			if(Input.GetMouseButton(1))
			{
				kickStrength = 75.0f;
			} else {
				kickStrength = 15.0f;
			}
			cooldownRemaining = cooldown;
			Ray ray = new Ray( Camera.main.transform.position,Camera.main.transform.forward);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo, range)) {
				Vector3 hitPoint = hitInfo.point;
				//Instantiate(debrisPrefab, hitPoint,Quaternion.identity);
				if(hitInfo.rigidbody != null) {
					hitInfo.rigidbody.AddForceAtPosition(Camera.main.transform.forward * kickStrength, hitPoint, ForceMode.Impulse);
				}
			}


		}
	}
}
