using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public string descriptor = "event descriptor";
	public int eventID;
	public float useTime = 1f;
	public bool hideGuy = false;
    public AudioSource[] eventAudio = null;

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

        eventAudio = GetComponents<AudioSource>();
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

        // get the guy, hide him if we should
        // start animation or whatever
        // play start sound

        // start animation or whatever
        // play start sound
        // wait for time amount

		if (eventAudio != null && eventAudio.Length >= 2)
        {
         
                eventAudio[0].Play();
                eventAudio[1].Play();
            
        }

		GlobalState.characterActing = true;
		GlobalState.characterVis = !hideGuy;

        Debug.Log ("starting wait");
		yield return new WaitForSeconds(useTime);
		Debug.Log ("ending wait");

		GlobalState.characterActing = false;
		GlobalState.characterVis = true;
		// wait for time amount       
		// play Loop sound
		// kill animation or whatever
		// stop loop sound
		// play Loop sound
		// kill animation or whatever
		// stop loop sound

		// play end sound
		// make guy visible again
		// play end sound
		// make guy visible again

		finishEvent ();
	}
}