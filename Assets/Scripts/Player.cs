using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float x=0;
    float y=0;
    float r = 0;
    public float xRotate = 0f;
    public SpriteRenderer myImage;
    public Texture2D texture;
    public Sprite[] redCar;
    // Use this for initialization
    void Start () {
        int i = 0;
        redCar = Resources.LoadAll<Sprite>(texture.name);
        //        Sprite[] redCar = Resources.LoadAll<Sprite>("carros/carros_");
        myImage.sprite = redCar[0];
        x = -1;
    }
	
	// Update is called once per frame
	void Update () {
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
            xRotate -= Time.fixedDeltaTime * 25;
            if (xRotate <= 0)
                xRotate = 359;
            Debug.Log("Left key"+ Time.fixedTime+" AND "+ Time.fixedDeltaTime);
            x = Mathf.Cos(xRotate);
            y = Mathf.Sin(xRotate);
            myImage.sprite = redCar[(int)(xRotate / 11.2f)];
        }
        if (Input.GetKey("right"))
        {
            xRotate += Time.fixedDeltaTime * 25;
            if (xRotate >= 359)
                xRotate = 0;
            x = Mathf.Cos(xRotate);
            y = Mathf.Sin(xRotate);
            Debug.Log("Angle: " + xRotate + " X:" + x + " , Y:" + y);
            myImage.sprite = redCar[(int)(xRotate/11.2f)];
        }

        if (Input.GetButton("Accelerate"))
        {
            transform.position += new Vector3(x, y, 0) * 0.01F;
            Debug.Log("Angle: "+xRotate+" ID: " + (int)(xRotate / 32) + " X:"+x+" , Y:"+y);
        }
        
        if (Input.GetButton("Turbo"))
            print("Turbo key");
        
	}
}
