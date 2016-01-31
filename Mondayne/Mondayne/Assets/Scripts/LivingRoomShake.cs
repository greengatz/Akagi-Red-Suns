using UnityEngine;
using System.Collections;

public class LivingRoomShake : MonoBehaviour {
	private CameraShake shaker;

	// Use this for initialization
	void Start () {
		this.shaker = this.GetComponent<CameraShake> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.shaker.Shake (2.0f);
	}
}
