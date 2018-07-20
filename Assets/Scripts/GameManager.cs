using UnityEngine;
using System.Collections;

    using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        private int level = 3;
		int iLapCount1 = 0;
		int iLapCount2 = 4;
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
		public Text iGUILapCounter1 ;
		public Text iGUILapCounter2 ;
		public Text iGUILapCounter3 ;
		public Text iGUILapCounter4 ;
		public Text iGUILapCounter5 ;

		public Text iGUIGameTimer;
		float fTimer = 0;
		bool bGameOver = false;

		public GameObject Winner;
		
		

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
		
	public void Restart()
	{
		SceneManager.LoadScene("boot");	
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
			if (!bGameOver)
				fTimer += Time.deltaTime;
			iGUIGameTimer.text = fTimer.ToString("F1");
			if(iLapCount1 == 5 || iLapCount2 == 5 || iLapCount3 == 5|| iLapCount4 == 5 || iLapCount5 == 5)
			{
				bGameOver = true;
				BroadcastMessage ("RaceOver");
				Winner.active = true;
			}
        }

		public void PlayerFinished(GameObject goCollider)
		{
			Debug.Log("PlayerFinished: "+goCollider.name + " : " + gameObject.name + " : " + Time.time+ " -> "+ftimer2+" ?? "+canCountLap2);
			switch(goCollider.name)
			{
				case "carros_1_yellow":
					if(canCountLap1 && ftimer1 < Time.time){
						iLapCount1 ++;
						canCountLap1=false;
						ftimer1 = Time.time+10.1f;
						if(iLapCount1 != 1)
							iGUILapCounter1.text = iLapCount1.ToString();
					}
				break;
		case "carros_2_red":
			Debug.Log("VAI CARRO 2: "+goCollider.name + " : " + canCountLap2 + " : "+ ftimer2 +" - " + Time.time);
					if(canCountLap2&& ftimer2 < Time.time)
					{
						iLapCount2 ++;
						canCountLap2=false;
						ftimer2 = Time.time+5.1f;
						if(iLapCount2 != 1)
							iGUILapCounter2.text = iLapCount2.ToString();
					}
				break;
		case "carros_3_blue":
					if(canCountLap3 && ftimer3 < Time.time)
					{
						iLapCount3 ++;
						canCountLap3=false;
						ftimer3 = Time.time+5.1f;
						if(iLapCount3 != 1)
							iGUILapCounter3.text = iLapCount3.ToString();
								
					}
				break;
		case "carros_4_green":
					if(canCountLap4 && ftimer4 < Time.time)
					{
						iLapCount4 ++;
						canCountLap4=false;
						ftimer4 = Time.time+10.1f;
						if(iLapCount4 != 1)
							iGUILapCounter4.text = iLapCount4.ToString();
					}
				break;
		case "carros_5_gray":
					if(canCountLap5 && ftimer5 < Time.time)
					{
						iLapCount5 ++;
						canCountLap5=false;
						ftimer5 = Time.time+10.1f;
						if(iLapCount5 != 1)
							iGUILapCounter5.text = iLapCount5.ToString();
					}
				break;
			}
		}

		public void PlayerStarted(GameObject goCollider)
		{
	        Debug.Log("PlayerStarted: "+goCollider.name + " : " + gameObject.name + " : " + Time.time);
			switch(goCollider.name)
			{
		case "carros_1_yellow":
					canCountLap1=true;
				break;
		case "carros_2_red":
					canCountLap2=true;
				break;
		case "carros_3_blue":
					canCountLap3=true;
				break;
		case "carros_4_green":
					canCountLap4=true;
				break;
		case "carros_5_gray":
					canCountLap5=true;
				break;
				default:
					Debug.Log("Carro: "+goCollider.name);
				break;
			}
		}


	}