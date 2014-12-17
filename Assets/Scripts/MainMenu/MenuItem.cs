using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {
	
	public Transform playButton;
	public Transform exitButton;
	public Transform creditsButton;

	public void Update(){

		float scale = Screen.width / 700f * 2;

		//play button
		float playX = -Screen.width / 3f;

		playButton.localPosition = new Vector3(playX, 0, 0);
		playButton.localScale = new Vector3(scale, scale, 1);

		//exit button
		float exitX = Screen.width / 3f;
		exitButton.localPosition = new Vector3(exitX, 0, 0);
		exitButton.localScale = new Vector3(scale, scale, 1);

		//credits button
		float creditsY = -Screen.height / 2f + Screen.height / 15f;
		creditsButton.localPosition = new Vector3(0, creditsY, 0);
		creditsButton.localScale = new Vector3(scale / 1.25f, scale / 1.25f, 1);
	}
}
