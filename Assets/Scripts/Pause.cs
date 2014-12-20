using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public KeyCode pauseKey;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(pauseKey) && GameObject.FindGameObjectWithTag("Pause") == null){
			Time.timeScale = 0f;
			Application.LoadLevelAdditive("Pause");
		}
	}
}
