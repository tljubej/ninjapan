using UnityEngine;
using System.Collections;

public class PauseItems : MonoBehaviour {
	
	public Transform resumeButton;
	public Transform restartButton;
	public Transform mainMenuButton;
	public Transform quitButton;
	
	// Update is called once per frame
	void Update () {
		float scale = Screen.width / 700f * 2;
		
		//resume button
		float resumeY = 0;
		resumeButton.localPosition = new Vector3(0, resumeY, 0);
		resumeButton.localScale = new Vector3(scale, scale, 1);
		
		//restart button
		float restartY = 0 - Screen.height / 9f;
		restartButton.localPosition = new Vector3(0, restartY, 0);
		restartButton.localScale = new Vector3(scale, scale, 1);
		
		//main menu button
		float mainMenuY = -Screen.height / 9f * 2;
		mainMenuButton.localPosition = new Vector3(0, mainMenuY, 0);
		mainMenuButton.localScale = new Vector3(scale, scale, 1);

		//quit button
		float quitY = -Screen.height / 9f * 3;
		quitButton.localPosition = new Vector3(0, quitY, 0);
		quitButton.localScale = new Vector3(scale, scale, 1);


	}
}
