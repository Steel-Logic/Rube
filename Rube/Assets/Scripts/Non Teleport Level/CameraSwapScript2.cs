using UnityEngine;
using System.Collections;

public class CameraSwapScript2 : MonoBehaviour {
	
	public Camera isometricCamera;
	public Camera playerCamera;

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
			isometricCamera.enabled = !isometricCamera.enabled;
			playerCamera.enabled = !playerCamera.enabled;
		}
	}
}