using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public bool ranged;
	public double ammo, weaponRange, shotCooldown, damage;
	public float shotTime;
	public WeaponManager wm;
	public LayerMask lm;


	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	protected void Update () {
		shotTime += Time.deltaTime;

		//Debugging purposes, weapon distance when equipped
		if(wm) {
			Vector2 forward = wm.gameObject.transform.right;
			Vector2 pos = wm.gameObject.transform.position;
			Debug.DrawRay(pos, forward, Color.green, (float)weaponRange);

		}

	}

	public virtual void Fire() {



	}
}
