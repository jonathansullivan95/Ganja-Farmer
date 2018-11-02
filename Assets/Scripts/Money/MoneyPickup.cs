using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoneyPickup : MonoBehaviour {

    public enum collType { Single, Double, Triple};
    public collType type;

    public float Scale;
    public float shrinkSpeed;

    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            switch (type)
            {
			case collType.Single:
				player.gameObject.GetComponent<MoneyManager>().Add(1);
                    player.gameObject.GetComponent<AudioSource>().PlayOneShot(pickupSound);
                    Destroy(this.gameObject);
                    break;
			case collType.Double:
				player.gameObject.GetComponent<MoneyManager>().Add(2);
                    player.gameObject.GetComponent<AudioSource>().PlayOneShot(pickupSound);
                    Destroy(this.gameObject);
                    break;
			case collType.Triple:
				player.gameObject.GetComponent<MoneyManager>().Add(3);
                    player.gameObject.GetComponent<AudioSource>().PlayOneShot(pickupSound);
                    Destroy(this.gameObject);
                    break;
            }
            
        }
    }

}
