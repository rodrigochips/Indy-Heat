using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveVision : MonoBehaviour {

	public bool bAmIRight = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collider")
        {
			if(bAmIRight)
				SendMessageUpwards("TurnRight");
			else
				SendMessageUpwards("TurnLeft");
            Debug.Log("OnTriggerEnter2D");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("OnTriggerStay2D "+gameObject.name+" - "+other.gameObject.name);
        if (other.tag == "Collider")
		{
			if(bAmIRight)
				SendMessageUpwards("TurnRight");
			else
				SendMessageUpwards("TurnLeft");
		}
    }
}
