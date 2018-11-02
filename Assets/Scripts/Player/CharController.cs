using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    private Vector2 velocity;
    public float moveSpeed, camSpeed;
    private Plane ground;
    private Camera cam;
    public float DistanceFromCursor;
    private UI ui;
	private Transform to, from;
	public bool controlDisabled = false;
    void Awake()
    {
        ui = GetComponent<UI>();
        ui.StartPrompt("Welcome, you worthless piece of shit!", 4);
    }

	void Start () {
        ground = new Plane(Vector2.up, Vector2.zero);
        cam = Camera.main;
		camSpeed = 0.02f;
	}
	
	// Update is called once per frame
	void Update () {
		from = cam.transform;
		to = transform;
		//cam.transform.position = transform.position;
		float interpAmount = camSpeed * Time.smoothDeltaTime;
		cam.transform.position = Vector3.Lerp(from.position, to.position, camSpeed);
	}

    void FixedUpdate()
    {
		if(!controlDisabled){
		  	if (Input.GetKey(KeyCode.W)) 
		  	{
		  	    transform.Translate(Vector2.up * moveSpeed * Time.fixedDeltaTime, Space.World);
		  	}
		  	if (Input.GetKey(KeyCode.S))
		  	{
		  	    transform.Translate(-Vector2.up * moveSpeed * Time.fixedDeltaTime, Space.World);
		  	}
		  	if (Input.GetKey(KeyCode.A))
		  	{
		  	    transform.Translate(-Vector2.right * moveSpeed * Time.fixedDeltaTime, Space.World);
		  	}
		  	if (Input.GetKey(KeyCode.D))
		  	{
		  	    transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime, Space.World);
		  	}
			LookAtMouse();
		} 	
    }

    void LookAtMouse()
    {
        Vector3 target = Input.mousePosition;
        target.z = -(transform.position.x - cam.transform.position.x);
        Vector3 player = cam.WorldToScreenPoint(transform.position);
        target.x = target.x - player.x;
        target.y = target.y - player.y;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
    }
}
