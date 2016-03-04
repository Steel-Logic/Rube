using UnityEngine;
using System.Collections;

public class LevelFinished : MonoBehaviour {

	public GameObject LevelEnd;
	public GameObject Player;
	
	public ScreenFader script;
	
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");
			script.sceneEnding = true;
		} else {
			Debug.Log("Did not collide with player");
		}
	}
}
