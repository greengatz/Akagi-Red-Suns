﻿using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public string descriptor = "event descriptor";
	public int eventID;
	public float useTime = 0.0f;
	public bool hideGuy = false;

	private bool running = false;
	private bool completed = false;

	// Use this for initialization
	public void Start () {
		if (GlobalState.events.ContainsKey(eventID)) {
			GlobalState.events.Remove(eventID);
		}

		GlobalState.events.Add (eventID, this);

		if (GlobalState.current > eventID) {
			completed = true;
		}
	}

	public void startEvent() {
		running = true;
	}

	public bool isRunning() {
		return running;
	}

	public bool isCompleted() {
		return completed;
	}

	public void finishEvent() {
		running = false;
		completed = true;
	}

	public void selected() {
		//Debug.Log ("selected");
		if (isRunning ()) {
			Debug.Log ("selected");
			StartCoroutine (waitSelected ());
		}
	}

	IEnumerator waitSelected() {
		// get the guy, hide him if we should

		// start animation or whatever
		// play start sound

		// wait for time amount
		Debug.Log ("starting wait");
		yield return new WaitForSeconds(useTime);
		Debug.Log ("ending wait");

		// play Loop sound
		// kill animation or whatever
		// stop loop sound

		// play end sound
		// make guy visible again


		finishEvent ();
	}
}
