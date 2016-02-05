﻿using UnityEngine;
using System.Collections;

public class HasPlayerFinishedTeleport : MonoBehaviour {

	public GameObject TeleporterEnd;
	public GameObject Player;
	
	public bool PlayerFinishedTeleport;
	
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");
			PlayerFinishedTeleport = true;
		} 
	}
}

