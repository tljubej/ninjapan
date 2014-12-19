using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour, ITriggerable {

    public Rigidbody fallingBlock;

    public float volLow = 0.75f;
    public float volHigh = 0.75f;
    public AudioClip cuttingSound = null;
    
    private bool isCut_ = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagManager.shuriken) {
            cutRope();
        }
    }
    
    void ITriggerable.Trigger()
    {
        cutRope();
    }

    void ITriggerable.Untrigger()
    {
    }

    private void cutRope()
    {
        if (!isCut_) {
            float vol = Random.Range(volLow, volHigh);
            AudioSource.PlayClipAtPoint(cuttingSound, transform.position, vol);
            isCut_ = true;
            fallingBlock.isKinematic = false;
            fallingBlock.WakeUp();
            Destroy(gameObject);
        }
    }
}