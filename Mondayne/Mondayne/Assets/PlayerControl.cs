using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 5.0f;
	public float interactRange = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDirection *= speed;

		GetComponent<CharacterController> ().Move(moveDirection);
		//Debug.Log (moveDirection);

		//Collider coll = GetComponent<BoxCollider> ();

		// check for nearby objects
		Collider[] nearDest = Physics.OverlapSphere(gameObject.transform.position, interactRange);
		for(int i = 0; i < nearDest.Length; i++) {
			if (!gameObject.Equals (nearDest [i].gameObject)) {
				Debug.Log ("near anoterh object");
			}
		}
	}

	void OnCollisionEnter() {
		Debug.Log ("collision");
	}
}
