using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {
	public float damageDelay;
	// Use this for initialization
	void Start () {
		ranged = false;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();



	}

	public override void Fire () {
		//Weapon cooldownm
		if(shotTime > shotCooldown) {
			shotTime = 0;	//trigger cooldown
			Vector2 dir = wm.gameObject.transform.right;	//this is forward for player
			//dir = Vector2.Scale(dir, new Vector2(0.5f, 0.5f));
			RaycastHit2D[] hit = Physics2D.RaycastAll(wm.gameObject.transform.position, dir* (float)weaponRange, (float)weaponRange*2.7f);	//Fire a ray and return data for what is hit

			foreach(RaycastHit2D col in hit) //Cycle through all things hit and start coroutine to add delayed damage to enemies (compensate for attack anim)
			{
				if(col.collider.gameObject.tag == "Enemy")
				{
					Debug.Log("HIT ENEMY");
					StartCoroutine(DamageDelay(col));
					//DAMAGE, SOUND, BLOOD EFFECTS?
				}
			}
		}

	}

	public IEnumerator DamageDelay(RaycastHit2D col) {
		yield return new WaitForSeconds(damageDelay);
		col.collider.gameObject.GetComponent<HealthManager>().Damage(damage);
	}


}
