// Written by Stuart McEwan - 1302856
// Steel Logic
// Rube
// Rotate.cs

using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Rotate")]

public class NewRotate : MonoBehaviour
{	
	// Enum

	// Public
	public bool isRotating;
	public float rotationSpeed;
	
	// Private
	private GameObject ParentObject;
	private char AxisRotating;	
	private GameObject[] face;
	private GameObject[] cube;
	private GameObject[] obstacle;
	private GameObject pivotPoint;
	private double rotationCounter;

	private double playerRotationCounter;
	private bool playerRotating;
	private bool middleRotation;
	
	//private FaceRotating faceRotating;

	private float facePosition;
	
    private char axisRotating;
    private string hitTag, hitParentTag;
	private Vector3 axisVector;

	// New Rotation Fields (Swipe Gestures)
	private string gestureType;
	private Controls.CubeHit cubeHit;
	
	// Use this for initialization
	void Start()
	{
		obstacle = GameObject.FindGameObjectsWithTag("Obstacle");

		// 9 cubes per face
		face = new GameObject[9];
		
		rotationCounter = 0;
		
		middleRotation = false;
		playerRotating = false;
		isRotating = false;
		//faceRotating = FaceRotating.NONE;
	}
	
	// Called when the user presses the z key
	public void RotateFace(/*Vector3 axisVector_, float facePosition_, char axisRotating_,*/ string hitTag_, string hitParentTag_)
	{	
        // Tag all cubes in the rubix cube as "Cube" and fill the cube array with these objects
		//axisVector = axisVector_;
		//facePosition = facePosition_;
        //axisRotating = axisRotating_;
        hitTag = hitTag_;
		hitParentTag = hitParentTag_;
		cube = GameObject.FindGameObjectsWithTag(hitTag);
		ParentObject = GameObject.FindGameObjectWithTag(hitParentTag);

		if(facePosition == 0.0f){middleRotation = true;}

		ParentObject = GameObject.FindGameObjectWithTag(hitParentTag);
		//Debug.Log(hitParentTag);
		
		/*if (!isRotating)
		{
			// Set pivot point to position of centre cube relative to rotating face
			// Change this code to accomodate creating a new pivot point for cube and gesutre input - Stuart
			//switch(axisRotating)
			//{
			//case 'x':	
			if (axisRotating == 'x')
			{
				isRotating = true;
				pivotPoint = new GameObject("pivot");
				pivotPoint.transform.position = ParentObject.transform.position;
				pivotPoint.transform.parent = ParentObject.transform;
				pivotPoint.transform.localPosition = new Vector3(facePosition, 0.0f, 0.0f); // (facePosition, 0.0f, 1.0f);				
			}
			//break;
			//case 'y':	
			if (axisRotating == 'y')
			{
				isRotating = true;
				pivotPoint = new GameObject("pivot");
				pivotPoint.transform.position = ParentObject.transform.position;
				pivotPoint.transform.parent = ParentObject.transform;
				pivotPoint.transform.localPosition = new Vector3(0.0f, facePosition, 0.0f); // (1.0f, facePosition, 1.0f);				
			}
			//break;
			//case 'z':
			if (axisRotating == 'z')
			{
				isRotating = true;
				pivotPoint = new GameObject("pivot");
				pivotPoint.transform.position = ParentObject.transform.position;
				pivotPoint.transform.parent = ParentObject.transform;
				pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, facePosition); // (1.0f, 0.0f, facePosition);			
			}
			//break;
			//}
		}*/

		for(int i = 0; i < 26; i++)
		{
			/*switch(axisRotating)
			{
				case 'x':
					if((cube[i].transform.localPosition.x >= facePosition - 0.1)&&(cube[i].transform.localPosition.x <= facePosition + 0.1))
					{
						cube[i].transform.RotateAround(pivotPoint.transform.position, axisVector, rotationSpeed);
						rotationCounter+=rotationSpeed;
					}

					break;
				case 'y':
					if((cube[i].transform.localPosition.y >= facePosition - 0.1)&&(cube[i].transform.localPosition.y <= facePosition + 0.1))
					{	
						cube[i].transform.RotateAround(pivotPoint.transform.position, axisVector, rotationSpeed);
						rotationCounter+=rotationSpeed;
					}
			
					break;
				case 'z':
					if((cube[i].transform.localPosition.z >= facePosition - 0.1)&&(cube[i].transform.localPosition.z <= facePosition + 0.1))
					{
						cube[i].transform.RotateAround(pivotPoint.transform.position, axisVector, rotationSpeed);
						rotationCounter+=rotationSpeed;
					}             			
					break;
	            default:
	                break;
			}*/

			// Takes which cube is hit and which gesture is used and rotates the cube appropriately
			// isRotating as else in if-else statement, more gestures to be added for 3 way rotation - Stuart
			switch(cubeHit)
			{
			case Controls.CubeHit.FrontTopLeft:			// 01 - Start Front Slice
				isRotating = false;
				break;
			case Controls.CubeHit.FrontTopCentre:		// 02 - Test on this cube first
				if(gestureType == "Left")
				{
					RotateTopFace(i, -rotationSpeed);
				}
				else if(gestureType == "Right")
				{
					RotateTopFace(i, rotationSpeed);
				}
				else
				{
					isRotating = false;
				}
				break;
			case Controls.CubeHit.FrontTopRight:		// 03
				isRotating = false;
				break;
			case Controls.CubeHit.FrontCentreLeft:		// 04
				if(gestureType == "Up")
				{
					RotateLeftFace(i, rotationSpeed);
				}
				else if(gestureType == "Down")
				{
					RotateLeftFace(i, -rotationSpeed);
				}
				else
				{
					isRotating = false;
				}
				break;
			case Controls.CubeHit.FrontCentreCentre:	// 05
				isRotating = false;
				break;
			case Controls.CubeHit.FrontCentreRight:		// 06
				if(gestureType == "Up")
				{
					RotateRightFace(i, rotationSpeed);
				}
				else if(gestureType == "Down")
				{
					RotateRightFace(i, -rotationSpeed);
				}
				else
				{
					isRotating = false;
				}
				break;
			case Controls.CubeHit.FrontBottomLeft:		// 07
				isRotating = false;
				break;
			case Controls.CubeHit.FrontBottomCentre:	// 08
				if(gestureType == "Left")
				{
					RotateBottomFace(i, -rotationSpeed);
				}
				else if(gestureType == "Right")
				{
					RotateBottomFace(i, rotationSpeed);
				}
				else
				{
					isRotating = false;
				}
				break;
			case Controls.CubeHit.FrontBottomRight:		// 09 - End Front Slice
				isRotating = false;
				break;

			case Controls.CubeHit.CentreTopLeft:		// 10 - Start Centre Slice
				isRotating = false;
				break;
			case Controls.CubeHit.CentreTopCentre:		// 11
				isRotating = false;
				break;
			case Controls.CubeHit.CentreTopRight:		// 12
				isRotating = false;
				break;
			case Controls.CubeHit.CentreCentreLeft:		// 13
				isRotating = false;
				break;
			case Controls.CubeHit.CentreCentreCentre:	// 14
				isRotating = false;
				break;
			case Controls.CubeHit.CentreCentreRight:	// 15
				isRotating = false;
				break;
			case Controls.CubeHit.CentreBottomLeft:		// 16
				isRotating = false;
				break;
			case Controls.CubeHit.CentreBottomCentre:	// 17
				isRotating = false;
				break;
			case Controls.CubeHit.CentreBottomRight:	// 18 - End Centre Slice
				isRotating = false;
				break;

			case Controls.CubeHit.BackTopLeft:			// 19 - Start Back Slice
				isRotating = false;
				break;
			case Controls.CubeHit.BackTopCentre:		// 20
				isRotating = false;
				break;
			case Controls.CubeHit.BackTopRight:			// 21
				isRotating = false;
				break;
			case Controls.CubeHit.BackCentreLeft:		// 22
				isRotating = false;
				break;
			case Controls.CubeHit.BackCentreCentre:		// 23
				isRotating = false;
				break;
			case Controls.CubeHit.BackCentreRight:		// 24
				isRotating = false;
				break;
			case Controls.CubeHit.BackBottomLeft:		// 25
				isRotating = false;
				break;
			case Controls.CubeHit.BackBottomCentre:		// 26
				isRotating = false;
				break;
			case Controls.CubeHit.BackBottomRight:		// 27 - End Front Slice
				isRotating = false;
				break;
			default:									// DEFAULT
				isRotating = false;
				break;
			}
			
			if (middleRotation == false) {
				if(rotationCounter >= (90 * 9))
				{
					isRotating = false;
					axisRotating = '0';
					//faceRotating = FaceRotating.NONE;
					Destroy(pivotPoint);
					rotationCounter = 0;
					middleRotation = false;
					cubeHit = Controls.CubeHit.NONE;
					gestureType = "Null";
					
					/*if(pivotPoint)
					{
						Debug.Log("Pivot point still exists");
					}*/			
				}
			}
			
			if (middleRotation == true) {
				if(rotationCounter >= (90 * 8))
				{
					isRotating = false;
					axisRotating = '0';
					//faceRotating = FaceRotating.NONE;
					Destroy(pivotPoint);
					rotationCounter = 0;
					middleRotation = false;
					cubeHit = Controls.CubeHit.NONE;
					gestureType = "Null";
					
					/*if(pivotPoint)
					{
						Debug.Log("Pivot point still exists");
					}*/				
				}
			}
		}		
	}

