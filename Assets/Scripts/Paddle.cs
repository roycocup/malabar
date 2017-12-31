using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Paddle : NetworkBehaviour {



	float mousePosXPrev = 0; 
	float mousePosXDiff = 0; 

	int[] XLimits = {-12, 12};


	void Start()
	{
		transform.position = new Vector3(0, -2f, 20);
	}


	void Update () 
	{
		if (!isLocalPlayer)
		{
			return;
		}

		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosXDiff = Mathf.Clamp (mousePosXPrev - mousePos.x, -1f, 1f);
		mousePosXPrev = mousePos.x;

		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;

		transform.position = new Vector3 (
			Mathf.Clamp (
				//transform.position.x - mousePosXDiff,
				mousePosXDiff,
				XLimits [0],
				XLimits [1]
			), -5);

	}
		
}
