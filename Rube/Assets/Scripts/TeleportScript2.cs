using UnityEngine;
using System.Collections;

public class TeleportScript2 : MonoBehaviour {
	
	public Camera IsometricCamera;
	public GameObject TeleporterStart;
	public GameObject TeleporterEnd;
	public GameObject Player;
	
	public MouseClickCameraMove script;
	public AstarAI script2;
	
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.name == "Player") {
			Debug.Log ("Collided with player");
			if (IsometricCamera.enabled) {
				// Check if camera is in the right place
				if (script.GetCameraPosition () == 4) {
					Player.transform.position = TeleporterEnd.transform.position;
					script2.targetPosition = TeleporterEnd.transform.position;
				}
			}
		} else {
			Debug.Log("Did not collide with player");
		}
	}
}