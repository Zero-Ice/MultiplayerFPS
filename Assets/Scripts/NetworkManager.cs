using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		Connect ();
	}

	void Update(){
		//Debug.Log (PhotonNetwork.playerList.Length);
	}

	void Connect(){
		Debug.Log ("Connect");
		PhotonNetwork.ConnectUsingSettings ("ay");
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinOrCreateRoom ("Hub", new RoomOptions (){maxPlayers = 20, isVisible = true}, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		Debug.Log ("Joined room");
		Debug.Log (PhotonNetwork.room.name);
		PhotonNetwork.Instantiate ("Player", new Vector3 (0, 10, 0), Quaternion.identity, 0);
	}

	void OnPhotonPlayerConnected(PhotonPlayer other){

	}
}
