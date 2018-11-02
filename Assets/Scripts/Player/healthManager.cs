using UnityEngine;
using System.Collections;

public class healthManager : MonoBehaviour {

    private const int MAX_HEALTH = 100;
    private const int HEALTH_INCREMENT = 1;
    private const float HEALTH_UPDATE_TIME_STEP = 2f;
    public int health;

	// Use this for initialization
	void Start () {
        health = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddHealth(int heal)
    {
        if ((MAX_HEALTH + heal) > health)
        {
            health = MAX_HEALTH;
        }
        else
        {
            health += heal;
        }
    }

    public void RemoveHealth(int damage)
    {
        if(damage > health)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }
    }
}
