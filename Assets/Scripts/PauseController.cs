using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public void MainMenu(){
		Application.LoadLevel("MainMenu");
	}

	public void RestartGame(){
		Application.LoadLevel("Level1");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void ResumeGame(){
		GameObject pause  = GameObject.FindGameObjectWithTag ("Pause");
		Destroy(pause);
		Time.timeScale = 1.0f;
	}
}
