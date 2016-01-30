using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 0.01f;
	private Rigidbody2D rb2d;
	public float interactRange = 10.0f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		movement *= speed;
		rb2d.MovePosition (rb2d.position + movement);


		// check for nearby objects
		Collider2D[] nearDest = Physics2D.OverlapCircleAll (GetComponent<Transform>().position, interactRange);
		for(int i = 0; i < nearDest.Length; i++) {
			if (!gameObject.Equals (nearDest [i].gameObject)) {
				Debug.Log ("near another object");
			} else {
				Debug.Log ("forever alone");
			}
		}
	}

}
