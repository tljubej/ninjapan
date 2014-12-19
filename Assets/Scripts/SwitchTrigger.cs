using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {

    public MonoBehaviour triggerable;

    private bool isTriggered_ = false;
    private AudioSource source_ = null;
    public float pitchLow = 0.75f;
    public float pitchHigh = 1.25f;
    public float volLow = 0.75f;
    public float volHigh = 1.0f;

    void Start()
    {
        source_ = GetComponent<AudioSource>();
    }
    
    void OnTriggerStay(Collider other)
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
                if (isTriggered_) {
                    untrigger();
                    isTriggered_ = false;
                }
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
        source_.pitch = Random.Range(pitchLow, pitchHigh);
        source_.volume = Random.Range(volLow, volHigh);
        source_.Play();
    }

    private void untrigger()
    {
        transform.Translate(Vector3.up * 0.25f, Space.World);
        BoxCollider box = collider as BoxCollider;
        box.size  = box.size - Vector3.right - 2.0f * Vector3.up;
        (triggerable as ITriggerable).Untrigger();
    }
}
