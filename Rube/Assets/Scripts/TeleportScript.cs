using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {

	public Camera IsometricCamera;
	public GameObject TeleporterStart;
	public GameObject TeleporterEnd;
	public GameObject Player;
	public Camera IsometricCameraPlayer;
	public AudioSource audio;
	
	public NewRotate script;
	public HasPlayerFinishedTeleport script2;
	public AIPath script3;

	public bool PlayerMoving;
		
	public int WantedCameraPosition;
	
	void OnTriggerStay (Collider col)
	{
	//if (PlayerMoving == false) {
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");

				// Check if camera is in the right place
				if (script.GetCameraPosition() == WantedCameraPosition) {
					PlayerMoving = true;
					script2.PlayerFinishedTeleport = false;
					script3.enabled = false;
					audio.Play();
				}

		} else {
			Debug.Log("Did not collide with player");
		}
	}
}
