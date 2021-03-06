﻿using UnityEngine;


public class PlatformerCharacter2D : MonoBehaviour
{
    private bool facingRight = true; // For determining which way the player is currently facing.

    [SerializeField] private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
    [SerializeField] private float jumpForce = 400f; // Amount of force added when the player jumps.	

    [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
                                                 // Amount of maxSpeed applied to crouching movement. 1 = 100%

    [SerializeField] private bool airControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character

    private Transform groundCheck; // A position marking where to check if the player is grounded.
    private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool grounded = false; // Whether or not the player is grounded.
    private Transform ceilingCheck; // A position marking where to check for ceilings
    private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator anim; // Reference to the player's animator component.
	private bool candoublejump = false; 
	private Rigidbody2D rigi;
	private GameMaster gm;

	private AudioSource audio1;

	public AudioClip coin;
	public AudioClip coins8;
	public AudioClip coins10;

	//public AudioSource audio2;

	//public LevelManager levelManager;

	void Start()  {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		//levelManager = FindObjectOfType<LevelManager> ();
		audio1 = GetComponent<AudioSource>();
		//audio2 = GetComponent<AudioSource>();

	}

    private void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator>();
		rigi = GetComponent<Rigidbody2D> ();
    }


    private void FixedUpdate()
    {
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        // Set the vertical animation
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		anim.enabled = true;
    }


    public void Move(float move, bool crouch, bool jump)
    {

        // If crouching, check to see if the character can stand up
        if (!crouch && anim.GetBool("Crouch"))
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
                crouch = true;
        }

        // Set whether or not the character is crouching in the animator
        anim.SetBool("Crouch", crouch);

        //only control the player if grounded or airControl is turned on
        if (grounded || airControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            move = (crouch ? move*crouchSpeed : move);

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
                // ... flip the player.
                Flip();
                // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight)
                // ... flip the player.
                Flip();
        }

		if (jump)  {
			if (grounded)  {
				rigi.velocity = new Vector2(rigi.velocity.x, 0);
				rigi.AddForce(new Vector2(0, jumpForce));
				candoublejump = true;
			}
			else  {
				if (candoublejump)  {
					candoublejump = false;
					rigi.velocity = new Vector2(rigi.velocity.x, 0);
					rigi.AddForce(new Vector2(0, jumpForce));
				}
			}
		}
        /*// If the player should jump...
        if (grounded && jump && anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            grounded = false;
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }*/
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	void OnCollisionEnter2D (Collision2D other)  {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D (Collision2D other)  {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

	void OnTriggerEnter2D(Collider2D col)  {
		int point = gm.points;
		if (col.CompareTag ("Coin")) {

			if (gm.points < 7 | (gm.points > 7 & gm.points < 9))  {
				audio1.clip = coin;
				Destroy(col.gameObject);
				//point += 1;
				gm.points += 1;
				Debug.Log (gm.points);
			}

			else if (gm.points == 7)  {
				audio1.clip = coins8;
				Destroy(col.gameObject);
				//point += 1;
				gm.points += 1;
				Debug.Log (gm.points);
			}

			else if (gm.points == 9)  {
				audio1.clip = coins10;
				Destroy(col.gameObject);
				//point += 1;
				gm.points += 1;
				Debug.Log (gm.points);
			}

			audio1.Play();
		}
	}



	//Death Animation, Work on Later
	/*void OnTriggerEnter2D (Collider2D other)  {
		if (other.CompareTag ("Coin")) {
			audio.Play();
			Destroy(other.gameObject);
			gm.points += 1;
		}
		if (other.CompareTag ("Trap"))  {
			anim.SetBool ("IsDead", true);
			StartCoroutine (levelManager.RespawnPlayer());
			//rigidbody2D.AddForce (new Vector2 (0, 500));
		}
		//anim.SetBool ("IsDead", false);


	}*/
}











