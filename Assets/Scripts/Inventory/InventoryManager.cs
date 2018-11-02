using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public  List<GameObject> inventory;
    public GameObject currentItem;
    public AudioClip pickupSound;
    public int maxCapacity, currentCapacity;

	// Use this for initialization
	void Awake () {
        inventory = new List<GameObject>();
        currentCapacity = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public bool Add(GameObject obj)
    {
        Item pickupScript = obj.GetComponent<Item>();
        if (pickupScript)
        {
            inventory.Add(obj);
            currentCapacity++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Use(GameObject searchItem)
    {
        GameObject foundItem = inventory.Find(delegate(GameObject obj) { return obj.tag == searchItem.tag; }); //Find iteam with matching tag
        if (foundItem != null)
        {
            inventory.Remove(foundItem); // Remove from list
            currentCapacity--;
            if (inventory.Count > 0) { currentItem = inventory[0]; }
            else currentItem = null; 
            return true;
        }
        else return false;
    }

    public int GetBalance(GameObject searchItem)
    {
        List<GameObject> foundItems = inventory.FindAll(delegate(GameObject obj) { return obj.tag == searchItem.tag; }); //finds how many iteams with matching tag
        return foundItems.Count;
    }

    public List<GameObject> GetItems(string tag)
    {
        // Get a list of all the GameObjects with a matching type
        List<GameObject> foundItems = inventory.FindAll(delegate(GameObject obj) { return obj.tag == tag; });
        return foundItems;
    }
    public List<GameObject> GetAllItems()
    {
        // Get a list of all the GameObjects with a matching type
        List<GameObject> foundItems = inventory.FindAll(delegate(GameObject obj) { return true; });
        return foundItems;
    }

    public void DeleteAll()
    {
        inventory.Clear();
        currentCapacity = 0;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.GetComponent<Item>())
        {
            GetComponent<AudioSource>().PlayOneShot(pickupSound);
            if (hit.tag == "Seeds")
            {
                Add(hit.gameObject);
                hit.gameObject.transform.SetParent(gameObject.transform);
                currentItem = hit.gameObject;
                hit.gameObject.SetActive(false);
            }
        }
    }


}
