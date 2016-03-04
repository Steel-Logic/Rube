using UnityEngine;
using System.Collections;

public class MouseOverCog : MonoBehaviour {

	public SpriteRenderer thisSprite;
	public GameObject thisCog;
	private RaycastHit hit;
	private Ray ray;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject == thisCog) {
				thisSprite.enabled = true;
			} else {
				thisSprite.enabled = false;
			}
		}
	
	}
}
