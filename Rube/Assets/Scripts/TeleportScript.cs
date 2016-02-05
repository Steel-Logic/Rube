using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {

	public Camera IsometricCamera;
	public GameObject TeleporterStart;
	public GameObject TeleporterEnd;
	public GameObject Player;
	public Camera IsometricCameraPlayer;
	
	public MouseClickCameraMove script;
	public HasPlayerFinishedTeleport script2;

	public bool PlayerMoving;
		
	public int WantedCameraPosition;
	
	void OnTriggerStay (Collider col)
	{
	//if (PlayerMoving == false) {
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");
			if (IsometricCamera.enabled) {
				// Check if camera is in the right place
				if (script.GetCameraPosition() == WantedCameraPosition) {
					PlayerMoving = true;
					script2.PlayerFinishedTeleport = false;
				}
			}
		} else {
			Debug.Log("Did not collide with player");
		}
	}
}
