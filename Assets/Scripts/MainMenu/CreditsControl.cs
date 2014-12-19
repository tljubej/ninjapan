using UnityEngine;
using System.Collections;

public class CreditsControl : MonoBehaviour {

	public Transform creditText;
	public KeyCode stopCredits;
	public GameObject creditsBackgorund;
	public GameObject creditsCamera;
	public GameObject creditsText;

	private float speed = 1f;
	
	// Update is called once per frame
	void Update () {
		creditText.Translate(Vector3.up * Time.deltaTime * speed);
		if(Input.GetKey(stopCredits)){
			Destroy(creditsBackgorund);
			Destroy(creditsCamera);
			Destroy(creditsText);
		}
	}
}
