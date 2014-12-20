using UnityEngine;
using System.Collections;

public class PauseItems : MonoBehaviour {
	
	public Transform resumeButton;
	public Transform restartButton;
	public Transform mainMenuButton;
	public Transform quitButton;
	public Transform pauseBackground;
	public Transform title;
	
	// Update is called once per frame
	void Update () {
		GameObject mainCamera = GameObject.Find("Main Camera");
		GameObject pauseCamera = GameObject.Find("PauseCamera");
		pauseCamera.transform.localPosition = mainCamera.transform.localPosition;
		pauseCamera.transform.localRotation = mainCamera.transform.localRotation;
		pauseCamera.transform.localScale = mainCamera.transform.localScale;
		pauseCamera.transform.localEulerAngles = mainCamera.transform.localEulerAngles;

		float scale = Screen.width / 700f * 2;

		// background
		pauseBackground.localScale = new Vector3(scale * 20, scale * 20, 1);

		//title
		float titleY = Screen.height / 2f - Screen.height / 5f;
		title.localScale = new Vector3(scale * 30, scale * 30, 1);
		title.localPosition = new Vector3(0, titleY, -7 * scale);

		//resume button
		float resumeY = 0;
		resumeButton.localPosition = new Vector3(0, resumeY, 0);
		resumeButton.localScale = new Vector3(scale * 1.5f, scale * 1.5f, 1);
		
		//restart button
		float restartY = 0 - Screen.height / 7f;
		restartButton.localPosition = new Vector3(0, restartY, 0);
		restartButton.localScale = new Vector3(scale * 1.5f, scale * 1.5f, 1);
		
		//main menu button
		float mainMenuY = -Screen.height / 7f * 2;
		mainMenuButton.localPosition = new Vector3(0, mainMenuY, 0);
		mainMenuButton.localScale = new Vector3(scale * 1.5f, scale * 1.5f, 1);

		//quit button
		float quitY = -Screen.height / 7f * 3;
		quitButton.localPosition = new Vector3(0, quitY, 0);
		quitButton.localScale = new Vector3(scale * 1.5f , scale * 1.5f, 1);


	}
}
