using UnityEngine;
using System.Collections;

public class PlayerCameraFollowPlayer : MonoBehaviour {

	public GameObject player;
	public Camera isometricCamera;

	public float x;
	public float y;
	public float z;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = isometricCamera.transform.position + player.transform.position + new Vector3 (x, y, z);
	}
}
