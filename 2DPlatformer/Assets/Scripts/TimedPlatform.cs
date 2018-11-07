using UnityEngine;
using System.Collections;

public class TimedPlatform : MonoBehaviour {

	public GameObject gameobj;
	
	void Start()
	{
		InvokeRepeating("DisappearanceLogic", 0, 1.0f);
	}
	
	void DisappearanceLogic() 
	{
		if(gameobj.activeSelf) 
		{
			gameobj.SetActive(false);
		}
		else
		{
			gameobj.SetActive(true);
		}
	}
}
