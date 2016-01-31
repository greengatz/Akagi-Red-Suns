using UnityEngine;
using System.Collections;

public class LivingRoomShake : MonoBehaviour {
	public int startIteration;
	public int stopIteration;
	public float duration;

	private CameraShake shaker;
	private bool shake = false;
	private float currentTime = 0.0f;

	// Use this for initialization
	void Start () {
		this.shaker = this.GetComponent<CameraShake> ();
		if (GlobalState.run >= startIteration &&
		    GlobalState.run < stopIteration) {
			shake = true;
		} else {
			shake = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (shake && currentTime < duration) {
			this.shaker.Shake ();
			currentTime += Time.fixedDeltaTime;
		}
	}
}
