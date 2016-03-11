// Written by Stuart McEwan - 1302856
// Steel Logic
// Rube
// Gesture.cs

using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Gesture")]

public class Gesture : MonoBehaviour
{
	private Vector3 mouseDownPosition, mouseUpPosition;
	private float xPosDifference, yPosDifference;
	private bool mouseDown, gestureReturned;

	public AstarAI script;

	// Use this for initialization
	void Start ()
	{
		mouseDownPosition = new Vector3(0, 0, 0);
		mouseUpPosition = new Vector3(0, 0, 0);
		mouseDown = false;
		gestureReturned = true; // Start as true to avoid return a gesture every frame
	}
	
	// Update is called once per frame
	void Update ()
	{
		MouseSwipe();

		if (!mouseDown)
		{
			mouseDownPosition = new Vector3(0, 0, 0);
			mouseUpPosition = new Vector3(0, 0, 0);
		}
	}

	public string MouseSwipe() // Recognises a left, right, up or down swipe gesture (No diagonals)
	{
		if((Input.GetMouseButtonDown(0)) && !mouseDown)
		{
			mouseDownPosition = Input.mousePosition;
			mouseDown = true;
		}
		else if ((Input.GetMouseButtonUp (0)) && mouseDown)
		{
			gestureReturned = false;
			mouseUpPosition = Input.mousePosition;
			mouseDown = false;
			xPosDifference = mouseUpPosition.x - mouseDownPosition.x;
			yPosDifference = mouseUpPosition.y - mouseDownPosition.y;
			Debug.Log(xPosDifference + " and " + yPosDifference);
		}

		if (gestureReturned == false)
		{
			if (xPosDifference <= -100)
			{
				Debug.Log("Left Swipe");
				gestureReturned = true;
				return "Left";
			}
			else if (xPosDifference >= 100)
			{
				Debug.Log("Right Swipe");
				gestureReturned = true;
				return "Right";
			}
			else if (yPosDifference >= 100)
			{
				Debug.Log("Up Swipe");
				gestureReturned = true;
				return "Up";
			}
			else if (yPosDifference <= -100)
			{
				Debug.Log("Down Swipe");
				gestureReturned = true;
				return "Down";
			}
			else
			{
				Debug.Log("Invalid Gesture");
				gestureReturned = true;
				script.MakePath();
				return "Invalid";
			}
			gestureReturned = true;

		}
		return "Null";
	}
}