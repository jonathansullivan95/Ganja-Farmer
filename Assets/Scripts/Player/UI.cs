using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text prompt, ammoText;
    public Image currentItem;
    public Image[] slots;
    public Sprite emptySlot;
	private List<GameObject> inv;
    private InventoryManager im;
	private WeaponManager wm;

	// Use this for initialization
	void Awake () {
        im = GetComponent<InventoryManager>();
		wm = GetComponent<WeaponManager>();

	}
	
	// Update is called once per frame
	void Update () {
		//CURRENT ITEM STUFF
//        if (im.currentItem)
//        {
//            currentItem.sprite = im.currentItem.GetComponent<Item>().hudIcon;
//        }
//        else
//        {
//            currentItem.sprite = null;
//        }

		//SHOULD NOT REALLY CALL THIS SHIT EVERY FRAME ***FIX***
        inv = im.GetAllItems();
        for (int i = 0; i < im.currentCapacity; i++)
        {
            if (inv[i])
            {
                slots[i].sprite = inv[i].GetComponent<Item>().hudIcon;
            }
            else
            {
                slots[i].sprite = emptySlot;
            }
        }
        if (im.currentCapacity == 0)
        {
            foreach (Image slot in slots)
            {
                slot.sprite = emptySlot;
            }
        }
		if(wm.currentWeapon) {
			if(wm.currentWeapon.ranged) {
				ammoText.text = wm.currentWeapon.ammo.ToString();
			}
			else {
				ammoText.text = "-";
			}
		}
		else {
			ammoText.text = "N/A";
		}
	}
    public void StartPrompt(string words, float time)
    {
        StopAllCoroutines();
        StartCoroutine(SetPrompt(words, time));
    }
	public void StopPrompt()
	{
		StopAllCoroutines();
		prompt.text = "";
	}
    private IEnumerator SetPrompt(string words, float time)
    {
        Debug.Log("setting prompt");
        prompt.text = words;
        yield return new WaitForSeconds(time);
        prompt.text = "";
    }
}
