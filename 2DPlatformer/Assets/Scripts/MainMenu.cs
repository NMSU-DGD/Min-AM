using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string controls;

	public void NewGame()  {
		Application.LoadLevel (startLevel);
	}

	public void ControlsButton()  {
		Application.LoadLevel (controls);
	}

	public void QuitGame()  {
		Debug.Log ("Game Quit");
		Application.Quit ();
	}
}