	// Positive Y (Top Face)
	void RotateTopFace(int i_, float rotationSpeed_)
	{
		int i = i_;
		float rotationSpeedLocal = rotationSpeed_;

		// Set values for rotation
		pivotPoint = new GameObject("pivot");
		pivotPoint.transform.position = ParentObject.transform.position;
		pivotPoint.transform.parent = ParentObject.transform;
		pivotPoint.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
		middleRotation = false;
		
		if((cube[i].transform.localPosition.y >= 0.9)&&(cube[i].transform.localPosition.y <= 1.1))
		{	
			cube[i].transform.RotateAround(pivotPoint.transform.position, Vector3.down, rotationSpeedLocal);
			rotationCounter+=rotationSpeed;
		}
	}

	// Negative Y (Bottom Face)
	void RotateBottomFace(int i_, float rotationSpeed_)	
	{
		int i = i_;
		float rotationSpeedLocal = rotationSpeed_;
		
		// Set values for rotation
		pivotPoint = new GameObject("pivot");
		pivotPoint.transform.position = ParentObject.transform.position;
		pivotPoint.transform.parent = ParentObject.transform;
		pivotPoint.transform.localPosition = new Vector3(0.0f, -1.0f, 0.0f);
		middleRotation = false;
		
		if((cube[i].transform.localPosition.y <= -0.9)&&(cube[i].transform.localPosition.y >= -1.1))
		{	
			cube[i].transform.RotateAround(pivotPoint.transform.position, Vector3.down, rotationSpeedLocal);
			rotationCounter+=rotationSpeed;
		}
	}

