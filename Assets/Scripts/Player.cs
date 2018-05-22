using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("up"))
            print("down arrow key is held down");
       
        if (Input.GetKey("down"))
            print("down arrow key is held down");

		if (Input.GetKey("left"))
            print("up arrow key is held down");
        
        if (Input.GetKey("right"))
            print("down arrow key is held down");

		if (Input.GetKey("accelerate"))
            transform.position += Vector3.up * 10.0F;
        
        if (Input.GetKey("turbo"))
            print("down arrow key is held down");
        
	}
}
