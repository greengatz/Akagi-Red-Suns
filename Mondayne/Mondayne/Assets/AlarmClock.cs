using UnityEngine;
using System.Collections;

public class AlarmClock : MonoBehaviour {

	private bool running = false;
	private bool completed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void selected() {
		if(running) {
			Debug.Log ("clock used");
			running = false;
			completed = true;
		}
	}

	void startEvent() {
		running = true;
	}

	bool isCompleted() {
		return completed;
	}
}
