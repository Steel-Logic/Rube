using UnityEngine;
using System.Collections;

public class DeathPlaneCheck : MonoBehaviour {

	public int DeathPlane;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < DeathPlane) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
