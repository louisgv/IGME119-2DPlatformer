using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{
    /// <summary>
    /// Scrolling speed
    /// </summary>
    public Vector2 playerBasedSpeed = new Vector2(10, 10);

    /// <summary>
    /// Scrolling speed
    /// </summary>
    public Vector2 automaticBasedSpeed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

    /// <summary>
    /// Whether or not movement is based on player
    /// If true, movement is based on player
    /// If false, movement is automatic
    /// </summary>
    public bool playerBasedMovement = false;

    public Vector2 playerPrevPosition;
    public GameObject player;

	
	// 3 - Get all the children
	void Start()
	{
        playerPrevPosition = player.transform.position;
	}

    void Update()
    {
        Vector3 movement;
        if (playerBasedMovement)
        {
            Vector2 playerCurrPosition = player.transform.position;
            Vector2 positionChange = playerCurrPosition - playerPrevPosition;

            movement = new Vector3(
                playerBasedSpeed.x * direction.x * positionChange.x,
                playerBasedSpeed.y * direction.y * positionChange.y,
              0);
        }
        else
        {
            // Movement
            movement = new Vector3(
                automaticBasedSpeed.x * direction.x,
                automaticBasedSpeed.y * direction.y,
              0);

            movement *= Time.deltaTime;
        }

        transform.Translate(movement);
        playerPrevPosition = player.transform.position;


    }
}