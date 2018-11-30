using UnityEngine;
using System.Collections;

public class ControlsMenu : MonoBehaviour {

	public string backLevel;

	public void backButton()  {
		Application.LoadLevel (backLevel);
	}

}
