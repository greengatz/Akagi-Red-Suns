using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public string descriptor = "event descriptor";
	public int eventID;

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

	void selected() {
		if(isRunning()) {
			finishEvent ();
		}
	}
}
