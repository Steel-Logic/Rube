using UnityEngine;
using System.Collections;

public class ConstantRotate : MonoBehaviour {

	public float xRotate;
	public float yRotate;
	public float zRotate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (xRotate, yRotate, zRotate);
	}
}
