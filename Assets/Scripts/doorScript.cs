using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {

    public AudioClip doorSound;
	public float DOOR_OPEN_ANGLE; 
	public float DOOR_CLOSED_ANGLE;
    private float doorSpeed = 2;
    private bool enter;
	private bool open = false;

    void Start()
    {
		
    }

    void Update()
    {
		Debug.Log(DOOR_CLOSED_ANGLE);
        if(open)
        {
            Quaternion target = Quaternion.Euler(0, 0, DOOR_OPEN_ANGLE);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * doorSpeed);
        }
        if(!open)
        {
            Quaternion target = Quaternion.Euler(0, 0, DOOR_CLOSED_ANGLE);
			Debug.Log(target);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * doorSpeed);
        }
        
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if (!open)
            {
                open = true;
            }
            
            //open = true;
        }
    }

//    void OnTriggerExit2D(Collider2D hit)
//    {
//        if (hit.gameObject.tag == "Player")
//        {
//            if (open)
//            {
//                open = false;
//            }
//        }
//    }
//
//    void OnTriggerStay2D(Collider2D hit)
//    {
//        if(hit.gameObject.tag == "Player")
//        {
//            transform.localRotation = Quaternion.Euler(0, 0, DOOR_OPEN_ANGLE);
//        }
//    }


}
