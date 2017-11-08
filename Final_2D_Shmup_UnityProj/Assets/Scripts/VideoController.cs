using UnityEngine;
using System.Collections;

public class VideoController : MonoBehaviour {

	MovieTexture movie; 

	// Use this for initialization
	void Start () {
		movie = GetComponent<Renderer>().material.mainTexture as MovieTexture;
		movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(!movie.isPlaying){
			Debug.Log ("movie end");
			Application.LoadLevel("Platformer_Float");
		}
	}
}
