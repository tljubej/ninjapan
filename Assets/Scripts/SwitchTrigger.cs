using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {

    public MonoBehaviour triggerable;
    
    void OnTriggerEnter(Collider other)
    {
	switch (other.tag) {
	    case TagManager.player:
            case TagManager.fallingBlock:
            case TagManager.fallingFloor:
		trigger();
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
		break;
	    default:
		break;
	}
    }

    private void trigger()
    {
        transform.Translate(Vector3.down * 0.25f, Space.World);
        BoxCollider box = collider as BoxCollider;
        box.size  = box.size + Vector3.right;
        (triggerable as ITriggerable).Trigger();
    }

    private void untrigger()
    {
        transform.Translate(Vector3.up * 0.25f, Space.World);
        BoxCollider box = collider as BoxCollider;
        box.size  = box.size - Vector3.right;
        (triggerable as ITriggerable).Untrigger();
    }
}
