using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	public float width; 
	public float height; 

	void Start()
	{
        width = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width - 1f, 0, 0)).x;
        height = Camera.main.ScreenToWorldPoint(new Vector3 (0, Screen.height - 1f, 0)).y;
	}

}
