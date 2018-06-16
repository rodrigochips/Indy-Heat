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
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
		My
    }
}
