using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

    public float destroyAfter = 2.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (rigidbody.IsSleeping()) {
            Destroy(gameObject, destroyAfter);
        }
    }
}
