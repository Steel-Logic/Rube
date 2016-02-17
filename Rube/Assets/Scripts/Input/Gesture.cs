using UnityEngine;
using System.Collections;

public class Gesture : MonoBehaviour
{
	private Vector3 mouseDownPosition, mouseUpPosition;
	private bool mouseDown;

	// Use this for initialization
	void Start ()
	{
		mouseDownPosition = new Vector3(0, 0, 0);
		mouseUpPosition = new Vector3(0, 0, 0);
		mouseDown = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MouseSwipe ();

		if (!mouseDown)
		{
			mouseDownPosition = new Vector3(0, 0, 0);
			mouseUpPosition = new Vector3(0, 0, 0);
		}
	}

	void MouseSwipe()
	{
		if((Input.GetMouseButtonDown(1)) && !mouseDown)
		{
			mouseDownPosition = Input.mousePosition;
			mouseDown = true;
		}
		else if ((Input.GetMouseButtonUp (1)) && mouseDown)
		{
			mouseUpPosition = Input.mousePosition;
			mouseDown = false;
			Debug.Log ("Mouse Down Position (" + mouseDownPosition.x.ToString() + ", " + mouseDownPosition.y.ToString() + ")");
			Debug.Log ("Mouse Up Position (" + mouseUpPosition.x.ToString() + ", " + mouseUpPosition.y.ToString() + ")");
		}

		if ((mouseUpPosition.y - mouseDownPosition.y) <= 200 || (mouseUpPosition.y - mouseDownPosition.y) >= -200)
		{
			if ((mouseUpPosition.x - mouseDownPosition.x) <= -200)
			{
				Debug.Log("Left Swipe");
			}
			else if ((mouseUpPosition.x - mouseDownPosition.x) >= 200)
			{
				Debug.Log("Right Swipe");
			}
		}
	}
}