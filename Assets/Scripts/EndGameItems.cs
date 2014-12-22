using UnityEngine;
using System.Collections;

public class EndGameItems : MonoBehaviour {

	public Transform restartButton;
	public Transform mainMenuButton;
	public Transform quitButton;
	public Transform background;
	public Transform title;
	public Transform endGameText;
	public GameObject endGameCamera;
	
	// Update is called once per frame
	void Start () {
		GameObject mainCamera = GameObject.FindWithTag(TagManager.mainCamera);
		endGameCamera.transform.localPosition = mainCamera.transform.localPosition;
		endGameCamera.transform.localRotation = mainCamera.transform.localRotation;
		endGameCamera.transform.localScale = mainCamera.transform.localScale;
		endGameCamera.transform.localEulerAngles = mainCamera.transform.localEulerAngles;
		
		float scale = Screen.width / 700f * 2.0f;
		
		// background
		background.localScale = new Vector3(scale * 20f, scale * 20f, 1f);
		
		//title
		float titleY = Screen.height / 2f - Screen.height / 5f;
		title.localScale = new Vector3(scale * 25f, scale * 25f, 1f);
		title.localPosition = new Vector3(0f, titleY, -7f * scale);

		//endGame Text
		float endgameY = Screen.height / 2f - Screen.height / 2.5f;
		endGameText.localScale = new Vector3(scale * 25f, scale * 25f, 1f);
		endGameText.localPosition = new Vector3(0f, endgameY, -7f * scale);
		
		//restart button
		float restartY = 0f - Screen.height / 7f;
		restartButton.localPosition = new Vector3(0f, restartY, -10f);
		restartButton.localScale = new Vector3(scale * 1.25f, scale * 1.25f, 1f);
		
		//main menu button
		float mainMenuY = -Screen.height / 7f * 2f;
		mainMenuButton.localPosition = new Vector3(0f, mainMenuY, -10f);
		mainMenuButton.localScale = new Vector3(scale * 1.25f, scale * 1.25f, 1f);
		
		//quit button
		float quitY = -Screen.height / 7f * 3f;
		quitButton.localPosition = new Vector3(0f, quitY, -10f);
		quitButton.localScale = new Vector3(scale * 1.25f , scale * 1.25f, 1f);
	}
}
