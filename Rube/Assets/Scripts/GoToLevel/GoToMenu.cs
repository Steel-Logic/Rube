using UnityEngine;
using System.Collections;

public class GoToMenu : MonoBehaviour {

	public GameObject LevelEnd;
	public GameObject Player;
	
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");
			Application.LoadLevel("Main Menu");
		} else {
			Debug.Log("Did not collide with player");
		}
	}
}
