using UnityEngine;
using System.Collections;

public class SpriteSwitcher : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;
	public int eventID;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalState.events.ContainsKey (eventID) &&
		    GlobalState.events [eventID].isCompleted ()) {
			sr.sprite = sprite2;
		} else {
			sr.sprite = sprite1;
		}
	}

}
