using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScriptPlatformer : MonoBehaviour {
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(25, 25);
	public AudioSource source;
	public AudioClip audio_Shot;

	// 2 - Store the movement
	private Vector2 movement;

	void Start(){
		//get all attached audiosources in list
		//check for audioClip: if name = __ do __
		source = GetComponent<AudioSource>();
	}
	
	void Update()
	{

		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			source.PlayOneShot(audio_Shot);
			WeaponScript weapon = GetComponent<WeaponScript>();
		
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);

				//Animate shot
				gameObject.GetComponentInChildren<Animator>().SetInteger("Direction", 4);
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
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
		
		// End of the update method
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		GetComponent<Rigidbody2D>().velocity = movement;
	}


}
