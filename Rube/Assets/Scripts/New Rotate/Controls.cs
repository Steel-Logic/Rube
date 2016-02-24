﻿// Written by Stuart McEwan - 1302856
// Steel Logic
// Rube
// Controls.cs

using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	// Public

	// Private
	private GameObject cubeSelected;	
	private RaycastHit hit;
	private Ray ray;
	private string hitTag, hitParentTag;
	private char faceHit;
	private Vector3 rotationVector;
	private float facePosition;

	// Enum
	enum CubeHit // Depth, Height, Width (Z, Y, X)
	{
		// Front Slice
		FrontTopLeft, FrontTopCentre, FrontTopRight,
		FrontCentreLeft, FrontCentreCentre, FrontCentreRight,
		FrontBottomLeft, FrontBottomCentre, FrontBottomRight,

		// Centre Slice
		CentreTopLeft, CentreTopCentre, CentreTopRight,
		CentreCentreLeft, CentreCentreCentre, CentreCentreRight,
		CentreBottomLeft, CentreBottomCentre, CentreBottomRight,

		// Back Slice
		BackTopLeft, BackTopCentre, BackTopRight,
		BackCentreLeft, BackCentreCentre, BackCentreRight,
		BackBottomLeft, BackBottomCentre, BackBottomRight
	}

	// Methods
	// Use this for initialization
	void Start ()
	{

	}

	// Used to select cubes in the scene
	void TouchSelection()
	{
		if (this.GetComponentInParent<NewRotate>().isRotating == false)
		{
			// Currently right click, change to left click once control modes are created - Stuart
			if (Input.GetMouseButtonDown(1))
			{
				//ray = new Ray (transform.position, transform.forward);
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// Add third parameter "range" as a float to limit range of cast ray (Infinite range for now) - Stuart
				if (Physics.Raycast (ray, out hit))
				{
					//Debug.Log(hit.transform.gameObject.tag + " Hit");
					Debug.Log("X: " + (hit.transform.position.x - hit.transform.parent.transform.position.x) + " Y: " + (hit.transform.position.y - hit.transform.parent.transform.position.y) + " Z: " + (hit.transform.position.z - hit.transform.parent.transform.position.z));

					// Logic to calculate which face has been hit
					if((hit.transform.position.y - hit.transform.parent.transform.position.y == 0.0f) && (hit.transform.position.z - hit.transform.parent.transform.position.z == 0.0f))
					{
						faceHit = 'x';
						Debug.Log ("X");
						rotationVector = Vector3.right;

								if(hit.transform.position.x - hit.transform.parent.transform.position.x > 0){facePosition = 1.0f;}
						else 	if(hit.transform.position.x - hit.transform.parent.transform.position.x < 0){facePosition = -1.0f;}
					}
					else if((hit.transform.position.x - hit.transform.parent.transform.position.x == 0.0f) && (hit.transform.position.z - hit.transform.parent.transform.position.z == 0.0f))
					{
						faceHit = 'y';
						Debug.Log ("Y");
						rotationVector = Vector3.up;

								if(hit.transform.position.y - hit.transform.parent.transform.position.y > 0){facePosition = 1.0f;}
						else 	if(hit.transform.position.y - hit.transform.parent.transform.position.y < 0){facePosition = -1.0f;}
					}
					else if((hit.transform.position.x - hit.transform.parent.transform.position.x == 0.0f) && (hit.transform.position.y - hit.transform.parent.transform.position.y == 0.0f))
					{
						faceHit = 'z';
						Debug.Log ("Z");
						rotationVector = Vector3.forward;

								if(hit.transform.position.z - hit.transform.parent.transform.position.z > 0){facePosition = 1.0f;}
						else 	if(hit.transform.position.z - hit.transform.parent.transform.position.z < 0){facePosition = -1.0f;}
					}
					else
					{
						//return;
					}

					// Select cube here
					// If tag "Cube"
					if ((hit.transform.gameObject.tag == "Cube") || ((hit.transform.gameObject.tag == "Cube2")) || ((hit.transform.gameObject.tag == "Cube3")))
					{
						// Remove any hardcoded values or non dynamic script calling - Stuart
					   
						hitTag = hit.transform.gameObject.tag;
						hitParentTag = hit.transform.root.gameObject.tag;				
						this.GetComponentInParent<NewRotate>().RotateFace(rotationVector, facePosition, faceHit, hitTag, hitParentTag);
						// hit.collider.gameObject.GetComponent<SomeScript>().SomeFunction();
						// Call function which selects cube and have a second function called to rotate based on swipe direction
					}
				}
				else
				{
					Debug.Log("Miss");
				}
			}
		}
	}

	// Used to rotate the camera
	void RotateCamera()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
        TouchSelection();
	}


}
