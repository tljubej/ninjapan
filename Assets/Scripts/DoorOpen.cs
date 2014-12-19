using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour, ITriggerable {

    public float openSpeed = 2.0f;
    public float closeSpeed = 0.4f;

    public float openOffset = 3.0f;
    
    private bool isOpening_ = false;
    private Vector3 startPos_;
    private Vector3 endPos_;

    public float pitchLow = 0.75f;
    public float pitchHigh = 1.5f;
    public float volLow = 0.75f;
    public float volHigh = 1.0f;
    public AudioClip openingSound;
    public AudioClip openedSound;
    public AudioClip closedSound;

    private AudioSource source_ = null;
    private bool isClosed_ = true;
    private bool isOpened_ = false;

    void Start()
    {
        startPos_ = transform.position;
        endPos_ = startPos_;
        endPos_.y += openOffset;
        source_ = GetComponent<AudioSource>();
    }

    void Update()
    {
	Vector3 moveDirection = updateMoveDirection();
	transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }

    private Vector3 updateMoveDirection()
    {
	Vector3 direction = Vector3.zero;
	
	if (isOpening_) {
	    if (transform.position.y < endPos_.y) {
                direction.y = openSpeed;
            } else if (!isOpened_) {
                isOpened_ = true;
                source_.Stop();
                playSound(openedSound);
            }
	} else {
            if (transform.position.y > startPos_.y) {
                direction.y = -closeSpeed;
            } else if (!isClosed_) {
                isClosed_ = true;
                source_.Stop();
                playSound(closedSound);
            }
        }
	return direction;
    }

    private void playSound(AudioClip sound)
    {
        source_.pitch = Random.Range(pitchLow, pitchHigh);
        source_.PlayOneShot(sound, 1.0f);
    }
    
    void ITriggerable.Trigger()
    {
        if (!isOpening_) {
            isOpening_ = true;
            isClosed_ = false;
            source_.Stop();
            playSound(openingSound);
        }
    }

    void ITriggerable.Untrigger()
    {
        if (isOpening_) {
            source_.pitch = Random.Range(pitchLow, pitchHigh);
            source_.volume = Random.Range(volLow, volHigh);
            source_.Play();
            isOpening_ = false;
            isOpened_ = false;
        }
    }
}
