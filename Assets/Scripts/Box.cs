using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public GameObject goBoxRed;
	public GameObject goBoxYellow;
	public GameObject goBoxGreen;
	public GameObject goBoxBlue;
	public GameObject goBoxGray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// when the GameObjects collider arrange for this GameObject to travel to the left of the screen
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Contains ("carro")) {
			Debug.Log (col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
			if(col.gameObject.name.Contains ("yellow"))
				col.gameObject.SendMessage ("BoxStart",goBoxYellow.transform.position);
			
			if(col.gameObject.name.Contains ("red"))
				col.gameObject.SendMessage ("BoxStart",goBoxRed.transform.position);
			
			if(col.gameObject.name.Contains ("green"))
				col.gameObject.SendMessage ("BoxStart",goBoxGreen.transform.position);
			
			if(col.gameObject.name.Contains ("blue"))
				col.gameObject.SendMessage ("BoxStart",goBoxBlue.transform.position);
			
			if(col.gameObject.name.Contains ("gray"))
				col.gameObject.SendMessage ("BoxStart",goBoxGray.transform.position);
		}
	}
}

