// Written by Stuart McEwan - 1302856
// Steel Logic
// Rube
// Controls.cs

using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Controls")]

public class Controls : MonoBehaviour
{
	// Enum
	public enum CubeHit // Depth, Height, Width (Z, Y, X)
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
		BackBottomLeft, BackBottomCentre, BackBottomRight,

		NONE
	}

	// Public

	// Private
	private GameObject cubeSelected;	
	private RaycastHit hit;
	private Ray ray;
	private string hitTag, hitParentTag;
	private char faceHit;
	private Vector3 rotationVector;
	private float facePosition;

	private CubeHit cubeHit;

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
			if (Input.GetMouseButtonDown(0))
			{
				cubeHit = CubeHit.NONE;
				//ray = new Ray (transform.position, transform.forward);
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// Add third parameter "range" as a float to limit range of cast ray (Infinite range for now) - Stuart
				if (Physics.Raycast (ray, out hit))
				{
					// Debug.Log(hit.transform.gameObject.tag + " Hit");
					// Debug.Log("X: " + (hit.transform.position.x - hit.transform.parent.transform.position.x) + " Y: " + (hit.transform.position.y - hit.transform.parent.transform.position.y) + " Z: " + (hit.transform.position.z - hit.transform.parent.transform.position.z));

					// Logic to calculate which cube has been hit (Remove face hit logic once complete and working correctly) (Z, Y, X)
					// Z axis is negative towards the camera
					// Front(Z)
					if((hit.transform.position.z - hit.transform.parent.transform.position.z) >= -2.1 && (hit.transform.position.z - hit.transform.parent.transform.position.z) <= -1.9)		
					{
						// Top(Y)
						if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= 1.9 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= 2.1)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.FrontTopLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.FrontTopCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.FrontTopRight;
							}
						}
						// Centre(Y)
						else if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= -0.1 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= 0.1)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.FrontCentreLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.FrontCentreCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.FrontCentreRight;
							}
						}
						// Bottom(Y)
						else if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= -2.1 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= -1.9)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.FrontBottomLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.FrontBottomCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.FrontBottomRight;
							}
						}
					}
					// Centre(Z)
					else if((hit.transform.position.z - hit.transform.parent.transform.position.z) >= -0.1 && (hit.transform.position.z - hit.transform.parent.transform.position.z) <= 0.1)
					{
						// Top(Y)
						if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= 1.9 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= 2.1)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.CentreTopLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.CentreTopCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.CentreTopRight;
							}
						}
						// Centre(Y)
						else if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= -0.1 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= 0.1)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.CentreCentreLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.CentreCentreCentre;
								Debug.Log("You're not supposed to do this");
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.CentreCentreRight;
							}
						}
						// Bottom(Y)
						else if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= -2.1 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= -1.9)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.CentreBottomLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.CentreBottomCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.CentreBottomRight;
							}
						}
					}
					// Back(Z)
					else if((hit.transform.position.z - hit.transform.parent.transform.position.z) >= 1.9 && (hit.transform.position.z - hit.transform.parent.transform.position.z) <= 2.1)
					{
						// Top(Y)
						if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= 1.9 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= 2.1)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.BackTopLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.BackTopCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.BackTopRight;
							}
						}
						// Centre(Y)
						else if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= -0.1 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= 0.1)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.BackCentreLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.BackCentreCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.BackCentreRight;
							}
						}
						// Bottom(Y)
						else if((hit.transform.position.y - hit.transform.parent.transform.position.y) >= -2.1 && (hit.transform.position.y - hit.transform.parent.transform.position.y) <= -1.9)
						{
							// Left(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -2.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= -1.9)
							{
								cubeHit = CubeHit.BackBottomLeft;
							}
							// Centre(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= -0.1 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 0.1)
							{
								cubeHit = CubeHit.BackBottomCentre;
							}
							// Right(X)
							if((hit.transform.position.x - hit.transform.parent.transform.position.x) >= 1.9 && (hit.transform.position.x - hit.transform.parent.transform.position.x) <= 2.1)
							{
								cubeHit = CubeHit.BackBottomRight;
							}
						}
					}

					// Debug.Log("Cube Hit: " + cubeHit);


					// Remove this later - Stuart
					// Logic to calculate which face has been hit
					/*if((hit.transform.position.y - hit.transform.parent.transform.position.y == 0.0f) && (hit.transform.position.z - hit.transform.parent.transform.position.z == 0.0f))
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
					}*/
					// End Remove ^^

					// This may need fixed to accomodate new code written above - Stuart
					// Select cube here
					// If tag "Cube"
					if ((hit.transform.gameObject.tag == "Cube") || ((hit.transform.gameObject.tag == "Cube2")) || ((hit.transform.gameObject.tag == "Cube3")))
					{
						// Remove any hardcoded values or non dynamic script calling - Stuart
						// Debug.Log("Test parent hit " + hit.transform.gameObject.tag);
						hitTag = hit.transform.gameObject.tag;
						hitParentTag = hit.transform.root.gameObject.tag;				
						// this.GetComponentInParent<NewRotate>().RotateFace(rotationVector, facePosition, faceHit, hitTag, hitParentTag);
						// hit.collider.gameObject.GetComponent<SomeScript>().SomeFunction();
						// Call function which selects cube and have a second function called to rotate based on swipe direction
					}
				}
				else
				{
					Debug.Log("Miss");
					cubeHit = CubeHit.NONE;
				}
			}
		}
	}

	// Used to rotate the camera
	void RotateCamera()
	{
		// Do nothing
	}

	// Update is called once per frame
	void Update ()
	{
        TouchSelection();
	}

	// Getters
	public CubeHit GetCubeHit()
	{
		return cubeHit;
	}
	
	public string GetHitTag()
	{
		return hitTag;
	}

	public string GetHitParentTag()
	{
		return hitParentTag;
	}
}
