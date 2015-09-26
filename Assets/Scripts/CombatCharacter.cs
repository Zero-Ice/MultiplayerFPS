using UnityEngine;
using System.Collections;

public class CombatCharacter : MonoBehaviour {
	[SerializeField] GameObject Player; //first person character
	[SerializeField] GameObject Weapon1, Weapon2;

	byte Health;
	byte currentWeaponState; //0 for gun, 1 for melee

	private CombatStats combatStats1, combatStats2;

	// Use this for initialization
	void Start () {
	Cursor.lockState = CursorLockMode.Locked;
		Health = 100;

		combatStats1 = Weapon1.GetComponent<CombatStats> (); //get weapon 1's stats
		combatStats2 = Weapon2.GetComponent<CombatStats> (); //get weapon 2's stats

		currentWeaponState = combatStats1.WeaponType; //Set current weapon player is holding to weapon 1's(default) type
	}
	
	// Update is called once per frame
	void Update () {
		//To do, get current weapon state , slash

		//0 LMB, 1 RMB, 2 MMB
		if(Input.GetMouseButtonDown(0)){
			if(currentWeaponState == 0){ //if weapon state is a gun
				Shoot ();
			}
			else{
				//Slash();
			}
		}

		Debug.DrawRay (Player.transform.position, Player.transform.forward*50, Color.green);
	}

	void Shoot(){
		//GameObject bulletInstance = Instantiate (combatStats1.AmmoType, transform.position, transform.rotation) as GameObject;
		//bulletInstance.GetComponent<Bullet> ().direction = Player.transform.forward;//(Player.transform.rotation.x, transform.rotation.y, 0);
		RaycastHit hit;
		if (Physics.Raycast (Player.transform.position, Player.transform.forward*50, out hit)) {
			if(hit.transform.gameObject.tag == "EntityMob")
				Debug.Log("hit a mob");
			else
				Debug.Log("hit nothing");
		}

	}


}
