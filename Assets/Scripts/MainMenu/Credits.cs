using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject creditsBackgorund;
	public GameObject creditsCamera;
	public GameObject creditsText;

	void OnBecameInvisible() {
		Destroy(creditsBackgorund);
		Destroy(creditsCamera);
		Destroy(creditsText);
	}
}
