using UnityEngine;
using System.Collections;

public class NavigationController : MonoBehaviour {

    public void MainMenu(){
        Time.timeScale = 1.0f;
        Application.LoadLevel("MainMenu");
    }

    public void RestartGame(){
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ResumeGame(){
        GameObject pause = GameObject.FindWithTag(TagManager.pauseMenu);
        Destroy(pause);
        Time.timeScale = 1.0f;
    }
}
