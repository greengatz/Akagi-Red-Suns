using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateUpdater : MonoBehaviour {
	private static string unknownTask = "Hmm, I wonder what you should do next";

	public AudioSource music1 = null;
	public AudioSource music2 = null;
	public int switchMusicOn = 2;

	// Use this for initialization
	void Start () {
		GlobalState.switchMusic = switchMusicOn;

		//GlobalState.testMethod ();
		if (GlobalState.music1 == null && music1 != null) {
			GlobalState.music1 = music1;
			GlobalState.music1.Play ();
			DontDestroyOnLoad (GlobalState.music1);
		}
		if (GlobalState.music2 == null && music2 != null) {
			GlobalState.music2 = music2;
			DontDestroyOnLoad (GlobalState.music2);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalState.events.Count > GlobalState.current) {
			Event running = null; 
			bool gotEvent = GlobalState.events.TryGetValue (GlobalState.current, out running);

			if (gotEvent) {
				if (!running.isRunning () && !running.isCompleted ()) {
					Debug.Log ("Starting event: " + running.descriptor[Mathf.Min(GlobalState.run, running.descriptor.Length - 1)]);
					running.startEvent ();
					GlobalState.toDisplay = running.descriptor[Mathf.Min(GlobalState.run, running.descriptor.Length - 1)];
				} else if (!running.isRunning () && running.isCompleted ()) {
					Debug.Log ("Event finished, moving to next event, event " + (GlobalState.current+1));
					GlobalState.current++;
					GlobalState.toDisplay = unknownTask;
				}
			}
		} else {
			// next event is in another room
		}
	}
}
