using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

	VideoPlayer movie;

	// Use this for initialization
	void Start ()
	{
		movie = GetComponent<VideoPlayer> ();
		movie.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!movie.isPlaying) {
			Debug.Log ("movie end");
			Application.LoadLevel ("Platformer_Float");
		}
	}
}
