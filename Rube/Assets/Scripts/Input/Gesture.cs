
using UnityEngine;
using System.Collections;

public class Gesture : MonoBehaviour
{
	private Vector3 mouseDownPosition, mouseUpPosition;
	private float xPosDifference, yPosDifference;
	private bool mouseDown, gestureReturned;

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

	public string MouseSwipe()
	{
		if((Input.GetMouseButtonDown(1)) && !mouseDown)
		{
			mouseDownPosition = Input.mousePosition;
			mouseDown = true;
		}
		else if ((Input.GetMouseButtonUp (1)) && mouseDown)
		{
			gestureReturned = false;
			mouseUpPosition = Input.mousePosition;
			mouseDown = false;
			xPosDifference = mouseUpPosition.x - mouseDownPosition.x;
			yPosDifference = mouseUpPosition.y - mouseDownPosition.y;
			//Debug.Log ("Mouse Down Position (" + mouseDownPosition.x.ToString() + ", " + mouseDownPosition.y.ToString() + ")");
			//Debug.Log ("Mouse Up Position (" + mouseUpPosition.x.ToString() + ", " + mouseUpPosition.y.ToString() + ")");
		}

		if (gestureReturned == false)
		{
			if (xPosDifference <= -200)
			{
				Debug.Log("Left Swipe");
				gestureReturned = true;
				return "Left";
			}
			else if (xPosDifference >= 200)
			{
				Debug.Log("Right Swipe");
				gestureReturned = true;
				return "Right";
			}
			else if (yPosDifference >= 200)
			{
				Debug.Log("Up Swipe");
				gestureReturned = true;
				return "Up";
			}
			else if (yPosDifference <= -200)
			{
				Debug.Log("Down Swipe");
				gestureReturned = true;
				return "Down";
			}
			else
			{
				Debug.Log("Invalid Gesture");
				gestureReturned = true;
				return "Invalid";
			}
			gestureReturned = true;
		}
		return "Null";
	}
}