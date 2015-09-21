using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Connect ();
	}

	void Connect(){
		Debug.Log ("Connect");
		PhotonNetwork.ConnectUsingSettings ("ay");
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby(){
		Debug.Log ("Joined random room");
		//If a room exists, join a random room
		if (PhotonNetwork.room != null) {
			PhotonNetwork.JoinRandomRoom ();
		} else { //else create a room
			PhotonNetwork.CreateRoom(null);
		}
	}

	void OnJoinedRoom(){
		Debug.Log ("Joined room");
		SpawnPlayer (); //spawn player when they join the room
	}

//	void OnConnectedToMaster(){
//		Debug.Log ("Connected to master");
//		Debug.Log ("Creating room");
//		PhotonNetwork.CreateRoom ("123");
//		PhotonNetwork.JoinRoom ("123");
//	}

	void SpawnPlayer(){
		PhotonNetwork.Instantiate ("Player", Vector3.zero, Quaternion.identity, 0);
	}
}
