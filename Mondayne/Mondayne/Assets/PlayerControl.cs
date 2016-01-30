using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDirection *= speed;

		GetComponent<CharacterController> ().Move(moveDirection);
		//Debug.Log (moveDirection);

		Collider coll = GetComponent<BoxCollider> ();
	}

	void OnCollisionEnter() {
		Debug.Log ("collision");
	}
}
