using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Moving speed
    public float speed = 6.0f;
    // Jumping speed
    public float jumpSpeed = 8.0f;
    // Falling speed
    public float gravity = 20.0f;

    private CharacterController controller_;
    // Current move direction
    private Vector3 moveDirection_ = Vector3.zero;
    // Last trigger spawn point
    private Vector3 activeSpawnPoint_ = Vector3.zero;
    
    void Awake()
    {
        controller_ = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
	if (controller_.isGrounded) {
	    moveDirection_ = updateMoveDirection();
	}
	moveDirection_.y -= gravity * Time.deltaTime;
        CollisionFlags collisionFlags = controller_.Move(moveDirection_ * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
	switch (other.tag) {
	    case TagManager.spikes:
		dieBySpikes();
		break;
	    case TagManager.spawnPoint:
		activateSpawnPoint(other.transform.position);
		break;
	    default:
		break;
	}
    }

    /// <summary>
    ///   Handles input for basic movement (running and jumping).
    /// </summary>
    private Vector3 updateMoveDirection()
    {
        float h = Input.GetAxis("Horizontal");
	Vector3 moveDirection = (Vector3.right * h).normalized;
	moveDirection.x  *= speed;
	if (Input.GetButton("Jump")) {
	    moveDirection.y = jumpSpeed;
	}
	return moveDirection;
    }

    /// <summary>
    ///   Handles triggering of spike trap and runs death animation.
    /// </summary>
    private void dieBySpikes()
    {
	Debug.Log("died by spikes");
	transform.position = activeSpawnPoint_;
    }

    /// <summary>
    ///   Sets the new active spawn point.
    /// </summary>
    private void activateSpawnPoint(Vector3 position)
    {
	activeSpawnPoint_ = position;
    }
}
