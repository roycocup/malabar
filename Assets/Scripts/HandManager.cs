using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour {

	public Transform leftHand; 
	public Transform rightHand;
	public Transform indicator;
    public bool active = false; 

	float mousePosXPrev = 0; 
	float mousePosXDiff = 0; 

	int[] rightHandXLimits = {1, 12};
	int[] leftHandXLimits = {-12, -1};

	

	void Update () {
        if (active == false)
            return; 
        
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosXDiff = Mathf.Clamp (mousePosXPrev - mousePos.x, -1f, 1f);
		mousePosXPrev = mousePos.x;

		if (GM.activeHand == 1) {
			indicator.position = new Vector3(6, indicator.position.y);
			rightHand.transform.position = new Vector3 (
				Mathf.Clamp (
					rightHand.transform.position.x - mousePosXDiff, 
					rightHandXLimits [0], 
					rightHandXLimits [1]
				), rightHand.position.y);
		} else {
			indicator.position = new Vector3(-6, indicator.position.y);
			leftHand.transform.position = new Vector3 (
				Mathf.Clamp (
					leftHand.transform.position.x - mousePosXDiff, 
					leftHandXLimits[0], 
					leftHandXLimits[1]
				), leftHand.position.y
			);
		}


	}
		


}
