using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 10;
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
		rb2d.MovePosition (rb2d.position + movement * Time.fixedDeltaTime * speed);

		// check for nearby objects
		Collider2D[] nearDest = Physics2D.OverlapCircleAll (GetComponent<Transform>().position, interactRange);
		for(int i = 0; i < nearDest.Length; i++) {
			if (!gameObject.Equals (nearDest [i].gameObject)) {
				bool select = Input.GetButtonDown ("Jump");
				if (select) {
					//Debug.Log ("using object " + nearDest [i].gameObject.name);
					//nearDest [i].gameObject.name;
					nearDest[i].gameObject.SendMessage("selected");
				}
			} else {
				//Debug.Log ("forever alone");
			}
		}
	}

}
