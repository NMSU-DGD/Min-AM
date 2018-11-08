using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	//public float levelStartDelay = 2f;
	public int points;
	public Text toyText;
	public Text objectiveText;
	public Text exitText;

	//private Text levelText;
	//private GameObject levelImage;
	//private bool doingSetup;

	// Use this for initialization
	void Start () {
		Invoke("DisableText", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		toyText.text = ("Toys: " + points + " / 8");
		if (points >= 6) {
			exitText.text = ("EXIT OPEN!");
			StartCoroutine (BlinkText());
		}
	}

	void DisableText ()  {
		objectiveText.enabled = false;
	}
	
	public IEnumerator BlinkText()  {
		int a = 0;
		while (a != 5) {
			exitText.text = "";
			yield return new WaitForSeconds (0.5f);
			exitText.text = ("EXIT OPEN!");
			yield return new WaitForSeconds (0.5f);
			a++;
		}
		Invoke("DisableText1", 0.0f);	
	}
	
	void DisableText1()  {
		exitText.enabled = false;
	}
}

