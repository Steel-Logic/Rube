using UnityEngine;
using System.Collections;

public class GoToLevel1 : MonoBehaviour {

	public GameObject LevelEnd;
	public GameObject Player;
	
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");
			Application.LoadLevel("Level 1");
		} else {
			Debug.Log("Did not collide with player");
		}
	}
}

