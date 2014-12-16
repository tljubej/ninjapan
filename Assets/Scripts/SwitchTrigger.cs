using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {

    public MonoBehaviour triggerable;

    private bool isTriggered_ = false;
    
    void OnTriggerEnter(Collider other)
    {
	switch (other.tag) {
	    case TagManager.player:
            case TagManager.fallingBlock:
            case TagManager.fallingFloor:
                if (!isTriggered_) {
                    trigger();
                    isTriggered_ = true;
                }
		break;
	    default:
		break;
	}
    }
    
    void OnTriggerExit(Collider other)
    {
	switch (other.tag) {
	    case TagManager.player:
		untrigger();
                isTriggered_ = false;
		break;
	    default:
		break;
	}
    }

    private void trigger()
    {
        transform.Translate(Vector3.down * 0.25f, Space.World);
        BoxCollider box = collider as BoxCollider;
        box.size  = box.size + Vector3.right + 2.0f * Vector3.up;
        (triggerable as ITriggerable).Trigger();
    }

    private void untrigger()
    {
        transform.Translate(Vector3.up * 0.25f, Space.World);
        BoxCollider box = collider as BoxCollider;
        box.size  = box.size - Vector3.right - 2.0f * Vector3.up;
        (triggerable as ITriggerable).Untrigger();
    }
}
