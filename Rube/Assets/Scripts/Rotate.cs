// Written by Stuart McEwan - 1302856
// Steel Logic
// Rube
// Controls.cs

using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Rotate")]

public class Rotate : MonoBehaviour
{	
	
	// Enumerators
	/*public enum FaceRotating // Used to choose which face of the cube should be rotating
	{
		NONE, FRONT, BACK, LEFT, RIGHT, TOP, BOTTOM, MIDDLEX, MIDDLEY, MIDDLEZ
	};*/
	
	/*public enum AxisRotating // Used to choose which axis a face of the cube should be rotating around
	{
		NONE, X, Y, Z
	};*/
	
	public bool isRotating;
	
	// Public
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
	
	// Use this for initialization
	void Start()
	{
		obstacle = GameObject.FindGameObjectsWithTag("Obstacle");

		// 9 cubes per face
		face = new GameObject[9];
		
		rotationCounter = 0;

		//rotationSpeed = 3f;
		
		middleRotation = false;
		playerRotating = false;
		isRotating = false;
		//faceRotating = FaceRotating.NONE;
		
		pivotPoint = new GameObject("pivot");
	}
	
	// Called when the user presses the z key
	public void RotateFace(Vector3 axisVector_, float facePosition_, char axisRotating_, string hitTag_, string hitParentTag_)
	{
	
        // Tag all cubes in the rubix cube as "Cube" and fill the cube array with these objects
		axisVector = axisVector_;
		facePosition = facePosition_;
        axisRotating = axisRotating_;
        hitTag = hitTag_;
		hitParentTag = hitParentTag_;
		cube = GameObject.FindGameObjectsWithTag(hitTag);
		ParentObject = GameObject.FindGameObjectWithTag(hitParentTag);

		if(facePosition == 0.0f){middleRotation = true;}

		if (!isRotating)
		{
			// Set pivot point to position of centre cube relative to rotating face
			switch(axisRotating)
			{
				case 'x':					
					pivotPoint.transform.position = ParentObject.transform.position;
					pivotPoint.transform.parent = ParentObject.transform;
					pivotPoint.transform.localPosition = new Vector3(facePosition, 0.0f, 1.0f); // (facePosition, 0.0f, 1.0f);
				break;
				case 'y':								
					pivotPoint.transform.position = ParentObject.transform.position;
					pivotPoint.transform.parent = ParentObject.transform;
					pivotPoint.transform.localPosition = new Vector3(1.0f, facePosition, 1.0f); // (1.0f, facePosition, 1.0f);
				break;
				case 'z':
					pivotPoint.transform.position = ParentObject.transform.position;
					pivotPoint.transform.parent = ParentObject.transform;
					pivotPoint.transform.localPosition = new Vector3(1.0f, 0.0f, facePosition); // (1.0f, 0.0f, facePosition);
				break;
			}
		}

		for(int i = 0; i < 27; i++)
		{
			switch(axisRotating)
			{
			/*case AxisRotating.NONE:
				break;*/
			case 'x':
				if((cube[i].transform.localPosition.x >= facePosition - 0.1)&&(cube[i].transform.localPosition.x <= facePosition + 0.1))
				{
					isRotating = true;
					cube[i].transform.RotateAround(pivotPoint.transform.position, axisVector, rotationSpeed);
					rotationCounter+=rotationSpeed;
				}

				break;
			case 'y':
				if((cube[i].transform.localPosition.y >= facePosition - 0.1)&&(cube[i].transform.localPosition.y <= facePosition + 0.1))
				{	
					isRotating = true;				
					cube[i].transform.RotateAround(pivotPoint.transform.position, axisVector, rotationSpeed);
					rotationCounter+=rotationSpeed;
				}
		
				break;
			case 'z':
				if((cube[i].transform.localPosition.z >= facePosition - 0.1)&&(cube[i].transform.localPosition.z <= facePosition + 0.1))
				{
					isRotating = true;
					cube[i].transform.RotateAround(pivotPoint.transform.position, axisVector, rotationSpeed);
					rotationCounter+=rotationSpeed;
				}             			
				break;
            default:
                break;
			}
			
			if (middleRotation == false) {
				if(rotationCounter >= (90 * 9))
				{
					isRotating = false;
					//faceRotating = FaceRotating.NONE;
					//Destroy(pivotPoint);
					rotationCounter = 0;
					middleRotation = false;
					
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
					//faceRotating = FaceRotating.NONE;
					//Destroy(pivotPoint);
					rotationCounter = 0;
					middleRotation = false;
					
					/*if(pivotPoint)
					{
						Debug.Log("Pivot point still exists");
					}*/				
				}
			}
		}		
	}
	
	// Update is called once per frame
	void Update()
	{
		// Remove keyboard controls once mouse/touch input is working correctly - Stuart
		// Start Keyboard Controls
        /*
		if((Input.GetKeyDown("z")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.FRONT;
			
			// Set pivot point to position of centre cube on front face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
		}

		if((Input.GetKeyDown("q")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.BACK;
			
			// Set pivot point to position of centre cube on back face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, 1.0f);
		}
		
		if((Input.GetKeyDown("a")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.MIDDLEZ;
			
			// Set pivot point to position of centre cube on back face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			middleRotation = true;
		}
		
		if((Input.GetKeyDown("x")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.RIGHT;
			
			// Set pivot point to position of centre cube on right face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(-1.0f, 0.0f, 0.0f);	
		}
		
		if((Input.GetKeyDown("w")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.LEFT;
			
			// Set pivot point to position of centre cube on left face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(1.0f, 0.0f, 0.0f);	
		}
		
		if((Input.GetKeyDown("s")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.MIDDLEX;
			
			// Set pivot point to position of centre cube on back face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			middleRotation = true;
		}
		
		if((Input.GetKeyDown("e")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.TOP;
			
			// Set pivot point to position of centre cube on top face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);			
		}
		
		if((Input.GetKeyDown("c")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.BOTTOM;
			
			// Set pivot point to position of centre cube on bottom face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(0.0f, -1.0f, 0.0f);			
		}
		
		if((Input.GetKeyDown("d")) && (isRotating == false))
		{
			isRotating = true;
			faceRotating = FaceRotating.MIDDLEY;
			
			// Set pivot point to position of centre cube on bottom face
			pivotPoint = new GameObject("pivot");
			pivotPoint.transform.position = ParentObject.transform.position;
			pivotPoint.transform.parent = ParentObject.transform;
			pivotPoint.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			middleRotation = true;
		}
        */
		// End Keyboard Controls		
		
		if(isRotating == true)
		{
			// Possibly remove middle "face" rotation (?) - Stuart
			RotateFace(axisVector, facePosition, axisRotating, hitTag, hitParentTag);
        }
	}
}