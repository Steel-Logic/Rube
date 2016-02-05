using UnityEngine;
using System.Collections;

public class GoToLevel3 : MonoBehaviour {
	
	public GameObject LevelEnd;
	public GameObject Player;
	
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");
			Application.LoadLevel("FinalLevel");
		} else {
			Debug.Log("Did not collide with player");
		}
	}
}