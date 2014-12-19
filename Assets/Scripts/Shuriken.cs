using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

    public float destroyAfter = 2.0f;

    public float pitchLow = 0.75f;
    public float pitchHigh = 1.25f;
    public float volLow = 0.75f;
    public float volHigh = 1.0f;

    private AudioSource source_ = null;

    void Start()
    {
        source_ = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (rigidbody.IsSleeping()) {
            Destroy(gameObject, destroyAfter);
            rigidbody.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        source_.pitch = Random.Range(pitchLow, pitchHigh);
        source_.volume = Random.Range(volLow, volHigh);
        source_.Play();
    }
}
