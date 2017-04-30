using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayVideos : MonoBehaviour {

	public Button SkipVideo;


	// Use this for initialization
	void Start () {

		SkipVideo.onClick.AddListener (skipBtn);

		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		//Handheld.PlayFullScreenMovie ("inicio.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void skipBtn(){

		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Stop ();
		GetComponent<MeshRenderer> ().enabled = false;

	}

}
