using UnityEngine;
using System.Collections;

public class FallingBlockSound : MonoBehaviour {

    private AudioSource source_;

    public float pitchLow = 0.75f;
    public float pitchHigh = 1.25f;
    public float volLow = 0.65f;
    public float volHigh = 1.0f;
    
    // Use this for initialization
    void Start()
    {
	source_ = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        source_.pitch = Random.Range(pitchLow, pitchHigh);
        source_.volume = Random.Range(volLow, volHigh);
        source_.Play();
    }
}
