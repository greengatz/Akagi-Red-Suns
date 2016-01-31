using UnityEngine;
using System.Collections;

public class DelayedSpriteSwitcher : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;
	public int eventID;
	public float delayAmount = 0.5f;

	private bool canSwitch = true;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (canSwitch) {
			StartCoroutine (Switch ());
		}
	}

	IEnumerator Switch() {
		canSwitch = false;
		if (GlobalState.events.ContainsKey (eventID) &&
			GlobalState.events [eventID].isCompleted ()) {
			yield return new WaitForSeconds (0.2f);
			sr.sprite = sr.sprite == sprite1 ? sprite2 : sprite1;
		} else {
			sr.sprite = null;
		}
		canSwitch = true;

	}
}
