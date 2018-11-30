using UnityEngine;
using System.Collections;

public class menuMusic : MonoBehaviour {
	
	static bool AudioBegin = false; 
	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void Awake()
	{
		if (!AudioBegin) {
			audio.Play ();
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
		} 
	}
	void Update () {
		if(Application.loadedLevelName == "ControlsScene")
		{
			audio.Stop();
			AudioBegin = false;
		}
	}
}
