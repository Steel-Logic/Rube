using UnityEngine;
using System.Collections;

public class PlayerMoveBetweenTeleports : MonoBehaviour {

	public GameObject TeleporterStart;
	public GameObject TeleporterEnd;
	public GameObject Player;
	
	public Camera IsometricCameraSeePlayer;
	
	public TeleportScript script;
	public HasPlayerFinishedTeleport script2;
	public AstarAI script3;
	
	public int TeleportFrames;
	
	private bool PlayerStartedMoving;
	
	public Vector3 distancePerFrame;

	// Use this for initialization
	void Start () {
		PlayerStartedMoving = false;
		
	}
	
	// Update is called once per frame
	void Update () {	
		if (script.PlayerMoving == true) {
			if (PlayerStartedMoving == false) {
				
				IsometricCameraSeePlayer.enabled = true;

				Vector3 distance = new Vector3(
				TeleporterStart.transform.position.x - TeleporterEnd.transform.position.x,
				TeleporterStart.transform.position.y - TeleporterEnd.transform.position.y,
				TeleporterStart.transform.position.z - TeleporterEnd.transform.position.z);
				
				distancePerFrame = new Vector3(
				distance.x / TeleportFrames,
				distance.y / TeleportFrames,
				distance.z / TeleportFrames);
			
				PlayerStartedMoving = true;
				script2.PlayerFinishedTeleport = false;
			
			}
			
			if (PlayerStartedMoving == true) {
				Player.transform.position = Player.transform.position - distancePerFrame;
				if (script2.PlayerFinishedTeleport == true) {
					script3.targetPosition = TeleporterEnd.transform.position;
					PlayerStartedMoving = false;
					script.PlayerMoving = false;
					IsometricCameraSeePlayer.enabled = false;;
				}
			}
		}
	}
}
