using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour, ITriggerable {

    public Rigidbody fallingBlock;
    
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
            isCut_ = true;
            fallingBlock.isKinematic = false;
            fallingBlock.WakeUp();
            Destroy(gameObject);
        }
    }
}