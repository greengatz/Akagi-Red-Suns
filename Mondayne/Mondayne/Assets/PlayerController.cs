using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 0.01f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.MovePosition (rb2d.position + movement);

	}

}
