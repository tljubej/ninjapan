using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagManager.player) {
            endLevel();
        }
    }

    private void endLevel()
    {
        Debug.Log("Ending level.");
		Time.timeScale = 0f;
		Application.LoadLevelAdditive("EndGame");
    }
}
