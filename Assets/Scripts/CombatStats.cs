using UnityEngine;
using System.Collections;

public class CombatStats : MonoBehaviour {
	public byte WeaponType; //0 for ranged, 1 for melee, 2 for hybrid
	public byte DefaultHybridWeaponState; //for hybrid weapon
	public GameObject AmmoType;
	public byte Damage, MagazineSize, ClipSize, RateOfFire, Reload, RecoilRate, Accuracy;

	byte WeaponState; 

	// Use this for initialization
	void Start () {

		//Initialize type of weapon
		switch (WeaponType) {
		default:
			WeaponState = 0;
			break;
		case 1:
			WeaponState = 1;
			break;
		case 2:
			WeaponState = DefaultHybridWeaponState;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
