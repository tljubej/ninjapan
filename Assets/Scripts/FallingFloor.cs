using UnityEngine;
using System.Collections;

public class FallingFloor : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
	switch (other.tag) {
	    case TagManager.player:
		fallDown();
		break;
	    default:
		break;
	}
    }

    private void fallDown()
    {
	Rigidbody rigidbody = GetComponentInParent<Rigidbody>();
	rigidbody.isKinematic = false;
	rigidbody.WakeUp();
    }
}
