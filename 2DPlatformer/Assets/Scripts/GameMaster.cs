using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	//public float levelStartDelay = 2f;
	public int points;
	public Text toyText;
	public Text objectiveText;
	public Text exitText;
	public Text InputText;
	public Text InsufficientText;

	//public AudioSource audio;

	//private Text levelText;
	//private GameObject levelImage;
	//private bool doingSetup;

	// Use this for initialization
	void Start () {
		Invoke("DisableText", 5f);
		//audio = GetComponent<AudioSource>();
		//Invoke ("PlayAudio", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		toyText.text = ("Coins: " + points + " / 10");
		if (points == 8) {
			exitText.text = ("EXIT OPEN!");
			StartCoroutine (BlinkText());
		}
	}

	void DisableText ()  {
		objectiveText.enabled = false;
	}

	/*void PlayAudio()   {
		if (points == 6) {
			audio.Play();
		}
	}*/

	public IEnumerator BlinkText()  {
		int a = 0;
		while (a != 7) {
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

