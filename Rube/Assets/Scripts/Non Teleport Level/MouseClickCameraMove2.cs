using UnityEngine;
using System.Collections;
 
public class MouseClickCameraMove2 : MonoBehaviour
{
	public float dragSpeed = 2f;
	private Vector3 dragOrigin;
	
	public bool cameraDragging = true;
	public bool turningLeft = false;
	public bool turningRight = false;
	
	int counter = 0;
	
	public bool startTurning = false;
	
	public int cameraPosition;
	
	public HasPlayerFinishedTeleport script;
	public HasPlayerFinishedTeleport script2;
	
	public Transform target;
	
	new Camera myCamera;
 
	void Start() {
	
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		cameraPosition = 1;

	}

	public int GetCameraPosition() {
		return cameraPosition;
	}
   
	void Update()
	{
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		
		/*float left = (Screen.width * 0.1f) + Screen.width;
        float right = (Screen.width - (Screen.width * 0.1f));
		float down = (Screen.height * 0.1f) + Screen.height;
        float up = (Screen.height - (Screen.height * 0.1f));*/
		
		float left = (Screen.width * 0.1f);
		float right = (Screen.width - (Screen.width * 0.1f));
		float down = (Screen.height * 0.1f);
		float up = (Screen.height - (Screen.height * 0.1f));
		
		if (myCamera.isActiveAndEnabled) {
			
			if (Input.GetMouseButtonDown (0)) {
				if (startTurning == false) {
					cameraDragging = true;
					dragOrigin = Input.mousePosition;
					return;
				}
			}
			
			if (cameraDragging) {
				
				if (Input.mousePosition.x < dragOrigin.x) {
					if (startTurning == false) {
						turningLeft = true;
						turningRight = false;
					}
				}
				if (Input.mousePosition.x > dragOrigin.x) {
					if (startTurning == false) {
						turningRight = true;
						turningLeft = false;
					}
				}
				
				Vector3 pos = myCamera.ScreenToViewportPoint (Input.mousePosition - dragOrigin);
				Vector3 rotate = new Vector3 (pos.x * dragSpeed, pos.y * dragSpeed, 0);
				Vector3 move = new Vector3 (pos.x * dragSpeed, pos.y * dragSpeed, 0);
				
				if (Input.GetMouseButtonUp (0)) {
					if (turningLeft == true || turningRight == true) {
						startTurning = true;
						cameraDragging = false;
					}
				}
				
				//transform.RotateAround(target.position, target.right, pos.y * dragSpeed);
				
				
				transform.LookAt (target);
				
				return;           
			}
			
			if (startTurning == true) {

					if (turningRight) {
						if (counter < 90) {
							transform.RotateAround (target.position, target.up, 1);
							counter++;
						}
						if (counter == 90) {
							turningLeft = false;
							startTurning = false;
							cameraPosition = cameraPosition - 1;
							counter = 0;
							
						}
						
					}
					if (turningLeft) {
						if (counter < 90) {
							transform.RotateAround (target.position, target.up, -1);
							counter++;
						}
						if (counter == 90) {
							turningRight = false;
							startTurning = false;
							cameraPosition = cameraPosition + 1;
							counter = 0;
							
						}
						
					}
					if (cameraPosition > 4) {
						cameraPosition = 1;
					}
					if (cameraPosition < 1) {
						cameraPosition = 4;
					}
					return;
				}
			}

	}
   
   
}