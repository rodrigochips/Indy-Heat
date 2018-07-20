using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Player : MonoBehaviour {

    float x=0;
    float y=0;
    float r = 0;
    public float xRotate = 0f;
	public float rotationSpeed = 50f;
    public SpriteRenderer myImage;
    public Texture2D texture;
    public Sprite[] redCar;
	float fTurboTimer = 0;
	float fTurboBoost = 10;
	public GameObject LeftEye;
	public GameObject RightEye;
	public GameObject waypoints;
	public Vector3[] V3waypoins;
	int waypointCounter = 0;
	public int CarID = 1;
	bool bRaceOver = false;


    // Use this for initialization
    void Start () {
		int i = 0;
		redCar = Resources.LoadAll<Sprite>(texture.name);
		x = -1;
		xRotate = 180;
		x = Mathf.Cos((xRotate * Mathf.PI)/180)*-1;
		y = Mathf.Sin((xRotate * Mathf.PI)/180);
		myImage.sprite = redCar[(int)(xRotate / 11.25f)+(CarID*32)];

		Debug.Log("MyPos: "+transform.position+" X: "+x+", Y: "+y);

		int size = waypoints.transform.childCount;
		V3waypoins = new Vector3[size];
		waypointCounter = 0;
		foreach (Transform trans in waypoints.transform) {
			V3waypoins [waypointCounter] = trans.position;
			waypointCounter++;
		}
		waypointCounter = 0;
			
    }
	
	// Update is called once per frame
	void Update () {
	/*	
		if (Input.GetKey("up"))
        {
            print("Up key");
        }

        if (Input.GetKey("down"))
        {
            print("Down key");
        }
        if (Input.GetKey("left"))
        {
            xRotate -= Time.fixedDeltaTime * rotationSpeed;
            if (xRotate < 0)
                xRotate = 359.9f;
            x = Mathf.Cos((xRotate * Mathf.PI)/180)*-1;
            y = Mathf.Sin((xRotate * Mathf.PI)/180);
            myImage.sprite = redCar[(int)(xRotate / 11.25f)];
            Debug.Log("Angle: "+xRotate+" ID: " + (int)(xRotate / 32) + " X:"+x+" , Y:"+y);
        }
        if (Input.GetKey("right"))
        {
            xRotate += Time.fixedDeltaTime * rotationSpeed;
            if (xRotate > 359.9f)
                xRotate = 0;
            x = Mathf.Cos((xRotate * Mathf.PI)/180)*-1;
            y = Mathf.Sin((xRotate * Mathf.PI)/180);
            myImage.sprite = redCar[(int)(xRotate / 11.25f)];
            Debug.Log("Angle: "+xRotate+" ID: " + (int)(xRotate / 32) + " X:"+x+" , Y:"+y);
        }

		transform.position += new Vector3(x, y, 0) * 0.01F;
        
        if (Input.GetButton("Turbo"))
        {
			if(Time.time > fTurboTimer)
			{
				StartCoroutine(UseTurbo(fTurboBoost));
				fTurboTimer = Time.time + 1f;
			}
        }*/

		if (!bRaceOver) {
			transform.LookAt (V3waypoins [waypointCounter]);
			transform.position += new Vector3 (x, y, 0) * 0.01F;
			//Debug.Log (Vector2.Distance (new Vector2(V3waypoins [waypointCounter].x, V3waypoins [waypointCounter].y) , new Vector2(transform.position.x, transform.position.y))+" - "+waypointCounter);
			if (Vector3.Distance (V3waypoins [waypointCounter], transform.position) < 0.01f)
				waypointCounter++;
		}
	}


	public void RaceOver()
	{
		Debug.Log ("RaceOver");
		bRaceOver = true;
	}


	IEnumerator UseTurbo(float loops)
	{
		for(int i = 0; i < loops; i++){
			transform.position += new Vector3(x, y, 0) * 0.01F;
			yield return new WaitForSeconds(0);
		}
	}
}
