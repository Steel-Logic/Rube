using UnityEngine;
using System.Collections;

public class ArrowBounce : MonoBehaviour {

	public ButtonPressCheck script;

	private float offsetY;
	private float timepassed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timepassed += Time.deltaTime;
		offsetY = Mathf.Sin (timepassed*2);
		this.gameObject.transform.Translate(new Vector3(0, offsetY/50, 0));

		if (script != null) {
			if (script.pressed == true) {
				Destroy (gameObject);
			}
		}
	}
}
