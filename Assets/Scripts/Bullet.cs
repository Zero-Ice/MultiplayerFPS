using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float duration;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		duration += Time.deltaTime;

		if(duration > 2){
			Destroy (gameObject);
		}

		transform.Translate (direction);
	}
}
