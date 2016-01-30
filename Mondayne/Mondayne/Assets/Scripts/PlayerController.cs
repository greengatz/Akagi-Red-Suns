using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
	private BoxCollider2D bc2d;
    public float interactRange = 0.1f;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		bc2d = GetComponent<BoxCollider2D> ();
		bc2d.offset = new Vector2 (-0.008f, -0.2f);
		bc2d.size = new Vector2 (0.155f, 0.4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		movement.Normalize ();
		rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime * GlobalState.speed);


        if (moveHorizontal != 0)
        {
            animator.SetFloat("DirectionX", moveHorizontal);
            animator.SetFloat("DirectionY", 0f);
            animator.SetBool("IsMoving", true);
        }
        else if (moveVertical != 0)
        {
            animator.SetFloat("DirectionY", moveVertical);
            animator.SetFloat("DirectionX", 0f);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        //Debug.Log(moveVertical + " " + moveHorizontal);


        // check for nearby objects
        Collider2D[] nearDest = Physics2D.OverlapCircleAll(GetComponent<Transform>().position, interactRange);
		bool select = Input.GetButtonDown("Jump");
        for (int i = 0; i < nearDest.Length; i++)
        {
			Collider2D near = nearDest [i];
			//Debug.Log ("near object " + nearDest [i].gameObject.name + " and " + select);

			if (select && !gameObject.Equals(near.gameObject) && 
					near.gameObject.CompareTag("Event"))
			{
                nearDest[i].gameObject.SendMessage("selected");
            }
        }
    }
}
