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
        GameObject mainCamera = GameObject.FindWithTag(TagManager.mainCamera);
        GameObject pauseCamera = GameObject.Find("PauseCamera");
        pauseCamera.transform.localPosition = mainCamera.transform.localPosition;
        pauseCamera.transform.localRotation = mainCamera.transform.localRotation;
        pauseCamera.transform.localScale = mainCamera.transform.localScale;
        pauseCamera.transform.localEulerAngles = mainCamera.transform.localEulerAngles;

        float scale = Screen.width / 700f * 2.0f;

        // background
        pauseBackground.localScale = new Vector3(scale * 20f, scale * 20f, 1f);

        //title
        float titleY = Screen.height / 2f - Screen.height / 5f;
        title.localScale = new Vector3(scale * 30f, scale * 30f, 1f);
        title.localPosition = new Vector3(0f, titleY, -7f * scale);

        //resume button
        float resumeY = 0.0f;
        resumeButton.localPosition = new Vector3(0f, resumeY, 0f);
        resumeButton.localScale = new Vector3(scale * 1.5f, scale * 1.5f, 1f);
		
        //restart button
        float restartY = 0f - Screen.height / 7f;
        restartButton.localPosition = new Vector3(0f, restartY, 0f);
        restartButton.localScale = new Vector3(scale * 1.5f, scale * 1.5f, 1f);
		
        //main menu button
        float mainMenuY = -Screen.height / 7f * 2f;
        mainMenuButton.localPosition = new Vector3(0f, mainMenuY, 0f);
        mainMenuButton.localScale = new Vector3(scale * 1.5f, scale * 1.5f, 1f);

        //quit button
        float quitY = -Screen.height / 7f * 3f;
        quitButton.localPosition = new Vector3(0f, quitY, 0f);
        quitButton.localScale = new Vector3(scale * 1.5f , scale * 1.5f, 1f);
    }
}
