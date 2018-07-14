﻿using UnityEngine;
using System.Collections;

    using System.Collections.Generic;       //Allows us to use Lists. 
    
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        private int level = 3;
		int iLapCount1 = 0;
		int iLapCount2 = 0;
		int iLapCount3 = 0;
		int iLapCount4 = 0;
		int iLapCount5 = 0;
		bool canCountLap1 = false;
		bool canCountLap2 = false;
		bool canCountLap3 = false;
		bool canCountLap4 = false;
		bool canCountLap5 = false;
		float ftimer1 = 0;
		float ftimer2 = 0;
		float ftimer3 = 0;
		float ftimer4 = 0;
		float ftimer5 = 0;

		                               //LapCounter

        //Awake is always called before any Start functions
        void Awake()
        {
            //Check if instance already exists
            if (instance == null)
                
                //if not, set instance to this
                instance = this;
            
            //If instance already exists and it's not this:
            else if (instance != this)
                
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);    
            
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
            
            //Get a component reference to the attached BoardManager script
//            boardScript = GetComponent<BoardManager>();
            
            //Call the InitGame function to initialize the first level 
            InitGame();
        }
        
        //Initializes the game for each level.
        void InitGame()
        {
            //Call the SetupScene function of the BoardManager script, pass it current level number.
//            boardScript.SetupScene(level);
            
        }
        
        
        
        //Update is called every frame.
        void Update()
        {
            
        }

		public void PlayerFinished(GameObject goCollider)
		{
	        Debug.Log("PlayerFinished: "+goCollider.name + " : " + gameObject.name + " : " + Time.time);
			switch(goCollider.name)
			{
				case "carros_1":
					if(canCountLap1 && ftimer1 < Time.time){
						iLapCount1 ++;
						canCountLap1=false;
						ftimer1 = Time.time+0.1f;
					}
				break;
				case "carros_2":
					if(canCountLap2&& ftimer2 < Time.time)
					{
						iLapCount2 ++;
						canCountLap2=false;
						ftimer2 = Time.time+0.1f;
					}
				break;
				case "carros_3":
					if(canCountLap3 && ftimer3 < Time.time)
					{
						iLapCount3 ++;
						canCountLap3=false;
						ftimer3 = Time.time+0.1f;
					}
				break;
				case "carros_4":
					if(canCountLap4 && ftimer4 < Time.time)
					{
						iLapCount4 ++;
						canCountLap4=false;
						ftimer4 = Time.time+0.1f;
					}
				break;
				case "carros_5":
					if(canCountLap5)
					{
						iLapCount5 ++;
						canCountLap5=false;
						ftimer5 = Time.time+0.1f;
					}
				break;
				default:
					Debug.Log("Carro: "+goCollider.name);
				break;
			}
		}

		public void PlayerStarted(GameObject goCollider)
		{
	        Debug.Log("PlayerStarted: "+goCollider.name + " : " + gameObject.name + " : " + Time.time);
			switch(goCollider.name)
			{
				case "carros_1":
					canCountLap1=true;
				break;
				case "carros_2":
					canCountLap2=true;
				break;
				case "carros_3":
					canCountLap3=true;
				break;
				case "carros_4":
					canCountLap4=true;
				break;
				case "carros_5":
					canCountLap5=true;
				break;
				default:
					Debug.Log("Carro: "+goCollider.name);
				break;
			}
		}


	}