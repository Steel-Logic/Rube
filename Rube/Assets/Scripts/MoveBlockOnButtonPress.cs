using UnityEngine;
using System.Collections;

public class MoveBlockOnButtonPress : MonoBehaviour {

	public float targetX;
	public float targetY;
	public float targetZ;

	public float startX;
	public float startY;
	public float startZ;

	Vector3 target;
	Vector3 start;

	public ButtonPressCheck check;

	// Use this for initialization
	void Start () {
		target.x = targetX;
		target.y = targetY;
		target.z = targetZ;

		start.x = startX;
		start.y = startY;
		start.z = startZ;

		this.transform.position = start;

	}
	
	// Update is called once per frame
	void Update () {
		if (check.pressed == true) {
			this.transform.position = target;
		}
	}
}
