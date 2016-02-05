﻿/*
Stuart McEwan
1302856
*/

using UnityEngine;
using System.Collections;

public class RotateXOnly : MonoBehaviour
{	
	
	// Enumerators
	public enum FaceRotating // Used to choose which face of the cube should be rotating
	{
		NONE, FRONT, BACK, LEFT, RIGHT, TOP, BOTTOM, MIDDLEX, MIDDLEY, MIDDLEZ
	};
	
	public enum AxisRotating // Used to choose which axis a face of the cube should be rotating around
	{
		NONE, X, Y, Z
	};
	
	// Public
	public GameObject RubixCube;
	public GameObject ParentObject;
	
	public float rotationSpeed;
	
	// Private
	private GameObject[] face;
	private GameObject[] cube;
	private GameObject[] obstacle;
	private GameObject pivotPoint;
	private double rotationCounter;
	private double playerRotationCounter;
	private bool isRotating;
	private bool playerRotating;
	private bool middleRotation;
	
	private FaceRotating faceRotating;
	
	// Use this for initialization
	void Start()
	{
		// Tag all cubes in the rubix cube as "Cube" and fill the cube array with these objects
		cube = GameObject.FindGameObjectsWithTag("Cube");
		
		obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
		
		// 9 cubes per face
		face = new GameObject[9];
		
		rotationCounter = 0;
		
		rotationSpeed = 3f;
		
		middleRotation = false;
		playerRotating = false;
		isRotating = false;
		faceRotating = FaceRotating.NONE;
		
		
	}
	
	// Called when the user presses the z key
	void RotateFace(Vector3 axisVector, float rotationVelocity, float facePosition, AxisRotating axisRotating)
	{
		for(int i = 0; i < 27; i++)
		{
			switch(axisRotating)
			{
			case AxisRotating.NONE:
				break;
			case AxisRotating.X:
				if((cube[i].transform.localPosition.x >= facePosition - 0.1)&&(cube[i].transform.localPosition.x <= facePosition + 0.1))
				{
					// Rotate the pivot point by 90 degrees around the specified vector ("axisVector")
					cube[i].transform.RotateAround(pivotPoint.transform.position, axisVector, rotationVelocity);
					rotationCounter+=rotationVelocity;
				}
				
				break;
			}
			
			if (middleRotation == false) {
				if(rotationCounter >= (90 * 9))
				{
					isRotating = false;
					faceRotating = FaceRotating.NONE;
					Destroy(pivotPoint);
					rotationCounter = 0;
					middleRotation = false;
					
					if(pivotPoint != null)
					{
						Debug.Log("Pivot point still exists");
					}				
				}
			}
			
			if (middleRotation == true) {
				if(rotationCounter >= (90 * 8))
				{
					isRotating = false;
					faceRotating = FaceRotating.NONE;
					Destroy(pivotPoint);
					rotationCounter = 0;
					middleRotation = false;
					
					if(pivotPoint != null)
					{
						Debug.Log("Pivot point still exists");
					}				
				}
			}
		}		
	}
	
	// Update is called once per frame
	void Update()
	{

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
		
		if(isRotating == true)
		{
			switch(faceRotating)
			{
			case FaceRotating.NONE:
				break;
			case FaceRotating.LEFT:
				RotateFace(Vector3.right, rotationSpeed, 1.0f, AxisRotating.X);
				break;
			case FaceRotating.RIGHT:
				RotateFace(Vector3.right, rotationSpeed, -1.0f, AxisRotating.X);
				break;
			case FaceRotating.MIDDLEX:
				RotateFace(Vector3.right, rotationSpeed, 0.0f, AxisRotating.X);
				break;
			default:
				break;
			}
		}
	}
}