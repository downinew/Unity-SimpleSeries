using UnityEngine;
using System.Collections;

public class NetworkingScript : MonoBehaviour {

	string registerGameName = "Simple_Multiplayer_beginning";
	float refreshRequestLength = 3.0f;
	HostData[] hostData;

	private void StartServer(){
		//First is the numOfPlayers
		Network.InitializeServer(4, 25002, false);
		MasterServer.RegisterHost(registerGameName, "Simple Multiplayer: Beginning", "This is my first try at a multiplayer game!");
	}

	void OnServerInitialized(){
		Debug.Log("Dat shit initialized");
	}

	void OnMasterServerEvent( MasterServerEvent mSE){
		if(mSE == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Registration shit succeeded");
		}
	}

	public IEnumerable RefreshHostList(){

		Debug.Log("Refreshing...");
		MasterServer.RequestHostList(registerGameName);
		float timeStarted = Time.time;
		float timeEnd = Time.time + refreshRequestLength;

		while(Time.time < timeEnd){
			hostData = MasterServer.PollHostList();
			yield return new WaitForEndOfFrame();
		}

		if ( hostData == null || hostData.Length == 0)
			Debug.Log("No active servers have been found");


	}


	void OnGUI(){

		if(GUI.Button(new Rect(25f,25f, 150f,30f),"Start Server")){
			StartServer();
		}

		if(GUI.Button(new Rect(25f,65f, 150f,30f),"Refresh Host List")){
			StartCoroutine("RefreshHostList");
		}

	}
}
