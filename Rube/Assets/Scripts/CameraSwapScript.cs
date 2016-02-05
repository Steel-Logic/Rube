using UnityEngine;
using System.Collections;



public class CameraSwapScript : MonoBehaviour {
	
	public Camera isometricCamera;
	public Camera playerCamera;

	public MouseClickCameraMove script3;
	public HasPlayerFinishedTeleport script;
	public HasPlayerFinishedTeleport script2;

	// Use this for initialization
	void Start () {
		playerCamera = GameObject.FindGameObjectWithTag ("PlayerCamera").GetComponent<Camera>();
		isometricCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();

		isometricCamera.enabled = true;
		playerCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			if ((script.PlayerFinishedTeleport == true)&&(script2.PlayerFinishedTeleport == true)) { 
				if (script3.startTurning == false) {
				isometricCamera.enabled = !isometricCamera.enabled;
				playerCamera.enabled = !playerCamera.enabled;
				}
			}
		}
	}
}