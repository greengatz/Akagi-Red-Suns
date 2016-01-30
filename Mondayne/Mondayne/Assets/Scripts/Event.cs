using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public string descriptor = "event descriptor";
	public int eventID;

	private bool running = false;
	private bool completed = false;

	// Use this for initialization
	public void Init () {
		GlobalState.events.Add (eventID, this);
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
}
