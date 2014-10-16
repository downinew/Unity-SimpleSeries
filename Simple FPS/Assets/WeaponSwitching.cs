using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {

	GameObject weapon01;
	GameObject weapon02;



	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			SwapWeapons();
		}
	}


	public void SwapWeapons(){
		if (weapon01.activeSelf == true) 
		{
			weapon01.SetActive (false);
			weapon02.SetActive(true);
		}
		
	}


}
