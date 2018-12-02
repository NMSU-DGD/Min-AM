using UnityEngine;
using System.Collections;

public class PreLvl2 : MonoBehaviour {

	void Start () {
		
		StartCoroutine (Waiting("Level2Scene"));
	}
	
	IEnumerator Waiting (string levelName) {
		
		yield return new WaitForSeconds (3f);
		Application.LoadLevel (levelName);
	}
}
