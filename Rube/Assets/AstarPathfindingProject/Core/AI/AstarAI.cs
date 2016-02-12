using UnityEngine;
using System.Collections;

//Note this line, if it is left out, the script won't know that the class "Path" exists and it will throw compiler
//error
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;

public class AstarAI : MonoBehaviour 
{
	//The point to move to
	public Vector3 targetPosition;
	public Transform targetT;
	
	//Get components
	protected Seeker seeker;
	protected CharacterController controller;

	//get camera
	public Camera isometricCamera;
	public Camera playerCamera;

	//get teleporter scipt
	public TeleportScript script;

	//The calculated path
	protected Path path;

	//The AI's speed per second
	public float speed = 2000;

	public int rotationSpeed = 100;

	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 2;
	
	//The waypoint we are currently moving towards
	private int currentWayPoint = 0;

	private Vector3 previousLocation;
	private Vector3 currentLocation;

	//
	// New
	//
	public float forwardLook;
	public float endReachedDistance;
	public bool closestOnPathCheck;
	protected float minMoveScale = 0.05f;
	protected bool targetReached = false;

	
	public void Start()
	{
		//Get references to attached components
		seeker = GetComponent<Seeker> ();
		controller = GetComponent<CharacterController> ();

		//camera stuff
		playerCamera = GameObject.FindGameObjectWithTag ("PlayerCamera").GetComponent<Camera>();
		isometricCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();

		//Default value for target position
		//targetPosition = controller.transform.position;


		//send path to seeker component
		seeker.StartPath (transform.position, targetPosition, OnPathComplete);
	}

	public void OnPathComplete(Path p)
	{
		Debug.Log ("Yay, we got a path back. Did it have an error? " + p.error);
		if (!p.error) 
		{
			path = p;
			//Reset the waypoint counter
			currentWayPoint = 0;
		}
	}

	public void OnDisable()
	{
		seeker.pathCallback -= OnPathComplete;
	}
	public void Update()
	{

		if(path == null)
		{
			//We have no path to move after yet
			return;
		}
		//MOUSE CLICKS
		if (Input.GetMouseButtonDown (0)) {
	
			AstarPath.active.Scan ();
			RaycastHit hit;
			//we need to actually hit an object

			if (playerCamera.enabled) {
				if (!Physics.Raycast (playerCamera.ScreenPointToRay (Input.mousePosition), out hit, 1000)) {
					return;
				}
				if (!hit.transform) {
					return;
				}
				targetPosition = hit.point;

			}			
					

			//Start a new path to the targetPosition, return the result to the OnPathComplete function
			seeker.StartPath (transform.position, targetPosition, OnPathComplete);
		}
		//if (currentWayPoint >= path.vectorPath.Count) 
		//{
			//Debug.Log("End of Path Reached");

			//return;
		//}

		previousLocation = currentLocation;    
		currentLocation = transform.position;

		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);

		//Direction to the next waypoint
		Vector3 direction = (path.vectorPath [currentWayPoint] - transform.position).normalized;
		direction *= speed * Time.deltaTime;
		controller.SimpleMove (direction);

		//Check if we are close enough to the next waypoint
		//if we are, proceed to follow the next waypoint
		if(Vector3.Distance (transform.position, path.vectorPath[currentWayPoint]) < nextWaypointDistance)
		{
			currentWayPoint++;
			return;
		}


	}
}