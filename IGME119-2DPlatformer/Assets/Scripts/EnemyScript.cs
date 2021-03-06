﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    static float platformLength = SpawnPlatforms.horizontalMin;

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 2f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
    public Transform player;
	public WeaponScript weapon;

    private bool grounded = false;
	private bool leftGrounded = false;
	private bool rightGrounded = false;
    private bool shotLastFrame = false;

    private Animator anim;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        weapon = this.GetComponentInChildren<WeaponScript> ();
		weapon.enabled = true;
        anim = gameObject.GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		leftGrounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground"));
		rightGrounded = Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"));


		// Auto-Fire
        if (weapon != null && weapon.enabled && weapon.CanAttack && !anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Shoot"))
		{
            //source.PlayOneShot(audio_Shot);
            Debug.Log(weapon + "Fire");
            weapon.Attack(true);
            gameObject.GetComponent<Animator>().SetTrigger("Shoot");
        }

//		// 4 - Out of the camera ? Destroy the game object.
//		if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
//		{
//			Destroy(gameObject);
//		}

		if (player != null) {
			if (player.position.x < gameObject.transform.position.x && leftGrounded) {
				gameObject.transform.Translate (maxSpeed * Time.deltaTime * -1f, 0, 0);
                gameObject.GetComponent<Animator>().SetBool ("Moving", true);
			} else if (player.position.x > gameObject.transform.position.x && rightGrounded) {
				gameObject.transform.Translate (maxSpeed * Time.deltaTime, 0, 0);
                gameObject.GetComponent<Animator>().SetBool ("Moving", true);
			}
		}
    }

    void FixedUpdate()
    {



//        if (h > 0 && !facingRight)
//            Flip();
//        else if (h < 0 && facingRight)
//            Flip();

        //if (jump)
        //{
        //    //anim.SetTrigger("Jump");
        //    rb2d.AddForce(new Vector2(0f, jumpForce));
        //    jump = false;
        //}
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	private void endShoot()
	{
		//anim.SetBool("Shoot",false);
	}

	private void endWalk()
	{
        //gameObject.GetComponent<Animator>().SetBool("Moving",false);
	}

	private void endInjury()
	{
		//anim.SetBool("Injury",false);
	}

}
