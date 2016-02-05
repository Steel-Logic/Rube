using UnityEngine;
using System.Collections;

public class ButtonPressCheck : MonoBehaviour {

	// Use this for initialization
	public bool pressed = false;

	public GameObject Button;
	public GameObject Player;
	
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collided with player");
			pressed = true;
		} else {
			Debug.Log("Did not collide with player");
		}
	}
}

