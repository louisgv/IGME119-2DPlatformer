using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile behavior
/// </summary>

public class ShotScript : MonoBehaviour {
	// 1 - Designer variables
	
	/// <summary>
	/// Damage inflicted
	/// </summary>
	public int damage = 1;
	
	/// <summary>
	/// Projectile damage player or enemies?
	/// </summary>
	public bool isEnemyShot = false;

	/// <summary>
	/// The life time of the bullet.
	/// After this many seconds, the bullet will die naturally.
	/// </summary>
	public float lifeTime = .25f;
	
	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		Destroy(gameObject, lifeTime); // 20sec
	}
}
