using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
	public double health;
	public int decalTime;
	public GameObject bloodDecal;
	public bool isDead;
	public Sprite Dead;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0d) {
			Debug.Log("DEAD");
			gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Dead;
			StartCoroutine(Destroy()); 
			isDead = true; 
		}
	}
	public void Damage(double dmg) {
		StartCoroutine(SpawnDecal(dmg)	);
	}
	IEnumerator SpawnDecal(double dmg) {
		GameObject blood = (GameObject)Instantiate(bloodDecal);
		health = health - dmg; 	 	
		yield return new WaitForSeconds(decalTime);
		Destroy(blood);
	}
	IEnumerator Destroy() {
		yield return new WaitForSeconds(3); 
		Destroy(gameObject);
	}
}
