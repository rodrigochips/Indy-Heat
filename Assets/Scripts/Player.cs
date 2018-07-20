using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

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
	public int CarID = 1;

	bool bPitstop = false;
	bool bRaceOver = false;
	Vector3 v3Pit;
	float fBoxTime = 0f;
	float fSafeBoxTimer = 0f;
	public float fSpeed = 0.001F;

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
//		LeftEye.transform.position = new Vector3(x*0.15f, y*0.15f , LeftEye.transform.position.z );
//		RightEye.transform.position = new Vector3(x*0.15f, y*0.15f, RightEye.transform.position.z );
    }
	
	// Update is called once per frame
	void Update () {

		if(!bRaceOver)
		if (!bPitstop) {
			if (Input.GetKey ("up")) {
				print ("Up key");
			}

			if (Input.GetKey ("down")) {
				print ("Down key");
			}
			if (Input.GetKey ("left")) {
				TurnLeft ();
			}
			if (Input.GetKey ("right")) {
				TurnRight ();
			}

			if (Input.GetButton ("Accelerate")) {
				transform.position += new Vector3 (x, y, 0) * fSpeed;
			}
	        
			if (Input.GetButton ("Turbo")) {
				if (Time.time > fTurboTimer) {
					StartCoroutine (UseTurbo (fTurboBoost));
					fTurboTimer = Time.time + 1f;
				}
			}
		} else {
			transform.position = Vector3.Lerp(transform.position, new Vector3(v3Pit.x, v3Pit.y, 0f), 0.05f);
			TurnTo (180f);
			GetComponent<BoxCollider2D> ().enabled = false;
			fBoxTime += Time.deltaTime;
			if (fBoxTime >= 3f) {
				GetComponent<BoxCollider2D> ().enabled = true;
				bPitstop = false;
			}
		}
	}

	public void RaceOver()
	{
		Debug.Log ("RaceOver");
		bRaceOver = true;
	}
	public void TurnRight()
	{
		xRotate += Time.fixedDeltaTime * rotationSpeed;
		if (xRotate > 359.9f)
			xRotate = 0;
		x = Mathf.Cos((xRotate * Mathf.PI)/180)*-1;
		y = Mathf.Sin((xRotate * Mathf.PI)/180);
		myImage.sprite = redCar[(int)(xRotate / 11.25f)+(CarID*32)];
		//Debug.Log("Angle: "+xRotate+" ID: " + (int)(xRotate / 32) + " X:"+x+" , Y:"+y);

	} 

	public void TurnTo(float r)
	{
		xRotate = r;
		if (xRotate > 359.9f)
			xRotate = 0;
		x = Mathf.Cos((xRotate * Mathf.PI)/180)*-1;
		y = Mathf.Sin((xRotate * Mathf.PI)/180);
		myImage.sprite = redCar[(int)(xRotate / 11.25f)+(CarID*32)];
		//Debug.Log("Angle: "+xRotate+" ID: " + (int)(xRotate / 32) + " X:"+x+" , Y:"+y);

	} 

	public void TurnLeft()
	{
            xRotate -= Time.fixedDeltaTime * rotationSpeed;
            if (xRotate < 0)
                xRotate = 359.9f;
            x = Mathf.Cos((xRotate * Mathf.PI)/180)*-1;
            y = Mathf.Sin((xRotate * Mathf.PI)/180);
			myImage.sprite = redCar[(int)(xRotate / 11.25f)+(CarID*32)];
	}

	public void BoxStart(Vector3 position)
	{
		if (fSafeBoxTimer < Time.time) {
			v3Pit = position;
			bPitstop = true;
			fSafeBoxTimer = Time.time + 3f;
		}
	}

	IEnumerator UseTurbo(float loops)
	{
		for(int i = 0; i < loops; i++){
			transform.position += new Vector3(x, y, 0) * 0.01F;
			yield return new WaitForSeconds(0);
		}
	}
}
