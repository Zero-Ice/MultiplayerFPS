using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	[SerializeField] GameObject FirstPersonCharacter;

	// Use this for initialization
	void Start () {
		if (photonView.isMine) {
			GetComponent<FirstPersonController> ().enabled = true;
			FirstPersonCharacter.GetComponent<AudioListener> ().enabled = true;
			FirstPersonCharacter.GetComponent<Camera>().enabled = true;
		} else {
			GetComponent<Rigidbody>().useGravity = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {

		} else {
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		Debug.Log ("Photon Serialize View");
		if (stream.isWriting) {
			//Send actual position to network
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} else {
			//Someone else's player. Receive their position
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
