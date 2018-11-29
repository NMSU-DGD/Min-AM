using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;
	private GameMaster gm;
	private int toyPoints;

	public string levelToLoad;
	//public int levelToLoad;

	// Use this for initialization
	void Start () {
	
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		//toyPoints = gm.points;
		//playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		toyPoints = gm.points;
	}

	void OnTriggerEnter2D (Collider2D other)  {
		if (other.CompareTag ("Player")) {
			if (toyPoints >= 6) {
				gm.InputText.text = ("[E] to Open");
				if (Input.GetKeyDown ("e")) {
					Application.LoadLevel (levelToLoad);
				}
			}
			else  {
				gm.InsufficientText.text = ("Insufficient Toys Collected");
			}
		}
		/*if (other.name == "Player") {
			playerInZone = true;
		}*/
	}

	void OnTriggerStay2D (Collider2D other)  {
		if(other.CompareTag("Player"))  {
			if (toyPoints >= 6) {
				if (Input.GetKeyDown ("e")) {
					Application.LoadLevel (levelToLoad);
				}
			}
		}
		/*if (other.name == "Player") {
			playerInZone = true;
		}*/
	}

	void OnTriggerExit2D (Collider2D other)  {
		if (other.CompareTag("Player")) {
			gm.InputText.text = (" ");
			gm.InsufficientText.text = (" ");
		}
	}
}
