using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {

    private Transform[] coinSpawns;
    public GameObject coin;
    public bool shouldSpawnCoins = false;

	// Use this for initialization
	void Start () {
        if (shouldSpawnCoins)
        {
            coinSpawns = gameObject.GetComponentsInChildren<Transform>();
            Spawn();
        }
	}
	
	void Spawn () {
		int coinFlip = Random.Range(0, 2);
		if (coinFlip == 1) {
			int whereToSpawn = Random.Range (0, 3);
            coin = Instantiate (coin, coinSpawns [whereToSpawn].position, Quaternion.identity, transform.parent);
		}
	}
}
