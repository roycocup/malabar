using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	static public byte activeHand = 0;
    public GameObject ball;

	UIManager uiManager;
	float timeElapsed = 0; 
    float timeLeft = 60f * 10f;
    int maxScore = 0; 

	enum State {INIT, RUNNING, PAUSED, UNSTARTED, GAMEOVER};
	State state; 

	void Awake()
	{
		uiManager = GameObject.Find ("GameManager").GetComponent<UIManager> ();
        GameObject.Find("UI/InGameUI/Canvas/Panel").SetActive(false);
        GameObject.Find("UI/InGameUI/Canvas/Unstarted").SetActive(false);
        GameObject.Find("UI/InGameUI/Canvas/GameOver").SetActive(false);
	}

	void Start () {
        state = State.UNSTARTED;
		Cursor.visible = true;
	}
	

	void Update () {
		switch (state){

    		case State.UNSTARTED:
    			// show menu and start button
                GameObject.Find ("UI/InGameUI/Canvas/Unstarted").SetActive(true);
    			break;

    		case State.INIT:
                GameObject.Find("UI/InGameUI/Canvas/Panel").SetActive(true);
    			Cursor.visible = false;
    			SendBall ();
                RunClock();
    			state = State.RUNNING;
    			break;

    		case State.RUNNING:
    			RunClock ();
    			if (Input.anyKeyDown) {
    				ManageKeyPresses ();
    			}
    			break;

    		case State.PAUSED:
    			break;

    		case State.GAMEOVER:
                GameObject.Find("UI/InGameUI/Canvas/Unstarted").SetActive(false);
                GameObject.Find("UI/InGameUI/Canvas/GameOver").SetActive(true);
                uiManager.setBestScore(maxScore);
    			break;

		}
	}

	public void StartGame(){
		GameObject ui = GameObject.Find ("UI/InGameUI/Canvas/Unstarted");
		ui.SetActive(false);
		state = State.INIT;
	}

		
	void RunClock(){
		timeElapsed += Time.deltaTime;

		if (timeElapsed >= 1f) 
		{
			timeLeft--;

			int minutes = (int) (timeLeft / 60);
			string seconds = (timeLeft - (minutes * 60)).ToString();


			if (seconds.Length < 2) {
				seconds = "0" + seconds;
			}

            uiManager.setStopWatch (minutes, int.Parse(seconds));

			timeElapsed = 0;
		}
	}
	void StopClock(){
		
	}

	void ManageKeyPresses(){
		// switch hand control
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(1)) {
			if (GM.activeHand == 0)
				GM.activeHand = 1;
			else
				GM.activeHand = 0;
		}

		if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0)) {
            SendBall();
        }
	}

    void SendBall(){
		GameObject clone = Instantiate(ball, new Vector3(5, 10, 0), Quaternion.identity, GameObject.Find ("Balls").transform) as GameObject;
		clone.tag = "Balls";
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
        if (balls.Length > maxScore)
            maxScore = balls.Length;
    }


}
