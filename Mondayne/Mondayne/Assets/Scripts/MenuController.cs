using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Animator animator;

	public float speed = 3.0f;

	public float bottomY = -2;
	public float topY = 1;
	public float leftX = -3;
	public float rightX = 0;

	public float closeEnough = 0.2f;

	private Vector2[] locs;
	private int nextDest = 0;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		locs = new Vector2[] {new Vector2(rightX, bottomY), new Vector2(rightX, topY),
			new Vector2(leftX, topY), new Vector2(leftX, bottomY)};
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 movement = locs [nextDest] - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		movement.Normalize ();
		rb2d.MovePosition (rb2d.position + movement * Time.fixedDeltaTime * speed);

		if ((new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - locs[nextDest]).magnitude < closeEnough) {
			nextDest = (nextDest + 1) % locs.Length;
		}

		if (movement.x != 0 && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
		{
			animator.SetFloat("DirectionX", movement.x);
			animator.SetFloat("DirectionY", 0f);
			animator.SetBool("IsMoving", true);
		}
		else if (movement.y != 0)
		{
			animator.SetFloat("DirectionY", movement.y);
			animator.SetFloat("DirectionX", 0f);
			animator.SetBool("IsMoving", true);
		}
		else
		{
			animator.SetBool("IsMoving", false);
		}
	}
}
