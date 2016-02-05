using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour {

	int wanted_X_Rotation = 0;
	int wanted_Y_Rotation = 0;
	int current_X_Rotation = 0;
	int current_Y_Rotation = 0;
	bool turning = false;
	
	// larger numbers = slower turn speed
	int turning_speed = 15;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (turning == false) {
			if (Input.GetKeyDown (KeyCode.C)) {
				wanted_X_Rotation -= 90;
				turning = true;

				}
			if (Input.GetKeyDown (KeyCode.V)) {
				wanted_X_Rotation += 90;
				turning = true;

			}
		}
		if (current_X_Rotation == wanted_X_Rotation) {
		wanted_X_Rotation = 0;
		current_X_Rotation = 0;
		turning = false;
		} else {
		transform.Rotate(wanted_Y_Rotation, wanted_X_Rotation / turning_speed, 0);
		current_X_Rotation += wanted_X_Rotation / turning_speed;
		}
		
		wanted_Y_Rotation = 0;
		
	}
}
