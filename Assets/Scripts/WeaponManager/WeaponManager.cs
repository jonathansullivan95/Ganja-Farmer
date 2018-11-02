using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public Transform weaponTransform;
	public Weapon currentWeapon;
	public float dropSpeed, pickupCooldown;
	private float pickupTime;
	public enum Weapons { Empty, LeadPipe, AR };
	public Weapons currentWeaponType = Weapons.Empty; //Maybe don't intialise???
	public List<GameObject> CharSprites;

	// Use this for initialization
	void Start () {
		foreach(GameObject sprite in CharSprites){
			if(sprite.name == "Empty")
			{
				sprite.GetComponent<SpriteRenderer>().enabled = true;
			}
			else {
				sprite.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		pickupTime += Time.deltaTime;
		if(Input.GetKey(KeyCode.Mouse0)) {
			
			currentWeapon.Fire();

		}
	}

	void OnTriggerStay2D(Collider2D hit) {
		Debug.Log("COL");
		if((hit.gameObject.tag == "Weapon")) {
			Debug.Log("HIT WEAPON");
			if(Input.GetKeyDown(KeyCode.Q)) {
				if(pickupTime > pickupCooldown) {
					if(currentWeapon) {
						//Drop Weapon
						Debug.Log("DROPP");
						currentWeapon.gameObject.GetComponent<SpriteRenderer>().enabled = true;
						currentWeapon.gameObject.transform.parent.DetachChildren();
						currentWeapon.gameObject.GetComponent<Collider2D>().enabled = true;
						currentWeapon.gameObject.GetComponent<Rigidbody2D>().simulated = true;
						currentWeapon.GetComponent<SpriteRenderer>().sortingOrder = 10;
						currentWeapon.wm = null;
						currentWeapon = null;
						foreach(GameObject sprite in CharSprites){
							if(sprite.name == "Empty")
							{
								sprite.GetComponent<SpriteRenderer>().enabled = true;
							}
							else {
								sprite.GetComponent<SpriteRenderer>().enabled = false;
							}
						}
						return;
					}
					if(currentWeapon == null) {
						Debug.Log("PICKUP WEAPON");
						//Set current weapon
						currentWeapon = hit.gameObject.GetComponent<Weapon>();
						currentWeapon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
						currentWeapon.wm = this;
						//Mount Weapon in correct position
						currentWeapon.gameObject.transform.SetParent(weaponTransform);
						currentWeapon.gameObject.transform.position = weaponTransform.position;
						currentWeapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
						pickupTime = 0;
						//SetCurrentWeaponType
						switch(currentWeapon.name)
						{
						case "Pipe":
							currentWeaponType = Weapons.LeadPipe;
							break;
						case "AR15":
							currentWeaponType = Weapons.AR;
							break;
						}
						//SORT ROTATION OUT

						//SetCharSprite
						foreach(GameObject sprite in CharSprites){
							if(sprite.name == currentWeaponType.ToString())
							{
								sprite.GetComponent<SpriteRenderer>().enabled = true;
							}
							else {
								sprite.GetComponent<SpriteRenderer>().enabled = false;
							}
						}
					}


				}
			}
		}
	}
}
