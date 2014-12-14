using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour, ITriggerable {

    public float openSpeed = 2.0f;
    public float closeSpeed = 0.4f;

    public float openOffset = 3.0f;
    
    private bool isOpening_ = false;
    private Vector3 startPos_;
    private Vector3 endPos_;

    void Start()
    {
        startPos_ = transform.position;
        endPos_ = startPos_;
        endPos_.y += openOffset;
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
            }
	} else {
            if (transform.position.y > startPos_.y) {
                direction.y = -closeSpeed;
            }
        }
	return direction;
    }
    
    void ITriggerable.Trigger()
    {
        isOpening_ = true;
    }

    void ITriggerable.Untrigger()
    {
        isOpening_ = false;
    }
}
