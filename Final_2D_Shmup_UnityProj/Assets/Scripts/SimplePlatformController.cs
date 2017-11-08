using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 0;
	public bool shouldFlip = false;
	public AudioSource source;
	public AudioClip audio_Shot;
    public Transform groundCheck;


    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
		anim.enabled = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
			Debug.Log ("Player jumped");
            jump = true;
        }

		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		shoot |= Input.GetKeyDown (KeyCode.Space);
		// Careful: For Mac users, ctrl + arrow is a bad idea

		Debug.Log (anim.GetBool("Shoot"));
		if (shoot)
		{
			source.PlayOneShot(audio_Shot);
			WeaponScript weapon = GetComponent<WeaponScript>();

			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
				anim.SetBool("Shoot", true);

			}
		}

		// 6 - Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
		).x;

		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
		).x;

//		var topBorder = Camera.main.ViewportToWorldPoint(
//			new Vector3(0, 0, dist)
//		).y;
//
//		var bottomBorder = Camera.main.ViewportToWorldPoint(
//			new Vector3(0, 1, dist)
//		).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			transform.position.y,
			transform.position.z
		);

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (shouldFlip) {
			if (h > 0 && !facingRight)
				Flip ();
			else if (h < 0 && facingRight)
				Flip ();
		}

        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
		transform.Rotate(0,180f,0);
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

		// Collision with enemy
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			// Kill the enemy
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

			damagePlayer = true;
		}

		// Damage the player
		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
	}

	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}

}