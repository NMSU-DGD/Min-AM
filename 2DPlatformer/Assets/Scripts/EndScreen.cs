using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

	public Text LevelText;
	public Text ObjectiveText;

	public GameObject endScreenCanvas;

	void Start () {
		
		StartCoroutine (Waiting("TitleScene"));
	}
	
	IEnumerator Waiting (string levelName) {
		yield return new WaitForSeconds (5f);
		endScreenCanvas.SetActive (true);
		yield return new WaitForSeconds (2f);
		LevelText.text = ("You woke up!");
		yield return new WaitForSeconds (2f);
		ObjectiveText.text = ("You successfully escaped your nightmare");
		yield return new WaitForSeconds (7f);
		Application.LoadLevel (levelName);
	}
}
