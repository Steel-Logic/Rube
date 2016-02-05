using UnityEngine;
using System.Collections;
 
public class MouseClickCameraMove2 : MonoBehaviour
{
    public float dragSpeed = 2f;
    private Vector3 dragOrigin;
   
    public bool cameraDragging = true;
	public bool turningLeft = false;
	public bool turningRight = false;

	public int cameraPosition;
	
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
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
       
        /*float left = (Screen.width * 0.1f) + Screen.width;
        float right = (Screen.width - (Screen.width * 0.1f));
		float down = (Screen.height * 0.1f) + Screen.height;
        float up = (Screen.height - (Screen.height * 0.1f));*/

		float left = (Screen.width * 0.1f);
		float right = (Screen.width - (Screen.width * 0.1f));
		float down = (Screen.height * 0.1f);
		float up = (Screen.height - (Screen.height * 0.1f));
       
        if(mousePosition.x < left)
        {
            cameraDragging = true;
        }
        else if(mousePosition.x > right)
        {
            cameraDragging = true;
        }
		if(mousePosition.y < down)
        {
            cameraDragging = true;
        }
        else if(mousePosition.y > up)
        {
            cameraDragging = true;
        }
           
        if (cameraDragging) {
           
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

			if (Input.mousePosition.x < dragOrigin.x)
			{
				turningLeft = true;
				turningRight = false;
			}
			if (Input.mousePosition.x > dragOrigin.x)
			{
				turningRight = true;
				turningLeft = false;
			}
           
			Vector3 pos = myCamera.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			Vector3 rotate = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
			Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            if (Input.GetMouseButtonUp(0))
			{

				if (turningLeft) 
				{
					transform.RotateAround(target.position, target.up, 90);
					turningLeft = false;
					cameraPosition = cameraPosition + 1;
				}
				if (turningRight) 
				{
					transform.RotateAround(target.position, target.up, -90);
					turningRight = false;
					cameraPosition = cameraPosition - 1;
				}
				if (cameraPosition > 4) {
					cameraPosition = 1;
				}
				if (cameraPosition < 1) {
					cameraPosition = 4;
				}
				return;
			}

			//transform.RotateAround(target.position, target.right, pos.y * dragSpeed);
	
			transform.LookAt(target);

			return;           
		}
    }
   
   
}