using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon {
	public float projAngleVariance, projVelocity;
	public GameObject projectile;
	// Use this for initialization
	void Awake () {
		ranged = true;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();

	}

	public override void Fire () {
		//DO STUFF HERE FOR ATTACK, spawn proj
	}
}
