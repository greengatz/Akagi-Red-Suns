using UnityEngine;
using System.Collections;

public class AlarmClock : Event {
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		// make noise or something
	}

	void selected() {
		if(isRunning()) {
			//Debug.Log ("clock used");
			finishEvent ();
		}
	}
}
