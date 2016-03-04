using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {
	
	private static DontDestroyOnLoad instance = null;
	public static DontDestroyOnLoad GetInstance {
		get { return instance; }
	}
	
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(instance.gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	void Update() {
		if (Application.loadedLevel == 0) {
			Destroy(this.gameObject);
		}
	}
}
