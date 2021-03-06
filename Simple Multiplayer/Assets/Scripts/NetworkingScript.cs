﻿using UnityEngine;
using System.Collections;

public class NetworkingScript : MonoBehaviour {

	string registerGameName = "Simple_Multiplayer_beginning_!@#$";
	float refreshRequestLength = 3.0f;
	HostData[] hostData;
    public GameObject spawnPoint;
    public bool spawned = false;

	private void StartServer(){
		//First is the numOfPlayers
		Network.InitializeServer(16, 25002, false);
		MasterServer.RegisterHost(registerGameName, "Simple Multiplayer: Beginning", "This is my first try at a multiplayer game!");
	}

	void OnServerInitialized(){
		Debug.Log("Dat shit initialized");
        SpawnPlayer();
	}

	void OnMasterServerEvent( MasterServerEvent masterServerEvent)
    {
        if (masterServerEvent == MasterServerEvent.RegistrationSucceeded)
        {
			Debug.Log("Registration shit succeeded");
		}
	}

	public IEnumerator RefreshHostList()
    {
		Debug.Log("Refreshing...");
		MasterServer.RequestHostList(registerGameName);
		//float timeStarted = Time.time;
		float timeEnd = Time.time + refreshRequestLength;

		while(Time.time < timeEnd){
			
            hostData = MasterServer.PollHostList();
			yield return new WaitForEndOfFrame();

		}

        if (hostData == null || hostData.Length == 0)
            Debug.Log("No active servers have been found");
        else
            Debug.Log("Found dat shit");
	}

    private void SpawnPlayer()
    {
        Debug.Log("Spawning...");
        Vector3 position = spawnPoint.transform.position;
        Network.Instantiate(Resources.Load("Prefabs/SamplePlayer"), position, Quaternion.identity, 0);
    }

    void OnPlayerDisconnect(NetworkPlayer player)
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

    void OnApplicationQuit()
    {
        if (Network.isServer)
        {
            Network.Disconnect(200);
            MasterServer.UnregisterHost();
        }
        if (Network.isClient)
        {
            Network.Disconnect(200);
        }
    }

    void OnGUI()
    {
        if (Network.isClient && !spawned)
        {
            if (GUI.Button(new Rect(25f, 25f, 150f, 30f), "Spawn Player"))
            {
                SpawnPlayer();
                spawned = true;
            }
        }



        if (!Network.isClient && !Network.isServer)
        {

            if (GUI.Button(new Rect(25f, 25f, 150f, 30f), "Start Server"))
            {
                StartServer();
            }

            if (GUI.Button(new Rect(25f, 65f, 150f, 30f), "Refresh Server List"))
            {
                StartCoroutine("RefreshHostList");
            }

            if (hostData != null)
            {
                for (int i = 0; i < hostData.Length; i++)
                {
                    if (GUI.Button(new Rect(Screen.width / 2, 65f + (30f * i), 300f, 30f), hostData[i].gameName))
                    {
                        Network.Connect(hostData[i]);
                        Debug.Log("Dat Shit Connected");

                    }
                }
            }

        }
    }
}
