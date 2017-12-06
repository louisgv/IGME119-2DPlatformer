using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{
    /// <summary>
    /// Player Based Scrolling speed - how far this unit should move
    /// for each unit the player moves
    /// </summary>
    public Vector2 playerBasedSpeed = new Vector2(10, 10);

    /// <summary>
    /// Automatic Scrolling Speed - when not based on player
    /// </summary>
    public Vector2 automaticBasedSpeed = new Vector2(10, 10);
	
	/// <summary>
	/// How this object should move relative to the speed it is given
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

    /// <summary>
    /// Whether or not movement is based on player
    /// If true, movement is based on player
    /// If false, movement is automatic
    /// </summary>
    public bool playerBasedMovement = false;

    /// <summary>
    /// The player's position last frame.
    /// </summary>
    public Vector2 playerPrevPosition;

    /// <summary>
    /// The player.
    /// </summary>
    public GameObject player;

	
	void Start()
	{

        // Get initial position of player
        playerPrevPosition = player.transform.position;
	}

    void Update()
    {
        //Where we will move this frame
        Vector3 movement;

        // If we're moving based on player, 
        // see how player moved and move accordingly
        if (playerBasedMovement)
        {
            Vector2 playerCurrPosition = player.transform.position;
            Vector2 positionChange = playerCurrPosition - playerPrevPosition;

            movement = new Vector3(
                playerBasedSpeed.x * direction.x * positionChange.x,
                playerBasedSpeed.y * direction.y * positionChange.y,
              0);
        }

        // Otherwise, if we're moving automatically, just move based on our 
        // automaticBasedSpeed and Time.DeltaTime
        else
        {
            // Movement
            movement = new Vector3(
                automaticBasedSpeed.x * direction.x,
                automaticBasedSpeed.y * direction.y,
              0);

            movement *= Time.deltaTime;
        }

        // Move and update playerPrevPosition
        transform.Translate(movement);
        playerPrevPosition = player.transform.position;


    }
}