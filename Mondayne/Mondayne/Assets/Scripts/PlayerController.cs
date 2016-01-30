using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float interactRange = 1.0f;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		gameObject.GetComponent<SpriteRenderer> ().enabled = GlobalState.characterVis;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		movement.Normalize ();

		if (!GlobalState.characterActing) {
			rb2d.MovePosition (rb2d.position + movement * Time.fixedDeltaTime * GlobalState.speed);
		}

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
