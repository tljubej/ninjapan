using UnityEngine;
using System.Collections;

public class FallingFloor : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag) {
            case TagManager.player:
            case TagManager.fallingFloor:
            case TagManager.fallingBlock:
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
