using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float x=0;
    float y=1;
    float r = 0;
    float xRotate = 0f;
    public SpriteRenderer myImage;
    public Texture2D texture;
    public Sprite[] redCar;
    // Use this for initialization
    void Start () {
        int i = 0;
        redCar = Resources.LoadAll<Sprite>(texture.name);
        //        Sprite[] redCar = Resources.LoadAll<Sprite>("carros/carros_");
        myImage.sprite = redCar[5];
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
            xRotate += Time.fixedDeltaTime;
            Debug.Log("Left key"+ Time.fixedTime+" AND "+ Time.fixedDeltaTime);
            r = Mathf.Cos(xRotate);
            Debug.Log(r);
        }
        if (Input.GetKey("right"))
        {
            xRotate += Time.fixedDeltaTime;
            if (xRotate >= 3)
                xRotate = 0;
            //Debug.Log();
            r = Mathf.Cos(xRotate);
            Debug.Log(r+" - "+((int)((r + 1) * 16))+ " AND " + Time.fixedDeltaTime+ " xRotate "+ xRotate);
            //r == 0;
            //ID = 0;
            //r == 0.5;
            //ID = 7;
            //r == 1;
            //ID == 15;
            //r == 2;
            //ID == 31;
            //(r + 1) * x = 15;
            //(r + 1) = 15 / x;
            //15 / (r + 1) = x;
            myImage.sprite = redCar[((int)((r + 1) * 16))];
   
        }

        if (Input.GetButton("Accelerate"))
            transform.position += new Vector3(x,y,0) * 0.01F;
        
        if (Input.GetButton("Turbo"))
            print("Turbo key");
        
	}
}
