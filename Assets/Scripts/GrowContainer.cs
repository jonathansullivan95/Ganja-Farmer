using UnityEngine;
using System.Collections;

public class GrowContainer : MonoBehaviour {
    public Sprite grownSprite;
    public bool growing;
	// Use this for initialization
	void Start () {
	
	}

    public void Grow(float time)
    {
        StartCoroutine(StartGrow(time));
    }
    IEnumerator StartGrow(float time) {
        growing = true;
        yield return new WaitForSeconds(time);
        Debug.Log("grown");
        //Set Sprite
        Transform[] sprites = GetComponentsInChildren<Transform>();
        foreach (Transform obj in sprites)
        {
            if (obj.tag == "SpritePos")
            {
                obj.GetComponent<SpriteRenderer>().sprite = grownSprite;
            }
        }
        growing = false;
    }
}
