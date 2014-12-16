using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public void StartGame () {
		Application.LoadLevel("Level1");
	}

	public void ExitGame(){
		Application.Quit();
	}
}
