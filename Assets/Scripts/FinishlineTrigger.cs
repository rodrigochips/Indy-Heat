using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishlineTrigger : MonoBehaviour {
	
	public GameObject myGameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if(gameObject.name == "Finish");
			myGameManager.SendMessage("PlayerFinished",col.gameObject);
		if(gameObject.name == "Start");
			myGameManager.SendMessage("PlayerStarted",col.gameObject);
    }
}
