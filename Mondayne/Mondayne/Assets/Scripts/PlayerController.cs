using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.01f;
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
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		movement.Normalize ();
		rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime * speed);


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
        for (int i = 0; i < nearDest.Length; i++)
        {
			bool select = Input.GetButtonDown("Jump");
			Collider2D near = nearDest [i];
			if (select && !gameObject.Equals(near.gameObject) && 
					near.gameObject.CompareTag("Event"))
			{
				if (!gameObject.Equals(nearDest[i].gameObject))
            	{
                
					//Debug.Log ("near object " + nearDest [i].gameObject.name);

                    //Debug.Log ("using object " + nearDest [i].gameObject.name);
                    //nearDest [i].gameObject.name;
                    nearDest[i].gameObject.SendMessage("selected");
                }
            }
            else {
                //Debug.Log ("forever alone");
            }
        }
    }
}
