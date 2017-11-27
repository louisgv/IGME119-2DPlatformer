using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platform;
	public GameObject enemy;
	public GameObject enemyLayer;
	public GameObject groundLayer;
	public GameObject player;

	/// <summary>
	/// How high above the platform to spawn enemies.
	/// </summary>
	private const float DIST_ABOVE_PLATFORM = .75f;


	/// <summary>
	/// Used in platform spawning.
	/// The minimum horizontal distance between two platforms.
	/// </summary>
    public float horizontalMin = 6.5f;


	/// <summary>
	/// Used in platform spawning.
	/// The maximum horizontal distance between two platforms.
	/// </summary>
    public float horizontalMax = 14f;


	/// <summary>
	/// Used in platform spawning.
	/// The minimum vertical distance between two platforms.
	/// Keep in mind how high the player can jump when setting this.
	/// </summary>
    public float verticalMin = -6f;


	/// <summary>
	/// Used in platform spawning.
	/// The minimum vertical distance between two platforms.
	/// Keep in mind how high the player can jump when setting this.
	/// </summary>
    public float verticalMax = 6f;

	/// <summary>
	/// Used in platform spawning.
	/// Offset from top/bottom that  we want platforms to spawn at.
	/// (i.e. we don't want the platforms to spawn 
	/// any closer than 1f away from the edge.)
	/// </summary>
	public float offset = 2f;

	/// <summary>
	/// Using in enemy spawning.
	/// Probability from 0-1 that an enemy will spawn on a platform.
	/// </summary>
	public float enemySpawnProb = .33f;

	/// <summary>
	/// Whether or not platforms should be randomly generated.
	/// Want to manually make your own levels? Set this false and go nuts.
	/// </summary>
	public bool shouldSpawnPlatforms = true;

	/// <summary>
	/// Whether or not enemies should be randomly generated.
	/// Want to manually make your own levels? Set this false and go nuts.
	/// </summary>
	public bool shouldSpawnEnemies = true;

	/// <summary>
	/// The position from which the next platform will spawn.
	/// Changes throughout spawning process.
	/// </summary>
    private Vector2 originPosition;

	void Start () {

        originPosition = transform.position;
        Spawn();

	}

	void Update () {
	}

	/// <summary>
	/// Spawns platforms.
	/// </summary>
    void Spawn()
    {

		//Iteratively spawn platfors, each being placed relative to the last.
		if (shouldSpawnPlatforms) {
			for (int i = 0; i < maxPlatforms; i++) {

				//Spawn the platform
				Vector2 randomPosition = originPosition +
				                                 new Vector2 (
					                                 Random.Range (horizontalMin, horizontalMax), 
					                                 Random.Range (verticalMin, verticalMax));

				randomPosition = CameraClamp (randomPosition, offset);
				Instantiate (platform, randomPosition, Quaternion.identity, groundLayer.transform);
				originPosition = randomPosition;

				//Optionally spawn enemy on platform
				if (shouldSpawnEnemies) {
					randomPosition.y += DIST_ABOVE_PLATFORM;
					if (Random.Range (0.0f, 1.0f) < enemySpawnProb) {
						GameObject newEnemy = Instantiate (enemy, randomPosition, Quaternion.identity, enemyLayer.transform);
						newEnemy.GetComponent<EnemyScript> ().player = player.transform;
					}
				}
			}
		}


    }

	/// <summary>
	/// Clamps a 2D position to the y position of the camera
	/// </summary>
	/// <returns>The clamped position.</returns>
	/// <param name="offset">Offset from top/bottom</param>
	/// <param name="position">Position to be clamped.</param>
	public Vector2 CameraClamp(Vector2 position, float offset) {

		// 6 - Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;

		float topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
		).y;
			
		float bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
		).y;

		return new Vector2(
			position.x,
			Mathf.Clamp(position.y, topBorder + offset, bottomBorder - offset)
		);

	}

}
