using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class UIManager : MonoBehaviour {

	public Text ballCounter;
	public Text stopWatch;
    public Text bestScore;
	World world;

	void Start () {
		ballCounter.text = "" + 0;
		world = GameObject.Find ("GameManager").GetComponent<World> ();
	}
	

	void FixedUpdate () {
		CountBalls ();
	}

	void CountBalls(){
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Balls");
		
		setBallCounter (balls.Length);
	}

	public void setBallCounter(int count)
	{
		ballCounter.text = "" + count;
	}

	public void setStopWatch(int minutes, int secs)
	{
		stopWatch.text =  minutes + ":" + secs;
	}

    public void setBestScore(int score)
    {
        bestScore.text = score.ToString();
    }
}
