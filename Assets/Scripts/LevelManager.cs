using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private Platformer2DUserControl player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Platformer2DUserControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()  {
		Debug.Log ("Player Respawn");
		player.transform.position = currentCheckpoint.transform.position;
	}
}
