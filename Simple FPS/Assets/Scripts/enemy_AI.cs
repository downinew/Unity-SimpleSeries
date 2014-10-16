using UnityEngine;
using System.Collections;

public class enemy_AI : MonoBehaviour {

	public GameObject player;
	public float enemyHealth = 100.0f;
	public float enemyRadius = 5.0f;
	public float enemyArea = 25.0f;
	public float enemySpeed = 5.0f;
	public float damping = 6.0f;
	bool enemyEngaged = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(transform.position, player.transform.position);
		if(distance < enemyArea){

		}
	}

	void enemyAttack() {
		transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
	}

	void enemyLookAt(){
		Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damping * Time.deltaTime);
	}
}
