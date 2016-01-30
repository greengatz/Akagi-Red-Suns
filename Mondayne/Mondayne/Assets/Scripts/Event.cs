using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public string descriptor = "event descriptor";
	public int eventID;
	public float useTime = 0.0f;
	public bool hideGuy = false;
    public AudioSource eventAudio = null;

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
			float toWait = useTime;

			Debug.Log ("starting wait");
			while (toWait > 0) {
				toWait -= Time.deltaTime;
			}
			Debug.Log ("ending wait");

			// get the guy, hide him if we should

			// start animation or whatever
			// play start sound

			// wait for time amount
			// play Loop sound
			// kill animation or whatever
			// stop loop sound

			// play end sound
			// make guy visible again


			finishEvent ();
		}
	}
}
