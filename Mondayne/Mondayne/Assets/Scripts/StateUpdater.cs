using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateUpdater : MonoBehaviour {
	// Use this for initialization
	void Start () {
		//GlobalState.testMethod ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalState.events.Count > GlobalState.current) {
			Event running = null; 
			bool gotEvent = GlobalState.events.TryGetValue (GlobalState.current, out running);

			if (gotEvent) {
				if (!running.isRunning () && !running.isCompleted ()) {
					Debug.Log ("Starting event: " + running.descriptor);
					running.startEvent ();
				} else if (!running.isRunning () && running.isCompleted ()) {
					Debug.Log ("Event finished, moving to next event");
					GlobalState.current++;
				}
			}
		} else {
			// next event is in another room
		}
	}

	void resetDay() {
		GlobalState.current = 0;
	}
}