	// Positive Z (Front Face)
	void RotateFrontFace(int i_, float rotationSpeed_)
	{
		int i = i_;
		float rotationSpeedLocal = rotationSpeed_;
		
		// Set values for rotation
		pivotPoint = new GameObject("pivot");
		pivotPoint.transform.position = ParentObject.transform.position;
		pivotPoint.transform.parent = ParentObject.transform;
		pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, 1.0f);
		middleRotation = false;
		
		if((cube[i].transform.localPosition.z >= 0.9)&&(cube[i].transform.localPosition.z <= 1.1))
		{	
			cube[i].transform.RotateAround(pivotPoint.transform.position, Vector3.forward, rotationSpeedLocal);
			rotationCounter+=rotationSpeed;
		}
	}

	// Negative Z (Back Face)
	void RotateBackFace(int i_, float rotationSpeed_)
	{
		int i = i_;
		float rotationSpeedLocal = rotationSpeed_;
		
		// Set values for rotation
		pivotPoint = new GameObject("pivot");
		pivotPoint.transform.position = ParentObject.transform.position;
		pivotPoint.transform.parent = ParentObject.transform;
		pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
		middleRotation = false;
		
		if((cube[i].transform.localPosition.z <= -0.9)&&(cube[i].transform.localPosition.z >= -1.1))
		{	
			cube[i].transform.RotateAround(pivotPoint.transform.position, Vector3.forward, rotationSpeedLocal);
			rotationCounter+=rotationSpeed;
		}
	}

	// Positive X (Right Face)
	void RotateRightFace(int i_, float rotationSpeed_)
	{
		int i = i_;
		float rotationSpeedLocal = rotationSpeed_;
		
		// Set values for rotation
		pivotPoint = new GameObject("pivot");
		pivotPoint.transform.position = ParentObject.transform.position;
		pivotPoint.transform.parent = ParentObject.transform;
		pivotPoint.transform.localPosition = new Vector3(1.0f, 0.0f, 0.0f);
		middleRotation = false;
		
		if((cube[i].transform.localPosition.x >= 0.9)&&(cube[i].transform.localPosition.x <= 1.1))
		{	
			cube[i].transform.RotateAround(pivotPoint.transform.position, Vector3.right, rotationSpeedLocal);
			rotationCounter+=rotationSpeed;
		}
	}

	// Negative X (Left Face)
	void RotateLeftFace(int i_, float rotationSpeed_)
	{
		int i = i_;
		float rotationSpeedLocal = rotationSpeed_;
		
		// Set values for rotation
		pivotPoint = new GameObject("pivot");
		pivotPoint.transform.position = ParentObject.transform.position;
		pivotPoint.transform.parent = ParentObject.transform;
		pivotPoint.transform.localPosition = new Vector3(-1.0f, 0.0f, 0.0f);
		middleRotation = false;
		
		if((cube[i].transform.localPosition.x <= -0.9)&&(cube[i].transform.localPosition.x >= -1.1))
		{	
			cube[i].transform.RotateAround(pivotPoint.transform.position, Vector3.right, rotationSpeedLocal);
			rotationCounter+=rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update()
	{	
		if (Input.GetMouseButtonUp(1))
		{
			if (isRotating == false)
			{
				gestureType = this.GetComponentInParent<Gesture> ().MouseSwipe ();
				cubeHit = this.GetComponentInParent<Controls> ().GetCubeHit ();
				Debug.Log(cubeHit.ToString() + " and " + gestureType);
				isRotating = true;
				RotateFace(this.GetComponentInParent<Controls>().GetHitTag(), this.GetComponentInParent<Controls>().GetHitParentTag());
			}
		}

		if(isRotating == true)
		{
			// Possibly remove middle "face" rotation (?) - Stuart
			RotateFace(hitTag, hitParentTag);
        }
	}
}