using UnityEngine;
using System.Collections;

public class PlayerCameraFollowPlayer2 : MonoBehaviour {

	public GameObject player;
	public Camera isometricCamera;
	
	public MouseClickCameraMove2 script;
	
	public float x;
	public float y;
	public float z;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (script.cameraPosition == 1) {
			this.transform.position = isometricCamera.transform.position + player.transform.position + new Vector3 (x, y - 6, z);
		}
		if (script.cameraPosition == 2) {
			this.transform.position = isometricCamera.transform.position + player.transform.position + new Vector3 (x + 9, y + 6, z);
		}
		if (script.cameraPosition == 3) {
			this.transform.position = isometricCamera.transform.position + player.transform.position + new Vector3 (x, y + 6, z);
		}
		if (script.cameraPosition == 4) {
			this.transform.position = isometricCamera.transform.position + player.transform.position + new Vector3 (x + 6, y - 6, z);
		}
	}
}
