using UnityEngine;
using System.Collections;

public class PreLvl1 : MonoBehaviour {

	void Start () {
	
		StartCoroutine (Waiting("Level1Scene"));
	}
	
	IEnumerator Waiting (string levelName) {
	
		yield return new WaitForSeconds (3f);
		Application.LoadLevel (levelName);
	}
}

/*using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    bool loadingStarted = false;
    float secondsLeft = 0;

	public string startLevel;


    void Start()
    {
        StartCoroutine(DelayLoadLevel(5));
    }

    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        loadingStarted = true;
        do
        {
            yield return new WaitForSeconds(1);
        } while (--secondsLeft > 0);

        Application.LoadLevel(startLevel);
    }

    void OnGUI()
    {
        if (loadingStarted)
            GUI.Label(new Rect(0, 0, 100, 20), secondsLeft.ToString());
    }
}*/
