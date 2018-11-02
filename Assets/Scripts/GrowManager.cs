using UnityEngine;
using System.Collections;

public class GrowManager : MonoBehaviour {
    private UI ui;
    private InventoryManager im;
	public enum GrowState {Idle, Growing, Finished};
	public GrowState state = GrowState.Idle;
	private enum Seeds {Lemon, BlueCheese, JackHerrer};
	private enum Pots {Basic, XL, Square}
	private enum Size {x1, x4, x9}
	private Seeds seed;
	private Pots pot;
	private Size size;

	void Awake () {
		ui = GameObject.Find("Player").GetComponent<UI>();
        im = GetComponent<InventoryManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
			if(state == GrowState.Idle)
			{
				ui.StartPrompt("Welcome to your Grow Station. Press 'Tab' to customise grow or 'E' to start harvest", 5);
			}
        }
    }
    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
			if(Input.GetKeyDown(KeyCode.E))
			{
				if(seed != null && pot != null && size != null)
				{
					//start grow
				}
			}
			if(Input.GetKeyDown(KeyCode.Tab))
			{
				//Pause game and display UI
			}
        }
    }
	void OnTriggerExit2D(Collider2D hit)
	{
		if (hit.tag == "Player")
		{
			ui.StopPrompt();
		}
	}
}
