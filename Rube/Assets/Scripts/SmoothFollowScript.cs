using UnityEngine;
using System.Collections;

    public class SmoothFollowScript : MonoBehaviour {
    public Transform target;
    public float distance = 3.0f;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public bool followBehind = true;
    public float rotationDamping = 10.0f;

	private Vector3 WorldUpVector = new Vector3(0, 1, 0);

	void Start() {

	}

    void Update () {
        Vector3 wantedPosition;

		if (Input.GetKeyDown ("p")) {
			target.transform.RotateAround(target.transform.position, WorldUpVector, 90);
		}

		// work out which direction player is facing
		if ((target.transform.rotation.y >= 0) && (target.transform.rotation.y < 90)) {
			wantedPosition = target.TransformPoint (-distance, distance, -distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		} else if ((target.transform.rotation.y >= 90) && (target.transform.rotation.y < 180)) {
			wantedPosition = target.TransformPoint (-distance, distance, distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		} else if ((target.transform.rotation.y >= 180) && (target.transform.rotation.y < 270)) {
			wantedPosition = target.TransformPoint (distance, distance, distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		} else if ((target.transform.rotation.y >= 270) && (target.transform.rotation.y < 360)) {
			wantedPosition = target.TransformPoint (distance, distance, -distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		}

            if (smoothRotation) {
                    Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, WorldUpVector);
                    transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
					
					transform.LookAt (target, WorldUpVector);
            }
            else transform.LookAt (target, WorldUpVector);

        }
}